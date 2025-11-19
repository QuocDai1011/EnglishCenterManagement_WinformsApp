using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories;
using EnglishCenterManagement.Models.Services;
using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Pages.Classes;
using EnglishCenterMangement.UI.Views.Admin.Pages.Dashboard;
using EnglishCenterMangement.UI.Views.Admin.Pages.Home;
using EnglishCenterMangement.UI.Views.Admin.Pages.Manage;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishCenterMangement.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Load configuration (appsettings.json)
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Build DI container
            var services = new ServiceCollection();

            // --- Đăng ký DbContext ---
            services.AddDbContext<EnglishCenterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb"))
            );

            // --- Đăng ký Repository ---
            services.AddScoped<IClassRepository, ClassRepository>();

            // thêm repo khác…


            // --- Đăng ký Service ---
            services.AddScoped<IClassService,ClassService>();

            // thêm service khác…

            // --- Đăng ký Form / Pages ---
            services.AddTransient<HomeForm>();
            services.AddTransient<ClassesPagePanel>();
            services.AddTransient<DashboardPagePanel>();
            services.AddTransient<ManagePagePanel>();
            services.AddTransient<BasePagePanel>();

            services.AddSingleton<PageFactory>();

            // thêm các page cần dùng…

            // Build provider
            var provider = services.BuildServiceProvider();

            // OPTIONAL: kiểm tra kết nối DB
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EnglishCenterDbContext>();
                if (db.Database.CanConnect())
                    Console.WriteLine("✅ Database connected successfully!");
                else
                    Console.WriteLine("❌ Failed to connect database!");
            }

            // Khởi chạy WinForms
            ApplicationConfiguration.Initialize();
            var homeForm = provider.GetRequiredService<HomeForm>();
            Application.Run(homeForm);
        }
    }
}
