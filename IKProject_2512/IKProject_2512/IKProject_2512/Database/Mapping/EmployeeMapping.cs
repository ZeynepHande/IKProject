using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee> 
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeID);
            builder.Property(e => e.EmployeeID).UseIdentityColumn(1, 1).HasColumnName("ÇalışanID");
            builder.Property(e => e.PhotoPath).HasColumnName("FotoDosyaYolu").HasMaxLength(255).IsRequired(false).HasDefaultValue("userdefaultfotoRev0.png");
            builder.Property(e => e.IsCompanyManager).HasColumnName("HesapYöneticisiMi").HasColumnType("bit").HasDefaultValue(false).IsRequired();
            builder.Property(e => e.IsActive).HasColumnName("HesapAktifMi").HasColumnType("bit").HasDefaultValue(true).IsRequired();
            builder.Property(e=>e.EmployeeName).HasMaxLength(20).IsUnicode(true).IsRequired().HasColumnName("Adı");
            builder.Property(e=>e.EmployeeMiddleName).HasMaxLength(20).IsUnicode(true).IsRequired(false).HasColumnName("İkinciAdı");
            builder.Property(e=>e.EmployeeLastName).HasMaxLength(50).IsUnicode(true).IsRequired().HasColumnName("Soyadı");
            builder.Property(e=>e.BirthDate).HasColumnName("DoğumTarihi").HasColumnType("date");
            builder.Property(e=>e.HireDate).HasColumnName("İşeGirişTarihi").HasColumnType("date");
            builder.Property(e=>e.TerminationDate).HasColumnName("İştenÇıkışTarihi").HasColumnType("date");
            builder.Property(e => e.Title).HasMaxLength(50).IsRequired(false).HasColumnName("Ünvanı");
            builder.Property(e=>e.MailAddress).HasMaxLength(50).IsRequired(false).HasColumnName("MailAdresi");
            builder.Property(e=>e.PhoneNumber).HasMaxLength(50).IsRequired(false).HasColumnName("İletişimNumarası");
            builder.Property(e=>e.HomeAddress).HasMaxLength(150).IsRequired(false).HasColumnName("İletişimAdresi");
            builder.Property(e => e.Shift).HasColumnType("int").HasColumnName("Vardiya");
            builder.Property(c => c.CompanyID).HasColumnType("int").HasColumnName("ŞirketID");
            builder.Property(e => e.MailExtension).HasColumnName("MailUzantısı").HasMaxLength(100).IsUnicode(true);
            builder.Property(e => e.TimeStamp).HasColumnName("ZamanDamgası").HasColumnType("int").HasDefaultValue(0);
            builder.Property(e => e.Password).HasMaxLength(25).IsUnicode(false).IsRequired().HasColumnName("Parola");
            builder.Property(e => e.LatestPassword).HasMaxLength(25).IsUnicode(false).IsRequired().HasColumnName("YeniParola").HasDefaultValue("user123");



            ////Employees && Company Mapping
            //builder.HasOne<Company>(e => e.Company).WithMany(c => c.Employees).HasForeignKey(e => e.CompanyID);
            //builder.HasOne<Department>(e => e.Department).WithMany(c => c.Employees).HasForeignKey(e => e.DepartmentID);


        }

    }
}
