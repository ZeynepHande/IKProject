using IKProject_2512.Areas.CoMgr.Models;
using IKProject_2512.Database;
using IKProject_2512.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.CoMgr.Controllers
{
    [Area("CoMgr")]
    public class EmployeeController : Controller
    {
        protected readonly IKDbContext _context;
        protected readonly IWebHostEnvironment _hostEnvironment;
        public EmployeeController(IKDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(int coMgrId, EmployeeAddModel emp)
        {
            Employee employee = _context.Employees.Find(coMgrId); // 1, 2 gibi şirket id alıyor.


            Employee newEmployee = new Employee();
            newEmployee.CompanyID = employee.CompanyID;
            newEmployee.MailExtension = employee.MailExtension;


            if (ModelState.IsValid)
            {
                if (emp.PhotoFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(emp.PhotoFile.FileName);
                    string extension = Path.GetExtension(emp.PhotoFile.FileName);

                    emp.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        emp.PhotoFile.CopyTo(fileStream);
                    }
                }

                if (emp.EmployeeMiddleName == null)
                {
                    newEmployee.MailAddress = ProjectMethods.RemoveTurkishChars(emp.EmployeeName.ToLower().Trim().Replace(" ", "")) + "." + ProjectMethods.RemoveTurkishChars(emp.EmployeeLastName.ToLower().Trim().Replace(" ", "")) + newEmployee.MailExtension;
                }
                if (emp.EmployeeMiddleName != null)
                {
                    newEmployee.MailAddress = ProjectMethods.RemoveTurkishChars(emp.EmployeeName.ToLower().Trim().Replace(" ", "")) + ProjectMethods.RemoveTurkishChars(emp.EmployeeMiddleName.ToLower().Trim().Replace(" ", "")) + "." + ProjectMethods.RemoveTurkishChars(emp.EmployeeLastName.ToLower().Trim().Replace(" ", "")) + newEmployee.MailExtension;
                }

                if (_context.PlatformManagers.Select(x => x.MailAddress == newEmployee.MailAddress).FirstOrDefault() == true)
                {
                    return Content("Bu mail adresi ve kişi kaydı sistemde mevcuttur, lütfen giriş bilgilerinizi kontrol edin.");
                }
                string temporaryPassword = ProjectMethods.NewPasswordComposition();
                try
                {
                    SmtpClient sc = new SmtpClient();
                    sc.Port = 587;
                    sc.Host = "smtp.gmail.com";
                    sc.EnableSsl = true;
                    sc.Credentials = new NetworkCredential("ikprojeteam1@gmail.com", "Team0001");

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("ikprojeteam1@gmail.com", "Team1");
                    mail.To.Add(newEmployee.MailAddress);

                    mail.Subject = "IK Platform Projesi, Geçici Şifre Bildirimi";
                    mail.IsBodyHtml = true;
                    //mail.Body = "Merhaba değerli " + platformManager.Name + platformManager.Surname + ", " + Environment.NewLine + "platform yöneticisi olarak atandınız. Bu kapsamda"
                    //    + "Geçiçi şifreniz: " + temporaryPassword + Environment.NewLine + "Lütfen http://ikmanagement.azurewebsites.net linke tıklayarak şifrenizi oluşturunuz";
                    ////Buraya şifre değiştirme ekranı linki eklenecek

                    //sc.Send(mail);
                }
                catch (Exception)
                {
                    throw new Exception("Girmiş olduğunuz mail adresi geçerli değildir");
                }

                newEmployee.EmployeeName = emp.EmployeeName;
                newEmployee.EmployeeMiddleName = emp.EmployeeMiddleName;
                newEmployee.EmployeeLastName = emp.EmployeeLastName;
                newEmployee.Password = temporaryPassword;
                newEmployee.LatestPassword = temporaryPassword;
                newEmployee.HireDate = emp.HireDate;
                newEmployee.BirthDate = emp.BirthDate;
                newEmployee.PhotoPath = emp.PhotoPath;
                newEmployee.HomeAddress = emp.HomeAddress;
                newEmployee.Department = emp.Department;
                newEmployee.Title = emp.Title;
                newEmployee.PhoneNumber = emp.PhoneNumber;
                newEmployee.Shift = (ShiftType)emp.Shift;

                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
                return RedirectToAction(nameof(EmployeeList));
            }
            return View(emp);

        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            Employee empCompID = _context.Employees.Find(int.Parse(HttpContext.Session.GetString("UserID")));
            int companyID = empCompID.CompanyID;

            List<Employee> EmpList = new List<Employee>();
            EmpList = _context.Employees.Where(x => x.IsActive == true && x.CompanyID == companyID).ToList();

            return View(EmpList);
        }
        [HttpGet]
        public IActionResult CompanyMshipDetails()
        {
            int id = int.Parse(HttpContext.Session.GetString("UserID"));
            var employee = _context.Employees.Find(id);
            var company = _context.Companies.Find(employee.CompanyID);
            var companyPackageID = _context.Companies.Find(employee.CompanyID).CompanyPackageID;
            var mShip = _context.MembershipPackages.Find(company.JokerValue);
            company.CompanyPackage.Package = mShip;

            var CompanyPackage = _context.CompanyPackages.Find(companyPackageID);
            CompanyPackage.PackageID = company.JokerValue;

            return View(CompanyPackage);

        }
    }
}

