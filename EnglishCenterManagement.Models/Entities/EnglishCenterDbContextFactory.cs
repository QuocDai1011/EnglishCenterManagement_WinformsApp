using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnglishCenterManagement.Models.Entities
{
    public class EnglishCenterDbContextFactory : IDesignTimeDbContextFactory<EnglishCenterDbContext>
    {
        public EnglishCenterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1431;Database=english_center_management_dev;User Id=sa;Password=Abc@12345XyZ;TrustServerCertificate=True;");

            return new EnglishCenterDbContext(optionsBuilder.Options);
        }
    }
}
