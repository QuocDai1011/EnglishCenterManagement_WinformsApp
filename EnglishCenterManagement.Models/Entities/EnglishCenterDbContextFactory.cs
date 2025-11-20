using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnglishCenterManagement.Models.Entities
{
    public class EnglishCenterDbContextFactory : IDesignTimeDbContextFactory<EnglishCenterDbContext>
    {
        public EnglishCenterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-9N554RA\\SQLEXPRESS;Database=english_center_management_dev;Trusted_Connection=True;TrustServerCertificate=True;");

            return new EnglishCenterDbContext(optionsBuilder.Options);
        }
    }
}
