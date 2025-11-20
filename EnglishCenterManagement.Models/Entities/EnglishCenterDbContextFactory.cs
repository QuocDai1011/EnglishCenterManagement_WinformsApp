using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnglishCenterManagement.Models.Entities
{
    public class EnglishCenterDbContextFactory : IDesignTimeDbContextFactory<EnglishCenterDbContext>
    {
        public EnglishCenterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-3A6OS2F\\SQLEXPRESS;Database=EnglishCenterManagementDev;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

            return new EnglishCenterDbContext(optionsBuilder.Options);
        }
    }
}
