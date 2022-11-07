using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class CompanyPackageMapping : IEntityTypeConfiguration<CompanyPackage>
    {
        public void Configure(EntityTypeBuilder<CompanyPackage> builder)
        {
            builder.HasKey(cp => cp.CompanyPackageID);
            builder.Property(cp => cp.CompanyPackageID).UseIdentityColumn(1, 1).HasColumnName("ŞirketPaketiID");
            builder.Property(cp => cp.PackageID).HasColumnName("ÜyelikPaketID").IsRequired();
            builder.Property(cp => cp.MembershipMonthlyPeriod).HasColumnName("ÜyelikSüresi").HasColumnType("int").IsRequired();
            builder.Property(cp => cp.MembershipPackagePrice).HasColumnName("ÜyelikToplamÜcreti").HasColumnType("float").IsRequired();
            builder.Property(cp => cp.PackageStartDate).HasColumnName("ÜyelikBaşlangıçTarihi").HasColumnType("date").IsRequired();
            builder.Property(cp => cp.PackageRemainingMonths).HasColumnName("PaketinKalanSüresi").IsRequired();

            // MEMBERSHIP && COMPANYPACKAGE MAPPING

            //builder.HasOne<MembershipPackage>(c => c.Package)
            //    .WithMany(py => py.CompanyPackages).HasForeignKey(c => c.PackageID);

        }
    }
}
