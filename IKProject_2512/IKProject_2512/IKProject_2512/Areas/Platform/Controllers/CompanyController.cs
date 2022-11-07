using IKProject_2512.Areas.Platform.Models;
using IKProject_2512.Database;
using IKProject_2512.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace IKProject_2512.Areas.Platform.Controllers
{
    [Area("Platform")]
    public class CompanyController : Controller
    {
        private readonly IKDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(IKDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCompany()
        {
            ViewBag.PackageNames = new SelectList(_context.MembershipPackages.Where(x => x.IsActive == true), "PackageName", "PackageName");
            ViewBag.PlatformManagerID = int.Parse(HttpContext.Session.GetString("UserID"));
            return View(new CompanyEmployeeModel());
        }

        [HttpPost]
        public IActionResult AddCompany(CompanyEmployeeModel model)
        {
            if (ModelState.IsValid)
            {

                MainCompany mainCompany = new MainCompany();
                Company company = new Company();
                CompanyPackage companyPackage = new CompanyPackage();
                MembershipPackage mp = new MembershipPackage();
                //******LOGO KAYIT*************
                if (model.PhotoFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(model.PhotoFile.FileName);
                    string extension = Path.GetExtension(model.PhotoFile.FileName);

                    model.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.PhotoFile.CopyTo(fileStream);
                    }
                }

                //MAIN COMPANY BINDING
                var mainCo = _context.MainCompanies.Where(x => x.MainCompanyName == model.MainCompanyName).FirstOrDefault();

                company.CompanyName = model.CompanyName;
                company.CommercialName = model.CommercialName;
                company.PhoneNumber = model.PhoneNumber;
                company.Address = model.Address;
                //MAIL OLUŞTUR
                var mailText = model.MailExtension.ToLower().Trim().Replace(" ", "").Substring(4);
                company.MailExtension = ProjectMethods.RemoveTurkishChars(mailText);

                if (_context.Companies.Select(x => x.MailExtension == company.MailExtension).FirstOrDefault() == true)
                {
                    if (company.MailExtension=="@bilgeadamboost.com")
                    {
                        return Content("Girilen mail uzantısını kullanamazsınız.");

                    }
                    return Content("Bu mail adresi ve şirket kaydı sistemde mevcuttur, lütfen giriş bilgilerinizi kontrol edin.");
                }
                

                company.Logo = model.PhotoPath;

                if (company.PersonelNumber != null)
                    company.PersonelNumber++;
                else
                    company.PersonelNumber = 1;

                if (mainCo != null)
                {
                    company.MainCompany = mainCo;
                    company.MainCompanyID = mainCo.MainCompanyID;
                }
                if (mainCo == null)
                {
                    mainCompany.MainCompanyName = model.MainCompanyName;
                    _context.MainCompanies.Add(mainCompany);
                    _context.Companies.Add(company);
                    _context.SaveChanges();
                    company.MainCompany = mainCompany;
                    company.MainCompanyID = mainCompany.MainCompanyID;
                }

                Employee employee = new Employee() { EmployeeName = model.EmployeeName, EmployeeMiddleName = model.EmployeeMiddleName, EmployeeLastName = model.EmployeeLastName, /*HireDate = model.HireDate,*/ IsActive = true, IsCompanyManager = true, Company = company, CompanyID = company.CompanyID, MailExtension = company.MailExtension };

                if (model.EmployeeMiddleName == null)
                {
                    employee.MailAddress = ProjectMethods.RemoveTurkishChars(employee.EmployeeName.ToLower().Trim().Replace(" ", "")) + "." + ProjectMethods.RemoveTurkishChars(employee.EmployeeLastName.ToLower().Trim().Replace(" ", "")) + employee.MailExtension;
                }
                else
                {
                    employee.MailAddress = ProjectMethods.RemoveTurkishChars(employee.EmployeeName.ToLower().Trim().Replace(" ", "")) + ProjectMethods.RemoveTurkishChars(employee.EmployeeMiddleName.ToLower().Trim().Replace(" ", "")) + "." + ProjectMethods.RemoveTurkishChars(employee.EmployeeLastName.ToLower().Trim().Replace(" ", "")) + employee.MailExtension;
                }
                if (_context.PlatformManagers.Select(x => x.MailAddress == employee.MailAddress).FirstOrDefault() == true)
                {
                    return Content("Kaydetmeye çalıştığınız kişi şirket yöneticisi olamaz (Platformda kayıtlıdır).");
                }
                if (_context.Employees.Select(x => x.MailAddress == employee.MailAddress).FirstOrDefault() == true)
                {
                    return Content("Kaydetmeye çalıştığınız kişi başka bir şirkete kayıtlıdır.Lütfen bilgileri kontrol edin. .");
                }
                employee.Password = ProjectMethods.NewPasswordComposition();
                employee.LatestPassword = "user123!";
                _context.Employees.Add(employee);
                company.Employees = new List<Employee>() { employee };
                employee.Company = company;
                _context.SaveChanges();

                mp = _context.MembershipPackages.Where(x => x.PackageName == model.PackageName).FirstOrDefault();
                company.JokerValue = mp.PackageID;
                companyPackage.Package = mp;
                companyPackage.PackageID = mp.PackageID;
                company.CompanyPackage = companyPackage;
                _context.CompanyPackages.Add(companyPackage);
                _context.SaveChanges();
                companyPackage.Company = company;
                company.CompanyPackageID = companyPackage.CompanyPackageID;
                _context.SaveChanges();
                companyPackage.MembershipMonthlyPeriod = model.PackagePeriod;
                companyPackage.PackageStartDate = model.PackageStartDate;
                mp.CompanyPackages = new List<CompanyPackage>() { companyPackage };

                _context.SaveChanges();

                company.PlatformManagerID = int.Parse(HttpContext.Session.GetString("UserID"));

                _context.SaveChanges();
                return RedirectToAction("CompanyList", "Company", new { area = "Platform" });
            }
            ViewBag.PackageNames = new SelectList(_context.MembershipPackages, "PackageName", "PackageName");
            return View(model);
        }

        [HttpGet]
        public IActionResult CompanyList()
        {
            var coList = _context.Companies.ToList();
            var Employees = _context.Employees.ToList();

            return View(coList);
        }
        [Route("Platform/Company/Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> CompanyDetails(int id)
        {
            var selectedCo = await _context.Companies.FindAsync(id);
            CompanyEmployeeModel cem = new CompanyEmployeeModel();
            cem.CompanyName = selectedCo.CompanyName;
            cem.CommercialName = selectedCo.CommercialName;
            cem.PhoneNumber = selectedCo.PhoneNumber;
            cem.Address = selectedCo.Address;
            cem.MailExtension = selectedCo.MailExtension;
            cem.PhotoPath = selectedCo.Logo;
            cem.MainCompanyName = _context.MainCompanies.Where(x => x.MainCompanyID == selectedCo.MainCompanyID).FirstOrDefault().MainCompanyName;
            cem.EmployeeName = _context.Employees.Where(x => x.CompanyID == id && x.IsCompanyManager == true).FirstOrDefault().EmployeeName;
            cem.EmployeeLastName = _context.Employees.Where(x => x.CompanyID == id && x.IsCompanyManager == true).FirstOrDefault().EmployeeLastName;
            //cem.HireDate = _context.Employees.Where(x => x.CompanyID == id && x.IsCompanyManager == true).FirstOrDefault().HireDate;


            cem.PackageName = _context.MembershipPackages.Where(x => x.PackageID == selectedCo.JokerValue).FirstOrDefault().PackageName;

            var member = _context.MembershipPackages.Find(selectedCo.JokerValue);

            var companyPackage = _context.CompanyPackages.Where(x => x.PackageID == selectedCo.JokerValue).ToList().Where(x => x.Company.CompanyID == selectedCo.CompanyID).FirstOrDefault();

            cem.PackagePeriod = companyPackage.MembershipMonthlyPeriod;
            cem.PackageStartDate = companyPackage.PackageStartDate;

            return View(cem);
        }

        [Route("Platform/Company/Edit/{id}")]
        [HttpGet]
        public IActionResult EditCompany(int id)
        {
            var registeredUser = _context.Companies.Find(id);
            Company companyEdit = new Company();
            companyEdit.CompanyID = registeredUser.CompanyID;
            companyEdit.CompanyName = registeredUser.CompanyName;
            companyEdit.CommercialName = registeredUser.CommercialName;
            companyEdit.PhoneNumber = registeredUser.PhoneNumber;
            companyEdit.Address = registeredUser.Address;
            //companyEdit.MainCompanyName = registeredUser.MainCompanyName;
            companyEdit.MailExtension = registeredUser.MailExtension;
            return View(companyEdit);
        }

        [Route("Platform/Company/Edit/{id}")]
        [HttpPost]
        public IActionResult EditCompany(Company companyEdit, int id)
        {
            if (ModelState.IsValid)
            {
                var registeredUser = _context.Companies.Find(id);
                registeredUser.CompanyName = companyEdit.CompanyName;
                registeredUser.CommercialName = companyEdit.CommercialName;
                registeredUser.PhoneNumber = companyEdit.PhoneNumber;
                registeredUser.Address = companyEdit.Address;
                //registeredUser.MainCompanyName = companyEdit.MainCompanyName;
               registeredUser.MailExtension = companyEdit.MailExtension;

                //if (companyEdit.PhotoFile != null)
                //{
                //    string wwwRootPath = _hostEnvironment.WebRootPath;
                //    string fileName = Path.GetFileNameWithoutExtension(companyEdit.PhotoFile.FileName);
                //    string extension = Path.GetExtension(companyEdit.PhotoFile.FileName);

                //    companyEdit.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //    string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
                //    using (var fileStream = new FileStream(path, FileMode.Create))
                //    {
                //        companyEdit.PhotoFile.CopyTo(fileStream);
                //    }
                //}
                //registeredUser.PhotoPath = companyEdit.PhotoPath;
                ViewBag.CurrentUserID = companyEdit.CompanyID;
                _context.Companies.Update(registeredUser);
                _context.SaveChanges();
                return RedirectToAction("CompanyList", "Company", new { area = "Platform" });
            }
            return View(companyEdit);
        }
        [HttpGet]
        public IActionResult CoMgrList()
        {
            List<Employee> CoMgrs = new List<Employee>();
            CoMgrs = _context.Employees.Where(x => x.IsActive == true && x.IsCompanyManager == true).ToList();
            ViewBag.CompanyNames = new SelectList(_context.Companies, "CompanyID", "CompanyName");
            return View(CoMgrs);
        }
        public async Task<IActionResult> DeleteCoMGr(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // yalnızca aktif hesap alanı pasife çekilecek.
        [HttpPost, ActionName("DeleteCoMGr")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCoMGrConfirmed(int id)
        {
            var coMgrEmpId = await _context.Employees.FindAsync(id);
            var companyId = coMgrEmpId.CompanyID; //doluyor
            var relatedCompany = _context.Companies.Find(companyId);

            var companyMgCount = Convert.ToInt32(_context.Employees.Where(x => x.CompanyID == companyId).Count(x => x.IsCompanyManager).ToString()); //doluyor

            if (coMgrEmpId.IsCompanyManager == true && companyMgCount >= 1)
            {
                coMgrEmpId.IsActive = false;
                _context.SaveChanges();

                var activeEmployeeCount = Convert.ToInt32(_context.Employees.Where(x => x.CompanyID == companyId).Count(x => x.IsActive).ToString());

                _context.Update(coMgrEmpId);
                await _context.SaveChangesAsync();

                if (activeEmployeeCount >= 1 && coMgrEmpId.IsCompanyManager == false)
                {
                    return Content("Silmeye çalıştığınız personel şirket yöneticisi olmadığı için bu listeden müdahale edemezsiniz. ");

                }
                if (activeEmployeeCount == 0 && coMgrEmpId.IsCompanyManager == true)
                {
                    relatedCompany.IsActive = false;
                }

                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(PassiveCoMgrList));

        }

        [HttpGet]
        public IActionResult PassiveCoMgrList()
        {
            List<Employee> PassiveCoMgrs = new List<Employee>();
            PassiveCoMgrs = _context.Employees.Where(x => x.IsActive == false && x.IsCompanyManager == true).ToList();
            ViewBag.CompanyNames = new SelectList(_context.Companies, "CompanyID", "CompanyName");
            return View(PassiveCoMgrs);
        }
        public async Task<IActionResult> MakeActiveCoMGr(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // yalnızca pasif hesap alanı aktife çekilecek.
        [HttpPost, ActionName("MakeActiveCoMGr")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeActiveCoMGrConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            employee.IsActive = true;
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CoMgrList));
        }

    }
}
