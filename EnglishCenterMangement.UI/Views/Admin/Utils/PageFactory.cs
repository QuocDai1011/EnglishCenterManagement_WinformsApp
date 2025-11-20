using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories;
using EnglishCenterManagement.Models.Services;
using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Pages.Classes;
using EnglishCenterMangement.UI.Views.Admin.Pages.Dashboard;
using EnglishCenterMangement.UI.Views.Admin.Pages.Manage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EnglishCenterMangement.UI.Views.Admin.Utils
{
    public class PageFactory
    {
        private readonly IServiceProvider _provider;

        public PageFactory(IServiceProvider provider)
        {
            _provider = provider; 
        }
        public  BasePagePanel CreatePage(string action)
        {
            return action switch
            {
                "manage" => _provider.GetRequiredService<ManagePagePanel>(),
                "dashboard" => _provider.GetRequiredService<DashboardPagePanel>(),
                "classes" => _provider.GetRequiredService<ClassesPagePanel>(),
                //"calendar" => _provider.GetRequiredService<CalendarPagePanel>(),
                //"invoices" => _provider.GetRequiredService<InvoicesPagePanel>(),
                _ => _provider.GetRequiredService<DashboardPagePanel>()
            };
        }


        public static string GetPageTitle(string action)
        {
            return action switch
            {
                "manage" => "Quản Lý",
                "dashboard" => "Dashboard",
                "classes" => "Lớp học của tôi",
                "calendar" => "Lịch cá nhân",
                "invoices" => "Hóa đơn",
                _ => "Trang chủ"
            };
        }

    }

    // Placeholder pages - bạn có thể tạo các file tương tự như ManagePagePanel
    public class CalendarPagePanel : BasePagePanel
    {
        public override string PageTitle => "Lịch cá nhân";

        protected override void LoadContent()
        {
            AddTitleSection(
                "Lịch cá nhân",
                "Quản lý lịch trình và sự kiện của bạn."
            );

            Label placeholderLabel = new Label
            {
                Text = "Nội dung trang Lịch cá nhân đang được phát triển...",
                Location = new Point(0, 150),
                Size = new Size(contentPanel.Width - 80, 100),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(placeholderLabel);
        }
    }

    public class InvoicesPagePanel : BasePagePanel
    {
        public override string PageTitle => "Hóa đơn";

        protected override void LoadContent()
        {
            AddTitleSection(
                "Hóa đơn",
                "Quản lý các hóa đơn và thanh toán."
            );

            Label placeholderLabel = new Label
            {
                Text = "Nội dung trang Hóa đơn đang được phát triển...",
                Location = new Point(0, 150),
                Size = new Size(contentPanel.Width - 80, 100),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(placeholderLabel);
        }
    }
}