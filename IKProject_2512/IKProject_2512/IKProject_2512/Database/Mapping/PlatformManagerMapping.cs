using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class PlatformManagerMapping : IEntityTypeConfiguration<PM>
    {
        public void Configure(EntityTypeBuilder<PM> builder)
        {
            builder.HasKey(py => py.ID );
            builder.Property(py => py.ID).UseIdentityColumn(1, 1);
            builder.Property(py => py.MailAddress).HasColumnName("MailAdresi").IsRequired(false);
            builder.HasIndex(py => py.MailAddress).IsUnique().HasDatabaseName("INDX_PY_Mail");
            builder.Property(py => py.Password).HasMaxLength(25).IsUnicode(false).IsRequired().HasColumnName("Parola");
            builder.Property(py => py.LatestPassword).HasMaxLength(25).IsUnicode(false).IsRequired().HasColumnName("YeniParola").HasDefaultValue("user123");
            builder.Property(py => py.Name).HasMaxLength(20).IsUnicode(true).IsRequired().HasColumnName("Adı");
            builder.Property(py => py.MiddleName).HasMaxLength(20).IsUnicode(true).IsRequired(false).HasColumnName("İkinciAdı");
            builder.Property(py => py.Surname).HasMaxLength(25).IsUnicode(true).IsRequired().HasColumnName("Soyadı");
            builder.Property(py => py.BirthDate).HasColumnType("date").HasColumnName("DoğumTarihi");
            builder.Property(py => py.HireDate).HasColumnName("İşeGirişTarihi").HasColumnType("date");
            builder.Property(py => py.TerminationDate).HasColumnName("İştenÇıkışTarihi").HasColumnType("date");
            builder.Property(py => py.PhotoPath).HasColumnName("FotoDosyaYolu").HasMaxLength(255).IsRequired(false).HasDefaultValue("userdefaultfotoRev0.png");
            builder.Property(py => py.Address).HasColumnName("AdresBilgileri").HasMaxLength(100).IsUnicode(true).IsRequired(false);
            builder.Property(py => py.MailExtension).HasColumnName("MailUzantısı").HasMaxLength(100).IsUnicode(true).HasDefaultValue("@bilgeadamboost.com");
            builder.Property(py => py.TimeStamp).HasColumnName("ZamanDamgası").HasColumnType("int").HasDefaultValue(0);
            builder.Property(py => py.IsActive).HasColumnName("HesapAktifMi").HasColumnType("bit").HasDefaultValue(true).IsRequired();
            builder.Property(py => py.IsAdmin).HasColumnName("HesapAdminMi").HasColumnType("bit").HasDefaultValue(false).IsRequired();

            ////PlatformManager && Company Mapping

            //builder.HasMany<Company>(pm => pm.Companies)
            //    .WithOne(c => c.PlatformManager);


        }
    }
}
