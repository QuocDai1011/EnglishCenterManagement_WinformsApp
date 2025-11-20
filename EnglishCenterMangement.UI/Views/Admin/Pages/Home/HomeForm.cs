using EnglishCenterManagement.Models.Services;
using EnglishCenterManagement.UI.Views.Admin.Pages.Classes;
using EnglishCenterMangement.UI.Views.Admin.Components.Header;
using EnglishCenterMangement.UI.Views.Admin.Components.Sidebar;
using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Home
{
    public partial class HomeForm : Form
    {
        private HeaderControl headerControl;
        private SidebarControl sidebarControl;
        private Panel mainContentPanel;
        private Panel containerPanel;
        private readonly PageFactory _pageFactory;
        private readonly ServiceHub _serviceHub;
        public HomeForm(PageFactory pageFactory, ServiceHub serviceHub)
        {
            InitializeComponent();
            SetupForm();
            CreateComponents();
            _pageFactory = pageFactory;
            _serviceHub = serviceHub;
        }

        private void SetupForm()
        {
            this.Padding = new Padding(0);
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.WindowState = FormWindowState.Maximized;
        }

        private void CreateComponents()
        {
            // Header - Chiếm toàn bộ chiều ngang ở trên cùng, cố định 70px
            headerControl = new HeaderControl
            {
                Dock = DockStyle.Top,
                Height = 80
            };
            headerControl.OnMenuItemClick += HeaderMenuClick;
            this.Controls.Add(headerControl);

            // Container Panel - Chứa Sidebar và Main Content, nằm dưới header
            containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 242, 245),
                Padding = new Padding(0, 60, 0, 0),
            };
            this.Controls.Add(containerPanel);

            // Sidebar - Cố định bên trái, chiều rộng 280px
            sidebarControl = new SidebarControl
            {
                Dock = DockStyle.Left,
                Width = 300,
                Padding = new Padding(0, 20, 0, 0)
            };
            sidebarControl.OnMenuItemClick += SidebarControl_OnMenuItemClick;
            containerPanel.Controls.Add(sidebarControl);

            // Main Content Panel - Fill phần còn lại
            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 242, 245),
                Padding = new Padding(20),
                AutoScroll = true
            };
            containerPanel.Controls.Add(mainContentPanel);

            // Load trang mặc định
            LoadDefaultContent();
        }

        private void LoadDefaultContent()
        {
            mainContentPanel.Controls.Clear();

            // Container chính giữa với chiều rộng lớn hơn
            Panel centerPanel = new Panel
            {
                BackColor = Color.White,
                AutoScroll = true
            };

            // Hàm cập nhật layout khi resize
            void UpdateCenterPanelLayout()
            {
                int maxWidth = 1580; // Tăng từ 800 lên 1580
                int availableWidth = mainContentPanel.ClientSize.Width - 40; // trừ padding 40 mỗi bên
                int width = Math.Min(maxWidth, availableWidth);

                centerPanel.Width = width;
                centerPanel.Height = mainContentPanel.ClientSize.Height - 80; // padding 40 trên dưới
                centerPanel.Location = new Point((mainContentPanel.ClientSize.Width - width) / 2 + 160, 40);
            }

            mainContentPanel.Controls.Add(centerPanel);
            mainContentPanel.Resize += (s, e) => UpdateCenterPanelLayout();
            UpdateCenterPanelLayout();

            UIHelper.MakeRounded(centerPanel, 12);

            // Logo avatar
            PictureBox avatarLogo = new PictureBox
            {
                Location = new Point(30, 30),
                Size = new Size(60, 60),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.logo2019_png_1
            };
            UIHelper.MakeRounded(avatarLogo, 25);
            centerPanel.Controls.Add(avatarLogo);

            // Panel tạo bài viết
            Panel createPostPanel = new Panel
            {
                Location = new Point(95, 30),
                Size = new Size(centerPanel.Width - 135, 50),
                BackColor = Color.FromArgb(240, 242, 245),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            UIHelper.MakeRounded(createPostPanel, 25);

            Label createPostLabel = new Label
            {
                Text = "Tạo bài viết",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                Padding = new Padding(20, 0, 0, 0)
            };
            createPostPanel.Controls.Add(createPostLabel);

            UIHelper.AddHoverEffect(createPostPanel, Color.FromArgb(220, 222, 225), Color.FromArgb(240, 242, 245));
            createPostPanel.Click += (s, e) => MessageBox.Show("Tạo bài viết mới");
            createPostLabel.Click += (s, e) => MessageBox.Show("Tạo bài viết mới");

            centerPanel.Controls.Add(createPostPanel);

            // Divider line
            Panel dividerLine = new Panel
            {
                Location = new Point(30, 100),
                Size = new Size(centerPanel.Width - 60, 1),
                BackColor = Color.FromArgb(220, 220, 220),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            centerPanel.Controls.Add(dividerLine);

            // Button Ảnh/video
            Button mediaBtn = new Button
            {
                Text = "📷 Ảnh/video",
                Location = new Point(500, 120),
                Size = new Size(centerPanel.Width - 900, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            mediaBtn.FlatAppearance.BorderSize = 0;
            UIHelper.AddHoverEffect(mediaBtn, Color.FromArgb(245, 245, 245), Color.White);
            UIHelper.MakeRounded(mediaBtn, 25);

            centerPanel.Controls.Add(mediaBtn);

            // Sample posts
            int yPos = 195;
            for (int i = 0; i < 3; i++)
            {
                Panel postPanel = new Panel
                {
                    Location = new Point(30, yPos),
                    Size = new Size(centerPanel.Width - 60, 150),
                    BackColor = Color.FromArgb(248, 249, 250),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                UIHelper.MakeRounded(postPanel, 10);

                Label postTitle = new Label
                {
                    Text = $"Bài viết mẫu {i + 1}",
                    Location = new Point(20, 20),
                    Size = new Size(postPanel.Width - 40, 25),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                postPanel.Controls.Add(postTitle);

                Label postContent = new Label
                {
                    Text = "Đây là nội dung mẫu của bài viết. Nội dung sẽ được hiển thị ở đây...",
                    Location = new Point(20, 55),
                    Size = new Size(postPanel.Width - 40, 80),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray
                };
                postPanel.Controls.Add(postContent);

                centerPanel.Controls.Add(postPanel);
                yPos += 170;
            }

            // Resize handler cho các controls bên trong centerPanel
            centerPanel.Resize += (s, e) =>
            {
                createPostPanel.Width = centerPanel.Width - 135;
                dividerLine.Width = centerPanel.Width - 60;
                mediaBtn.Width = centerPanel.Width - 60;
            };
        }

        private void HeaderMenuClick(object sender, string action)
        {
            // action = "profile:Hồ sơ"
            // action = "menu:Thêm sinh viên"
            // action = "create:Tạo bài viết"

            MessageBox.Show("Bạn vừa chọn: " + action);

            // Tách category và item nếu cần
            var parts = action.Split(':');
            string category = parts[0];
            string item = parts[1];

            switch (category)
            {
                case "profile":
                    if (item == "Đăng xuất")
                        Logout();
                    else if (item == "Hồ sơ")
                        OpenProfile();
                    break;

                case "menu":
                    if (item == "Thêm sinh viên")
                        OpenAddStudent();
                    break;
            }
        }

        private void OpenAddStudent()
        {
            var addForm = new StudentAddEditForm(_serviceHub);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Thêm sinh viên thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Logout()
        {
            MessageBox.Show("Đăng xuất thành công!", "Đăng xuất");
        }

        private void OpenProfile()
        {
            MessageBox.Show("Mở trang hồ sơ cá nhân", "Hồ sơ");
        }

        private void SidebarControl_OnMenuItemClick(object sender, string action)
        {
            mainContentPanel.Controls.Clear();
            //MessageBox.Show($"Sidebar clicked: {action}", "Sidebar Action");
            // Tạo wrapper panel để chứa page và căn giữa
            Panel wrapperPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false,
                Width = mainContentPanel.Width - 40,
                Height = mainContentPanel.Height,
            };

            // Tạo page từ factory
            BasePagePanel page = _pageFactory.CreatePage(action);
            page.Dock = DockStyle.Right;
            void UpdatePageLayout()
            {
                int maxWidth = 1580;
                int availableWidth = wrapperPanel.ClientSize.Width - 80;
                int width = Math.Min(maxWidth, availableWidth);

                page.Width = width;
                page.Height = wrapperPanel.ClientSize.Height - 80;
                page.Location = new Point((wrapperPanel.ClientSize.Width - width) / 2 + 160, 40);
                page.Visible = true;
            }

            wrapperPanel.Controls.Add(page);
            wrapperPanel.Resize += (s, e) => UpdatePageLayout();
            UpdatePageLayout();

            UIHelper.MakeRounded(page, 12);
            mainContentPanel.Controls.Add(wrapperPanel);
        }

    }
}