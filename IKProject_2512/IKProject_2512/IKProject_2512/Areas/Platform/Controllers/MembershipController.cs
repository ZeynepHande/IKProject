using IKProject_2512.Areas.Platform.Models;
using IKProject_2512.Database;
using IKProject_2512.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.Platform.Controllers
{
    [Area("Platform")]
    public class MembershipController : Controller
    {
        private readonly IKDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MembershipController(IKDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MembershipList()
        {
            var mShipList = _context.MembershipPackages.Where(x=>x.IsActive==true).ToList();
            return View(mShipList);
        }


        [HttpGet]
        public IActionResult CreatePackage()
        {
            PackageModel mShipPack = new PackageModel();
            return View(mShipPack);
        }

        [HttpPost]
        public IActionResult CreatePackage(PackageModel membership)
        {
            if (ModelState.IsValid)
            {
                if (membership.PhotoFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(membership.PhotoFile.FileName);
                    string extension = Path.GetExtension(membership.PhotoFile.FileName);

                    membership.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        membership.PhotoFile.CopyTo(fileStream);
                    }
                }
                MembershipPackage newPackage = new MembershipPackage();
                newPackage.PhotoPath = membership.PhotoPath;
                newPackage.PackageName = membership.PackageName;
                newPackage.PackageMaxCapacity= membership.PackageMaxCapacity;
                newPackage.PackageBasePrice= membership.PackageBasePrice;
                newPackage.IsActive = true;

                _context.MembershipPackages.Add(newPackage);
                _context.SaveChanges();
                return RedirectToAction(nameof(MembershipList));
            }
            return View(membership);
        }
        [HttpGet]
        public IActionResult MShipEdit(int id)
        {
            var package = _context.MembershipPackages.Find(id);
            PackageModel sentPackage = new PackageModel();
            sentPackage.PackageName = package.PackageName;
            sentPackage.PackageMaxCapacity = package.PackageMaxCapacity;
            sentPackage.PackageBasePrice = package.PackageBasePrice;
            sentPackage.PhotoPath = package.PhotoPath;
            sentPackage.PackageID = package.PackageID;

            return View(sentPackage);
        }
        [HttpPost]
        public IActionResult MShipEdit(PackageModel package)
        {
            if (ModelState.IsValid)
            {
                var newPackage = _context.MembershipPackages.Find(package.PackageID);
                newPackage.PackageName = package.PackageName;
                newPackage.PackageMaxCapacity = package.PackageMaxCapacity;
                newPackage.PackageBasePrice = package.PackageBasePrice;
                newPackage.IsActive = true;
                _context.MembershipPackages.Update(newPackage);
                _context.SaveChanges();
                return RedirectToAction(nameof(MembershipList));
            }
            return View(package);
        }
        [HttpGet]
        public IActionResult MShipDetails(int id)
        {
            var package = _context.MembershipPackages.Find(id);
            return View(package);
        }

        [HttpGet]
        public IActionResult MShipDefinedCoList(int id)
        {
            var package = _context.MembershipPackages.Find(id).PackageID;
            var cp = _context.CompanyPackages.Where(x => x.PackageID == package).ToList();
            ViewBag.PackageID = id;
            ViewBag.PackageName = _context.MembershipPackages.Find(id).PackageName;
            return View(cp);
        }
        [HttpPost]
        public IActionResult MShipDefinedCoList(int id, string name)
        {
            var package = _context.MembershipPackages.Find(id);
            package.IsActive = false;
            _context.Update(package);
            _context.SaveChanges();
            return RedirectToAction(nameof(MembershipList));
        }

        [HttpGet]
        public IActionResult PassiveMembershipList()
        {
            var passivePackages = _context.MembershipPackages.Where(x => x.IsActive == false).ToList();
            return View(passivePackages);
        }
    }
}
