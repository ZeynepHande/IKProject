using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.CompanyID);
            builder.Property(c => c.CompanyID).UseIdentityColumn(1, 1);
            builder.Property(c => c.CompanyName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired().HasColumnName("ŞirketAdı");
            builder.HasIndex(c => c.CompanyName).IsUnique().HasDatabaseName("INDX_Company_Name");
            builder.Property(c => c.CommercialName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired().HasColumnName("ŞirketÜnvanı");
            builder.Property(c => c.PersonelNumber).HasColumnName("ÇalışanSayısı");
            builder.Property(c => c.PhoneNumber).HasColumnName("ŞirketTelefonu").HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(100).HasColumnType("nvarchar").HasColumnName("ŞirketAdresi").IsRequired(false);
            builder.Property(c => c.MainCompanyID).HasColumnType("int").HasColumnName("AnaŞirketID");
            builder.Property(c => c.PlatformManagerID).HasColumnType("int").HasColumnName("PlatformYöneticisiID");
            builder.Property(c => c.Logo).HasColumnType("nvarchar").IsRequired(false).HasColumnName("Logo").HasMaxLength(255).HasDefaultValue("defaultCompanyRev0.jfif");
            builder.Property(c=>c.MailExtension).HasColumnName("MailUzantısı").HasMaxLength(100).IsUnicode(true);
            builder.Property(c=>c.IsActive).HasColumnName("ŞirketAktifMi").HasColumnType("bit").HasDefaultValue(true).IsRequired();
            builder.Property(c => c.JokerValue).HasColumnType("int").HasColumnName("PaketKayıtNo");

            ////PlatformManager && Company Mapping

            //builder.HasOne<PM>(c => c.PlatformManager)
            //    .WithMany(py => py.Companies).HasForeignKey(c => c.PlatformManagerID);

            ////Employees && Company Mapping
            //builder.HasMany<Employee>(c => c.Employees).WithOne(e => e.Company);

            //// Company && Main Company Mapping

            //builder.HasOne<MainCompany>(c => c.MainCompany)
            //   .WithMany(py => py.Subsidaries).HasForeignKey(c => c.MainCompanyID);
        }
    }
}
