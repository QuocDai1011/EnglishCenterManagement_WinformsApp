using EnglishCenterMangement.UI.Views.Admin.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Components.Sidebar
{
    public partial class SidebarControl : UserControl
    {
        public event EventHandler<string> OnMenuItemClick;
        private Panel scrollPanel;

        private readonly (string iconPath, string text, string action)[] menuItems = new[]
        {
            ("manage_icon", "Quản Lý", "manage"),
            ("dashboard_icon", "Dashboard", "dashboard"),
            ("classes_icon", "Lớp học của tôi", "classes"),
            ("", "Lối tắt của bạn", "shortcuts-header"),
            ("calendar_icon", "Lịch cá nhân", "calendar"),
            ("invoice_icon", "Hóa đơn", "invoices"),
        };


        public SidebarControl()
        {
            InitializeComponent();
            this.Width = 280; // Chiều rộng cố định cho sidebar
            SetupSidebar();
        }

        private void SetupSidebar()
        {
            // Main container
            this.BackColor = Color.White;
            this.Dock = DockStyle.Left;

            // Panel có scroll
            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(10, 15, 10, 15)
            };

            int yPosition = 10;

            foreach (var item in menuItems)
            {
                if (item.action == "shortcuts-header")
                {
                    // Header "Lối tắt của bạn"
                    Label headerLabel = new Label
                    {
                        Text = item.text,
                        Location = new Point(15, yPosition),
                        Size = new Size(250, 30),
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.Gray,
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    scrollPanel.Controls.Add(headerLabel);
                    yPosition += 40;
                }
                else
                {
                    Panel menuItem = CreateMenuItem(item.iconPath, item.text, item.action, yPosition);
                    scrollPanel.Controls.Add(menuItem);
                    yPosition += 60;
                }
            }

            this.Controls.Add(scrollPanel);
        }

        private Panel CreateMenuItem(string iconPath, string text, string action, int yPosition)
        {
            Panel itemPanel = new Panel
            {
                Location = new Point(5, yPosition),
                Size = new Size(280, 50),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Icon container với PictureBox
            Panel iconContainer = new Panel
            {
                Location = new Point(8, 8),
                Size = new Size(45, 45),
            };
            UIHelper.MakeRounded(iconContainer, 10);

            // PictureBox thay vì Label
            PictureBox iconPicture = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(7, 2),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            // Load icon từ resources (bạn cần thêm các icon vào Resources)
            try
            {
                // Giả sử bạn có các icon trong Resources
                switch (action)
                {
                    case "manage":
                        iconPicture.Image = Properties.Resources.logo2019_png_1; // Thay bằng icon thực tế
                        break;
                    case "dashboard":
                        iconPicture.Image = Properties.Resources.logo2019_png_1;
                        break;
                    case "classes":
                        iconPicture.Image = Properties.Resources.myClass;
                        break;
                    case "calendar":
                        iconPicture.Image = Properties.Resources.myCalender;
                        break;
                    case "invoices":
                        iconPicture.Image = Properties.Resources.Receipt;
                        break;
                    default:
                        // Tạo icon placeholder nếu không có
                        Bitmap placeholder = new Bitmap(24, 24);
                        using (Graphics g = Graphics.FromImage(placeholder))
                        {
                            g.Clear(Color.Gray);
                        }
                        iconPicture.Image = placeholder;
                        break;
                }
            }
            catch
            {
                // Fallback: tạo icon màu đơn giản
                Bitmap fallback = new Bitmap(24, 24);
                using (Graphics g = Graphics.FromImage(fallback))
                {
                    g.Clear(Color.Gray);
                }
                iconPicture.Image = fallback;
            }

            iconContainer.Controls.Add(iconPicture);

            // Text label
            Label textLabel = new Label
            {
                Text = text,
                Location = new Point(60, 15),
                Size = new Size(195, 20),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(50, 50, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };

            itemPanel.Controls.Add(iconContainer);
            itemPanel.Controls.Add(textLabel);

            // Hover effect
            UIHelper.AddHoverEffect(itemPanel, Color.FromArgb(245, 245, 245), Color.White);
            UIHelper.MakeRounded(itemPanel, 10);

            // Click events cho tất cả controls
            itemPanel.Click += (s, e) => OnMenuItemClick?.Invoke(this, action);
            iconContainer.Click += (s, e) => OnMenuItemClick?.Invoke(this, action);
            iconPicture.Click += (s, e) => OnMenuItemClick?.Invoke(this, action);
            textLabel.Click += (s, e) => OnMenuItemClick?.Invoke(this, action);

            return itemPanel;
        }
    }
}