using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class MembershipMapping : IEntityTypeConfiguration<MembershipPackage>
    {
        public void Configure(EntityTypeBuilder<MembershipPackage> builder)
        {
            builder.HasKey(mp=>mp.PackageID);
            builder.Property(mp=>mp.PackageID).UseIdentityColumn(1, 1).HasColumnName("PaketID").HasColumnType("int");
            builder.Property(mp => mp.PackageName).HasColumnName("PaketAdı").IsRequired(true).HasMaxLength(30);
            //builder.Property(mp => mp.PackageMinCapacity).HasColumnName("MinKapasite").IsRequired(true);
            builder.Property(mp => mp.PackageMaxCapacity).HasColumnName("MaksKapasite").IsRequired(true);
            builder.Property(mp => mp.PackageBasePrice).HasColumnName("PaketAylıkFiyatı").IsRequired(true).HasColumnType("float");
            builder.Property(py => py.PhotoPath).HasColumnName("FotoDosyaYolu").HasMaxLength(255).IsRequired(false).HasDefaultValue("badgeDefaultRev0.png");
            builder.Property(mp => mp.IsActive).HasColumnName("PaketAktifMi").HasColumnType("bit").HasDefaultValue(true).IsRequired();


            //// Employees && Company Mapping
            //builder.HasMany<CompanyPackage>(mc => mc.CompanyPackages).WithOne(c => c.Package);
        }
    }
}
