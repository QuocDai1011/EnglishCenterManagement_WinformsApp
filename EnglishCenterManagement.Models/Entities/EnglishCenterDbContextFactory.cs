using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnglishCenterManagement.Models.Entities
{
    public class EnglishCenterDbContextFactory : IDesignTimeDbContextFactory<EnglishCenterDbContext>
    {
        public EnglishCenterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-3A6OS2F\\SQLEXPRESS;Database=english_center_management_dev;User Id=sa;Password=123123;TrustServerCertificate=True;");

            return new EnglishCenterDbContext(optionsBuilder.Options);
        }
    }
}
