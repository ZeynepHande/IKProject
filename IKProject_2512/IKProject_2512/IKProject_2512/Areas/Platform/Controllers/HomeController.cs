using IKProject_2512.Areas.Platform.Models;
using IKProject_2512.Database;
using IKProject_2512.Models;
using IKProject_2512.Models.SignUpModel;
using IKProject_2512.Models.VM_PM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.Platform.Controllers
{

    [Area("Platform")]
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
            PM pm = new PM();
            int id = int.Parse(HttpContext.Session.GetString("UserID"));
            pm =  _context.PlatformManagers.Find(id);
            return View(pm);
        }
        [HttpGet]
        public IActionResult PasswordRenewal()
        {
            int id = int.Parse(HttpContext.Session.GetString("NewUserID"));
            SignUpModel signUpModel = new SignUpModel();
            signUpModel.ID = id;
            return View(signUpModel);
        }

        [Route("Platform/Home/PasswordRenewal/{id}")]
        [HttpPost]
        public IActionResult PasswordRenewal(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                //if{
                //var empPass = _context.Employees.Where(x => x.Password == x.LatestPassword).FirstOrDefault().ToString();
                //if (empPass == signUpModel.Password)
                //{
                //    var results = new List<ValidationResult>();

                //    results.Add(new ValidationResult("Yeni parola bir önceki parolanız ile aynı olamaz."));

                //}
                //else if (empPass == signUpModel.LatestPassword)
                //{
                //    var results = new List<ValidationResult>();

                //    results.Add(new ValidationResult("Yeni parola bir önceki parolanız ile aynı olamaz."));}
                //    else{
                if (signUpModel.Password == signUpModel.LatestPassword)
                {
                    var userRegister = _context.PlatformManagers.Find(signUpModel.ID);
                    userRegister.Password = signUpModel.LatestPassword;
                    userRegister.LatestPassword = signUpModel.LatestPassword;
                    userRegister.TimeStamp++;
                    _context.Update(userRegister);
                    _context.SaveChanges();
                    ViewBag.CurrentUserID = userRegister.ID;
                    HttpContext.Session.SetString("UserID", userRegister.ID.ToString());
                    return RedirectToAction(nameof(Index));

                }
                //}
            }
            return View(signUpModel);
        }
        [Route("Platform/Home/Edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var registeredUser = _context.PlatformManagers.Find(id);
            PlatformMgrAddModel pm = new PlatformMgrAddModel();
            pm.ID = registeredUser.ID;
            pm.Name = registeredUser.Name;
            pm.MiddleName = registeredUser.MiddleName;
            pm.Surname = registeredUser.Surname;
            //pm.MailAddress = registeredUser.MailAddress;
            pm.BirthDate = registeredUser.BirthDate;
            pm.HireDate = registeredUser.HireDate;
            pm.Address = registeredUser.Address;
            pm.PhotoPath = registeredUser.PhotoPath;
            return View(pm);
        }
        [Route("Platform/Home/Edit/{id}")]
        [HttpPost]
        public IActionResult Edit(PlatformMgrAddModel pm, int id)
        {
            
            if (ModelState.IsValid)
            {

                var registeredUser = _context.PlatformManagers.Find(id);

                if (registeredUser.IsAdmin == true )
                {
                    return Content("Bu kullancıyı güncelleyemezsiniz!!!");
                }
                registeredUser.Name = pm.Name;
                registeredUser.MiddleName = pm.MiddleName;
                registeredUser.Surname = pm.Surname;
                registeredUser.BirthDate = pm.BirthDate;
                registeredUser.HireDate = pm.HireDate;
                if (pm.Address != null)
                {
                    registeredUser.Address = pm.Address;
                }

                if (pm.PhotoFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(pm.PhotoFile.FileName);
                    string extension = Path.GetExtension(pm.PhotoFile.FileName);

                    pm.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        pm.PhotoFile.CopyTo(fileStream);
                    }
                }

                registeredUser.PhotoPath = pm.PhotoPath;
                ViewBag.CurrentUserID = pm.ID;
                _context.PlatformManagers.Update(registeredUser);
                _context.SaveChanges();
                return RedirectToAction(nameof(PlatformList));
            }
            return View(pm);
        }
        [HttpGet]
        public IActionResult PlatformList()
        {
            List<PM> PmList = new List<PM>();
            PmList = _context.PlatformManagers.Where(x => x.IsActive == true || x.TerminationDate > DateTime.Today).ToList();
            ViewBag.ActiveID= int.Parse(HttpContext.Session.GetString("UserID"));
            return View(PmList);
        }

        [HttpGet]
        public IActionResult PassivePlatformList()
        {
            List<PM> PmList = new List<PM>();
            PmList = _context.PlatformManagers.Where(x => x.IsActive == false && x.TerminationDate <= DateTime.Today).ToList();
            return View(PmList);
        }

        [HttpGet]
        public IActionResult AddPlatformManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlatformManager(PlatformMgrAddModel platformManager)
        {
            PM newUser = new PM();
            newUser.MailExtension = "@bilgeadamboost.com";
            if (ModelState.IsValid)
            {
                if (platformManager.PhotoFile!=null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(platformManager.PhotoFile.FileName);
                    string extension = Path.GetExtension(platformManager.PhotoFile.FileName);
                    
                    platformManager.PhotoPath = fileName=fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        platformManager.PhotoFile.CopyTo(fileStream);
                    }
                }

                if (platformManager.MiddleName == null)
                {
                    newUser.MailAddress = ProjectMethods.RemoveTurkishChars(platformManager.Name.ToLower().Trim().Replace(" ", "")) + "." + ProjectMethods.RemoveTurkishChars(platformManager.Surname.ToLower().Trim().Replace(" ","")) + newUser.MailExtension;
                }
                if (platformManager.MiddleName != null)
                {
                    newUser.MailAddress = ProjectMethods.RemoveTurkishChars(platformManager.Name.ToLower().Trim().Replace(" ", "")) + ProjectMethods.RemoveTurkishChars(platformManager.MiddleName.ToLower().Trim().Replace(" ", "")) + "." + ProjectMethods.RemoveTurkishChars(platformManager.Surname.ToLower().Trim().Replace(" ", "")) + newUser.MailExtension;
                }

                if (_context.PlatformManagers.Select(x => x.MailAddress == newUser.MailAddress).FirstOrDefault()==true)
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
                    mail.To.Add(newUser.MailAddress);

                    mail.Subject = "IK Platform Projesi, Geçici Şifre Bildirimi";
                    mail.IsBodyHtml = true;
                    //mail.Body = "Merhaba değerli " + platformManager.Name + platformManager.Surname + ", " + Environment.NewLine + "platform yöneticisi olarak atandınız. Bu kapsamda"
                    //    + "Geçiçi şifreniz: " + temporaryPassword + Environment.NewLine + "Lütfen http://ikmanagement.azurewebsites.net linke tıklayarak şifrenizi oluşturunuz";
                    ////Buraya şifre değiştirme ekranı linki eklenecek

                    //sc.Send(mail);
                }
                catch (Exception)
                {
                    throw new Exception("Girmiş olduğunuz mail adresi geçerli değildir"); //Burası tekrar düzenlenecek!!!!!(Gizem)
                }
                newUser.Name = platformManager.Name;
                newUser.MiddleName = platformManager.MiddleName;
                newUser.Surname = platformManager.Surname;
                newUser.Password = temporaryPassword;
                newUser.LatestPassword = temporaryPassword;
                newUser.Address = platformManager.Address;
                newUser.HireDate = platformManager.HireDate;
                newUser.BirthDate = platformManager.BirthDate;
                newUser.PhotoPath = platformManager.PhotoPath;
                _context.PlatformManagers.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction(nameof(PlatformList));

            }
            return View(platformManager);
        }

        [HttpGet]
        [Route("Platform/Home/Details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.ActiveID = int.Parse(HttpContext.Session.GetString("UserID"));
            var platformMgr = _context.PlatformManagers.Find(id);
            return View(platformMgr);
        }

        [Route("Platform/Home/Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var platformMgr = _context.PlatformManagers.Find(id);
            int activeID= int.Parse(HttpContext.Session.GetString("UserID"));
            if (platformMgr.IsAdmin==true||id==activeID )
            {
                return Content("Bu kullancıyı silemezsiniz!!!");
            }
            else
            {
                PlatformMgrAddModel pmModel = new PlatformMgrAddModel();
                pmModel.Name = platformMgr.Name;
                pmModel.ID = platformMgr.ID;
                pmModel.Surname = platformMgr.Surname;
                pmModel.HireDate = platformMgr.HireDate;
                pmModel.PhotoPath= platformMgr.PhotoPath;
                pmModel.MailAddress= platformMgr.MailAddress;
                return View(pmModel);
            }
        }

        [HttpPost]
        public IActionResult Delete(PlatformMgrAddModel pm, int id)
        {
            if (ModelState.IsValid)
            {
                if (pm.TerminationDate != default)
                {
                    var platformMgr = _context.PlatformManagers.Find(id);
                    platformMgr.TerminationDate = pm.TerminationDate;
                    platformMgr.IsActive = false;
                    _context.PlatformManagers.Update(platformMgr);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(PlatformList));
                }
                
            }

            return View(pm);
        }
        //[Route("CompanyManager/Home/Edit/{id}")]
        [HttpGet]
        public IActionResult EditCoMGr(int id)
        {
            var registeredUser = _context.Employees.Find(id);
            VMCoMgr empCoMng = new VMCoMgr();
            empCoMng.EmployeeID = registeredUser.EmployeeID;
            empCoMng.EmployeeName = registeredUser.EmployeeName;
            empCoMng.EmployeeMiddleName = registeredUser.EmployeeMiddleName;
            empCoMng.EmployeeLastName = registeredUser.EmployeeLastName;
            empCoMng.Title = registeredUser.Title;
            empCoMng.Department = registeredUser.Department;
            empCoMng.Title = registeredUser.Title;
            empCoMng.MailAddress = registeredUser.MailAddress;
            empCoMng.BirthDate = registeredUser.BirthDate;
            //empCoMng.HireDate = (DateTime)registeredUser.HireDate; // 01.01.0001 geliyordu
            empCoMng.TerminationDate = registeredUser.TerminationDate;
            empCoMng.PhoneNumber = registeredUser.PhoneNumber;
            empCoMng.HomeAddress = registeredUser.HomeAddress;

            return View(empCoMng);
        }
        //[Route("CompanyManager/Home/Edit/{id}")]
        [HttpPost]
        public IActionResult EditCoMGr(VMCoMgr vMCoMgr, int id)
        {
            if (ModelState.IsValid)
            {
                var registeredUser = _context.Employees.Find(id);

                registeredUser.EmployeeName = vMCoMgr.EmployeeName;
                registeredUser.EmployeeMiddleName = vMCoMgr.EmployeeMiddleName;
                registeredUser.EmployeeLastName = vMCoMgr.EmployeeLastName;
                registeredUser.Department = vMCoMgr.Department;
                registeredUser.Title = vMCoMgr.Title;
                registeredUser.MailAddress = vMCoMgr.MailAddress;
                registeredUser.BirthDate = vMCoMgr.BirthDate;
                registeredUser.HireDate = vMCoMgr.HireDate;
                registeredUser.TerminationDate = vMCoMgr.TerminationDate;
                registeredUser.PhoneNumber = vMCoMgr.PhoneNumber;
                registeredUser.HomeAddress = vMCoMgr.HomeAddress;

                if (vMCoMgr.PhotoFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(vMCoMgr.PhotoFile.FileName);
                    string extension = Path.GetExtension(vMCoMgr.PhotoFile.FileName);

                    vMCoMgr.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        vMCoMgr.PhotoFile.CopyTo(fileStream);
                    }
                }

                registeredUser.PhotoPath = vMCoMgr.PhotoPath;
                ViewBag.CurrentUserID = vMCoMgr.EmployeeID;
                _context.Employees.Update(registeredUser);
                _context.SaveChanges();
                return RedirectToAction("CoMgrList", "Company", new { area = "Platform" });
            }
            return View(vMCoMgr);
        }
        [Route("Platform/Home/CompanyEmployeeDetails/{id}")]
        public IActionResult CompanyEmployeeDetails(int id)
        {
            //ViewBag.ActiveID = int.Parse(HttpContext.Session.GetString("UserID"));
            var coMgr = _context.Employees.Find(id);
            return View(coMgr);
        }
    }
}
