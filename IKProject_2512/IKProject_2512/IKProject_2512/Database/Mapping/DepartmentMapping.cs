using IKProject_2512.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Database.Mapping
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.ID);
            builder.Property(e => e.ID).UseIdentityColumn(1, 1).HasColumnName("DepartmanID");
            builder.Property(e => e.DepartmentCode).HasColumnType("nvarchar").HasMaxLength(15).HasColumnName("DepartmanKodu").IsRequired();
            builder.Property(e => e.DepartmentName).HasColumnType("nvarchar").HasMaxLength(30).HasColumnName("DepartmanAdı").IsRequired();
            builder.Property(e=>e.Notes).HasColumnType("nvarchar").HasMaxLength(30).HasColumnName("Notlar");

            //builder.HasMany<Employee>(d => d.Employees).WithOne(e => e.Department);
        }
    }
}
