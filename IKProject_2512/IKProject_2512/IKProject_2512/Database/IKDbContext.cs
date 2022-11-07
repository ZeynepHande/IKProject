using IKProject_2512.Database.Mapping;
using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProject_2512.Models.SignUpModel;
using IKProject_2512.Areas.Platform.Models;

namespace IKProject_2512.Database
{
    public class IKDbContext : DbContext
    {
        public IKDbContext(DbContextOptions<IKDbContext> options) : base(options)
        { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlatformManagerMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new MembershipMapping());
            modelBuilder.ApplyConfiguration(new CompanyPackageMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());
            modelBuilder.ApplyConfiguration(new MainCompanyMapping());

            //**************TÜM RELATIONSHIP CONFIGURATION BURADA TOPLANDI******************

            //***COMPANY PACKAGE **********

            //COMPANY
            modelBuilder.Entity<CompanyPackage>()
                .HasOne<Company>(ca => ca.Company)
                .WithOne(c => c.CompanyPackage)
                .HasForeignKey<Company>(ca => ca.CompanyPackageID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CompanyPackage>()
                .Navigation(ca => ca.Company).AutoInclude();

            //MEMBERSHIP
            modelBuilder.Entity<CompanyPackage>()
                .HasOne<MembershipPackage>(ca => ca.Package)
                .WithMany(c => c.CompanyPackages)
                .HasForeignKey(ca => ca.PackageID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CompanyPackage>()
                .Navigation(ca => ca.Package).AutoInclude();

            //********EMPLOYEE**********

            //COMPANY
            modelBuilder.Entity<Employee>().
                HasOne<Company>(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyID).OnDelete(DeleteBehavior.NoAction);

            //DEPARTMENT
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.DepartmentID).OnDelete(DeleteBehavior.NoAction);

            //************COMPANY*************

            //PLATFORM MANAGER
            modelBuilder.Entity<Company>()
                .HasOne<PM>(c => c.PlatformManager)
                .WithMany(py => py.Companies).HasForeignKey(c => c.PlatformManagerID).OnDelete(DeleteBehavior.NoAction);

            //MAINCONPANY
            modelBuilder.Entity<Company>()
                .HasOne<MainCompany>(c => c.MainCompany)
                .WithMany(py => py.Subsidaries).HasForeignKey(c => c.MainCompanyID).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PM>().HasData(new
            {
                ID = 1,
                Name = "Gizem",
                Surname = "Akalp",
                MailAddress = "gizemyldz01@gmail.com",
                Password = "Gizem123!",
                BirthDate = Convert.ToDateTime("08/08/1988"),
                HireDate = Convert.ToDateTime("01-01-2021"),
                Address = "Gayrettepe/Beşiktaş",
                IsAdmin = true
            }); ;

            //modelBuilder.Entity<PM>().HasData(new
            //{
            //    ID = 1,
            //    Name = "Kaan",
            //    MiddleName = "Kartal",
            //    Surname="Akdoğan",
            //    MailAddress = "kartalkaanakdogan@hotmail.com",
            //    Password = "Kkaan123!",
            //    BirthDate = Convert.ToDateTime("01/01/2000"),
            //    HireDate = Convert.ToDateTime("01-01-2021"),
            //    Address = "Kadıköy/İstanbul",
            //    IsAdmin = true
            //}); ;

            modelBuilder.Entity<MembershipPackage>().HasData(new
            {
                PackageID = 1,
                PackageName = "Başlangıç",
                PackageMaxCapacity = 150,
                PackageBasePrice = Convert.ToDouble(1000),
                PhotoPath = "badgeBaslangicRev0.png",
                IsActive = true
            }) ;
            modelBuilder.Entity<MembershipPackage>().HasData(new
            {
                PackageID = 2,

                PackageName = "Silver",
                PackageMaxCapacity = 300,
                PackageBasePrice = Convert.ToDouble(3000),
                PhotoPath = "badgeSilverRev0.jfif",
                IsActive = true

            });

            modelBuilder.Entity<MembershipPackage>().HasData(new
            {
                PackageID = 3,

                PackageName = "Gold",
                PackageMaxCapacity = 500,
                PackageBasePrice = Convert.ToDouble(5000),
                IsActive = true,
                PhotoPath = "badgeGoldRev0.png"
            });
            modelBuilder.Entity<MembershipPackage>().HasData(new
            {
                PackageID = 4,
                PackageName = "Bronz",
                PackageMaxCapacity = 2000,
                PackageBasePrice = Convert.ToDouble(8000),
                PhotoPath = "badgeBronzeRev0.jpg",
                IsActive = true

            });

            modelBuilder.Entity<Department>().HasData(new
            {
                ID=1,
                DepartmentName="Bilgi İşlem",
                DepartmentCode="IT",
            });

            modelBuilder.Entity<Department>().HasData(new
            {
                ID = 2,
                DepartmentName = "Finans",
                DepartmentCode = "Fin",
            });

            modelBuilder.Entity<Department>().HasData(new
            {
                ID = 3,
                DepartmentName = "Satış Pazarlama",
                DepartmentCode = "SP",
            });

            modelBuilder.Entity<Department>().HasData(new
            {
                ID = 4,
                DepartmentName = "İnsan Kaynakları",
                DepartmentCode = "HR",
            });

            modelBuilder.Entity<Department>().HasData(new
            {
                ID = 5,
                DepartmentName = "Operasyon",
                DepartmentCode = "Opr",
            });
            modelBuilder.Entity<Department>().HasData(new
            {
                ID = 6,
                DepartmentName = "Yönetim",
                DepartmentCode = "Exe",
            });

            
        }
        

        public virtual DbSet<PM> PlatformManagers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<MembershipPackage> MembershipPackages { get; set; }
        public virtual DbSet<CompanyPackage> CompanyPackages { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<MainCompany> MainCompanies { get; set; }
        public DbSet<IKProject_2512.Models.SignUpModel.SignUpModel> SignUpModel { get; set; }
        public DbSet<IKProject_2512.Areas.Platform.Models.CompanyEmployeeModel> CompanyEmployeeModel { get; set; }
    }

}

