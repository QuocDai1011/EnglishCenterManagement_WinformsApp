using EnglishCenterManagement.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using EnglishCenterManagement.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using EnglishCenterManagement.UI.Views;
using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.UI.Views.Student;
using EnglishCenterManagement.UI.Views.SystemAcess.Pages.Login;
using EnglishCenterManagement.UI.Views.SystemAcess.Pages.ForgetForm;


namespace EnglishCenterManagement.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Đọc file appsettings.json
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // optional = true
            .Build();

            // Lấy chuỗi kết nối
            string connectionString = config.GetConnectionString("EnglishCenterDb");

            // Tạo DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // (Tuỳ chọn) kiểm tra kết nối
            using (var context = new EnglishCenterDbContext(optionsBuilder.Options))
            {
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("✅ Kết nối cơ sở dữ liệu thành công!");
                }
                else
                {
                    Console.WriteLine("❌ Kết nối cơ sở dữ liệu thất bại!");
                }
            }

            // Khởi chạy ứng dụng WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(connectionString));
        }
    }
}
