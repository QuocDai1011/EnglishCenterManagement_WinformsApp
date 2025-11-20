using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.ToTable("expertise");

            builder.HasKey(e => e.ExpertiseId);
            builder.Property(e => e.ExpertiseId).ValueGeneratedOnAdd();

            builder.Property(e => e.ExpertiseName)
                .IsRequired()
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .HasColumnName("expertise_name");

            builder.HasMany(e => e.ExpertiseTeachers)
                .WithOne(e => e.Expertise)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.ExpertiseID);
        }
    }
}
