using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ProvinceCityConfiguration : IEntityTypeConfiguration<ProvinceCity>
    {
        public void Configure(EntityTypeBuilder<ProvinceCity> builder)
        {
            builder.ToTable("province_city");

            builder.HasKey(p => p.ProvinceCityId);

            builder.Property(p => p.ProvinceCityId)
                   .HasColumnName("province_city_id")
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.ProvinceCityName)
                   .HasColumnName("province_city_name")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255)
                   .IsRequired();

            // 1-n relationship
            builder.HasMany(p => p.CommuneDistricts)
                   .WithOne(c => c.ProvinceCity)
                   .HasForeignKey(c => c.ProvinceCityId);
        }
    }
}
