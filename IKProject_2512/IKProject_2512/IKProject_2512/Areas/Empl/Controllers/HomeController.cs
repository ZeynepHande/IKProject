using IKProject_2512.Database;
using IKProject_2512.Models;
using IKProject_2512.Models.SignUpModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.Empl.Controllers
{
    [Area("Empl")]
    public class HomeController : Controller
    {
        private readonly IKDbContext _context;
        public HomeController(IKDbContext context)
        {
            _context = context;
        }


        [Area("Empl")]
        public IActionResult Index()
        {
            Employee employee = new Employee();
            int id = int.Parse(HttpContext.Session.GetString("UserID"));
            employee = _context.Employees.Find(id);
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

        [Route("Empl/Home/PasswordRenewal/{id}")]
        [HttpPost]
        public IActionResult PasswordRenewal(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                if (signUpModel.Password == signUpModel.LatestPassword)
                {
                    var userRegister = _context.Employees.Find(signUpModel.ID);
                    userRegister.Password = signUpModel.LatestPassword;
                    userRegister.LatestPassword = signUpModel.LatestPassword;
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
    }
}
