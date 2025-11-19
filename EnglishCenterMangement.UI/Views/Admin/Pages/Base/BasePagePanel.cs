using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Base
{
    public partial class BasePagePanel : UserControl
    {
        protected Panel contentPanel;

        // THAY ĐỔI: Virtual thay vì abstract - có thể override hoặc không
        public virtual string PageTitle => "Trang";

        public BasePagePanel()
        {
            InitializeComponent();
            SetupPanel();
        }

        private void SetupPanel()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.Transparent;
            this.AutoScroll = true;

            // Main content panel
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                Padding = new Padding(40)
            };
            this.Controls.Add(contentPanel);
        }

        // THAY ĐỔI: Virtual thay vì abstract - có implementation mặc định
        protected virtual void LoadContent()
        {
            // Implementation mặc định - không làm gì cả
            // Các class con có thể override hoặc không
        }

        // Method này được gọi sau khi Designer load xong
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Chỉ load content khi không ở Design Mode
            if (!DesignMode)
            {
                LoadContent();
            }
        }

        protected void AddTitleSection(string title, string description = null)
        {
            // Title
            Label titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 50,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            contentPanel.Controls.Add(titleLabel);

            // Divider
            Panel divider = new Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                BackColor = Color.FromArgb(230, 230, 230)
            };
            contentPanel.Controls.Add(divider);

            // Description
            if (!string.IsNullOrEmpty(description))
            {
                Label descLabel = new Label
                {
                    Text = description,
                    Dock = DockStyle.Top,
                    Height = 50,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.TopLeft
                };
                contentPanel.Controls.Add(descLabel);
            }
        }

        // Helper method để get contentPanel từ Designer
        protected Panel GetContentPanel()
        {
            return contentPanel;
        }
    }

}