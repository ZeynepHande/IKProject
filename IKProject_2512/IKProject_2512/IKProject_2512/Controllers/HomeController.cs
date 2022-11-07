using IKProject_2512.Database;
using IKProject_2512.Models;
using IKProject_2512.Models.HomeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IKDbContext _context;

        public HomeController(ILogger<HomeController> logger, IKDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IndexModel model = new IndexModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexModel indexModel)
        {
            if (ModelState.IsValid)
            {
                //var newPMuser = _context.PlatformManagers.Where(x => x.MailAddress == indexModel.MailAddress && x.Password ==indexModel.Password).FirstOrDefault();
                var newPMuser = _context.PlatformManagers.Where(x => x.MailAddress == indexModel.MailAddress && x.Password==indexModel.Password && x.TimeStamp==0).FirstOrDefault();

                //var PMuser = _context.PlatformManagers.Where(x => x.MailAddress == indexModel.MailAddress && x.LatestPassword == indexModel.Password).FirstOrDefault();

                var PMuser = _context.PlatformManagers.Where(x => x.MailAddress == indexModel.MailAddress && x.Password == indexModel.Password && x.TimeStamp!=0).FirstOrDefault();

                //var newEmployeeUser = _context.Employees.Where(x => x.MailAddress == indexModel.MailAddress && x.Password == indexModel.Password).FirstOrDefault();

                var newEmployeeUser = _context.Employees.Where(x => x.MailAddress == indexModel.MailAddress && x.Password == indexModel.Password && x.TimeStamp==0 ).FirstOrDefault();

                //var EmployeeUser = _context.Employees.Where(x => x.MailAddress == indexModel.MailAddress && x.LatestPassword == indexModel.Password).FirstOrDefault();

                var EmployeeUser = _context.Employees.Where(x => x.MailAddress == indexModel.MailAddress && x.Password == indexModel.Password && x.TimeStamp!=0 ).FirstOrDefault();


                if (newPMuser != null) 
                {
                    int id=newPMuser.ID;
                    HttpContext.Session.SetString("NewUserID", id.ToString());
                    return RedirectToAction("PasswordRenewal", "Home", new { area = "Platform" });
                }

                if (PMuser!=null) 
                {
                    int id = PMuser.ID;
                    if (PMuser.TerminationDate <= DateTime.Today)
                    {
                        ViewBag.ErrorMessage = "Hesabınız pasife çekilmiştir. Lütfen şirketinizle iletişime geçin";
                        return View(indexModel);
                    }
                    HttpContext.Session.SetString("UserID", id.ToString());
                    return RedirectToAction("Index", "Home", new { area = "Platform" });
                }
                if (newEmployeeUser != null)
                {
                    int id = newEmployeeUser.EmployeeID;
                    HttpContext.Session.SetString("NewUserID", id.ToString());
                    bool isCoMgr = _context.Employees.Find(id).IsCompanyManager;

                    if (isCoMgr)
                    {
                        return RedirectToAction("PasswordRenewal", "Home", new { area = "CoMgr" });

                    }
                    return RedirectToAction("PasswordRenewal", "Home", new { area = "Emp" });
                }
                if (EmployeeUser != null)
                {
                    int id = EmployeeUser.EmployeeID;
                    HttpContext.Session.SetString("UserID", id.ToString());
                    bool isCoMgr = _context.Employees.Find(id).IsCompanyManager;
                    if (EmployeeUser.TerminationDate<=DateTime.Today)
                    {
                        ViewBag.ErrorMessage = "Hesabınız pasife çekilmiştir. Lütfen platform yöneticinizle konuşun";
                        return View(indexModel);
                    }
                    if (isCoMgr)
                    {
                        return RedirectToAction("Index", "Home", new { area = "CoMgr" });

                    }
                    return RedirectToAction("Index", "Home", new { area = "Emp" });
                }

            }
            if (indexModel.Password==null)
            {
                return View(indexModel);
            }
            ViewBag.ErrorMessage = "E-mail veya parola hatalı, lütfen bir daha deneyin.";
            return View(indexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
