using EnglishCenterManagement.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using EnglishCenterManagement.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using EnglishCenterManagement.UI.Views;
using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.UI.Views.StudentDai;
using EnglishCenterManagement.Models.Services;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using EnglishCenterManagement.Models.Repositories.Implementations;
using EnglishCenterManagement.Models.Services.Interfaces;
using EnglishCenterManagement.Models.Services.Implementations;

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
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            // --- Đăng ký DbContext ---
            services.AddDbContext<EnglishCenterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb"))
            );


            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IClassService, ClassService>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<ServiceHub>();

            services.AddTransient<teacherForm>();

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
            Application.Run(new StudentFrom());
        }
    }
}
