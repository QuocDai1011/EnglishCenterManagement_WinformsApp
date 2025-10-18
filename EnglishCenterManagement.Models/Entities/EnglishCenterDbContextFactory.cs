using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnglishCenterManagement.Models.Entities
{
    public class EnglishCenterDbContextFactory : IDesignTimeDbContextFactory<EnglishCenterDbContext>
    {
        public EnglishCenterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1444;Database=english_center_management_dev;User Id=english_center_manager;Password=Abc1234@;TrustServerCertificate=True;");

            return new EnglishCenterDbContext(optionsBuilder.Options);
        }
    }
}
