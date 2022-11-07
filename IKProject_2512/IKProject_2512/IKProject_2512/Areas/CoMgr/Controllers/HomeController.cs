using IKProject_2512.Areas.CoMgr.Models;
using IKProject_2512.Database;
using IKProject_2512.Models;
using IKProject_2512.Models.SignUpModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.CoMgr.Controllers
{
    [Area("CoMgr")]
    public class HomeController : Controller
    {
        private readonly IKDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HomeController(IKDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            Employee employee = new Employee();
            int id = int.Parse(HttpContext.Session.GetString("UserID"));
            employee = _context.Employees.Find(id);
            employee.Company = _context.Companies.Find(employee.CompanyID);

            return View(employee);
        }
        [HttpGet]
        public IActionResult PasswordRenewal()
        {
            int id = int.Parse(HttpContext.Session.GetString("NewUserID"));
            SignUpModel signUpModel = new SignUpModel();
            signUpModel.ID = id;
            return View(signUpModel);
        }

        [Route("CoMgr/Home/PasswordRenewal/{id}")]
        [HttpPost]
        public IActionResult PasswordRenewal(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                if (signUpModel.Password == signUpModel.LatestPassword)
                {
                    var userRegister = _context.Employees.Find(signUpModel.ID);
                    userRegister.LatestPassword = signUpModel.LatestPassword;
                    userRegister.Password = signUpModel.LatestPassword;
                    userRegister.TimeStamp++;
                    _context.Update(userRegister);
                    _context.SaveChanges();
                    ViewBag.CurrentUserID = userRegister.EmployeeID;
                    HttpContext.Session.SetString("UserID", userRegister.EmployeeID.ToString());
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(signUpModel);
        }
        [Route("CoMgr/Home/CompanyEmployeeDetails/{id}")]
        public IActionResult CompanyEmployeeDetails(int id)
        {
            ViewBag.ActiveID = int.Parse(HttpContext.Session.GetString("UserID"));
            var coMgr = _context.Employees.Find(id);
            return View(coMgr);
        }

        [HttpGet]
        public IActionResult DetailsCoMgr()
        {
            var coMgr = _context.Employees.Find(int.Parse(HttpContext.Session.GetString("UserID")));
            return View(coMgr);
        }
    }
}

