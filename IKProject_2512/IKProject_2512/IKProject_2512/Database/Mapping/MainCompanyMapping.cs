using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class MainCompanyMapping : IEntityTypeConfiguration<MainCompany>
    {

        public void Configure(EntityTypeBuilder<MainCompany> builder)
        {
            builder.HasKey(mc => mc.MainCompanyID);
            builder.Property(mc => mc.MainCompanyID).UseIdentityColumn(1, 1).HasColumnName("AnaŞirketID");
            builder.Property(mc => mc.MainCompanyName).HasColumnType("nvarchar").HasMaxLength(50).HasColumnName("AnaŞirketAdı");
            builder.Property(mc=>mc.CommercialName).HasColumnType("nvarchar").HasMaxLength(70).HasColumnName("AnaŞirketTicariÜnvan");

            ////Main && Company Mapping
            //builder.HasMany<Company>(mc => mc.Subsidaries).WithOne(c => c.MainCompany);
        }

    }
}
