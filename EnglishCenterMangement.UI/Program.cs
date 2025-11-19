using EnglishCenterManagement.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EnglishCenterManagement.Models;
using EnglishCenterManagement.UI.Views;
using EnglishCenterManagement.Models.Entities;
using Microsoft.Data.SqlClient;

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

            // Lấy chuỗi kết nối
            string connectionString = config.GetConnectionString("EnglishCenterDb");

            // Test raw SQL connection first
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    MessageBox.Show("✅ SQL Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"❌ SQL Connection Failed!\n\n" +
                    $"Error Number: {ex.Number}\n" +
                    $"Error Message: {ex.Message}\n\n" +
                    $"Server: {ex.Server}\n" +
                    $"Procedure: {ex.Procedure}\n" +
                    $"Line Number: {ex.LineNumber}",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Unexpected Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Tạo DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<EnglishCenterDbContext>();
            optionsBuilder.UseSqlServer(connectionString);  

            // Kiểm tra kết nối EF Core
            try
            {
                using (var context = new EnglishCenterDbContext(optionsBuilder.Options))
                {
                    bool canConnect = context.Database.CanConnect();
                    if (canConnect)
                    {
                        MessageBox.Show("✅ EF Core connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("❌ EF Core connection failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ EF Core Error: {ex.Message}\n\nInner: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Khởi chạy ứng dụng WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
