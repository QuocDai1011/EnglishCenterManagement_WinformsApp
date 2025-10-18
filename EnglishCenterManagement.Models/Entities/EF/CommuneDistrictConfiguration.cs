using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class CommuneDistrictConfiguration : IEntityTypeConfiguration<CommuneDistrict>
    {
        public void Configure(EntityTypeBuilder<CommuneDistrict> builder)
        {
            builder.ToTable("commune_district");

            builder.HasKey(c => c.CommuneDistrictId);

            builder.Property(c => c.CommuneDistrictId)
                   .HasColumnName("commune_district_id")
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.ProvinceCityId)
                   .HasColumnName("province_city_id")
                   .IsRequired();

            builder.Property(c => c.CommuneDistrictName)
                   .HasColumnName("commune_district")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255)
                   .IsRequired();
        }
    }
}
