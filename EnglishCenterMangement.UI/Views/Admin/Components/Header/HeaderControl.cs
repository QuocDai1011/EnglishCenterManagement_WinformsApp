using EnglishCenterMangement.UI.Views.Admin.Utils;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Components.Header
{
    public partial class HeaderControl : UserControl
    {
        public event EventHandler<string> OnMenuItemClick;
        private Panel dropdownPanel;

        private List<Panel> centerIcons = new List<Panel>();
        private List<Panel> rightIcons = new List<Panel>();
        private PictureBox logo;
        private Panel searchBoxPanel;

        // Effect variables
        private System.Windows.Forms.Timer fadeTimer;
        private float dropdownOpacity = 0f;
        private bool fadeIn = true;
        public HeaderControl()
        {
            InitializeComponent();
            this.Height = 70;
            this.Dock = DockStyle.Top;
            SetupHeader();
        }

        private void SetupHeader()
        {
            this.BackColor = Color.White;
            this.Padding = new Padding(0);

            // Logo - Fixed position
            logo = new PictureBox
            {
                Location = new Point(15, 10),
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.logo2019_png_1
            };
            UIHelper.MakeRounded(logo, 8);
            this.Controls.Add(logo);

            // Search Box - Fixed position bên cạnh logo
            searchBoxPanel = UIHelper.CreateRoundedPanel(80, 10, 280, 50, 25, Color.FromArgb(240, 242, 245));
            TextBox searchBox = new TextBox
            {
                Location = new Point(20, 15),
                Size = new Size(240, 20),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                Text = "Search...",
                ForeColor = Color.Gray,
                BackColor = Color.FromArgb(240, 242, 245)
            };

            searchBox.GotFocus += (s, e) =>
            {
                if (searchBox.Text == "Search...")
                {
                    searchBox.Text = "";
                    searchBox.ForeColor = Color.Black;
                }
            };

            searchBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchBox.Text))
                {
                    searchBox.Text = "Search...";
                    searchBox.ForeColor = Color.Gray;
                }
            };

            searchBoxPanel.Controls.Add(searchBox);
            this.Controls.Add(searchBoxPanel);

            // Center Navigation Icons
            CreateCenterIcons();

            // Right Side Icons
            CreateRightIcons();

            // Bottom border line
            Panel borderLine = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(230, 230, 230)
            };
            this.Controls.Add(borderLine);
        }

        #region Center Icons
        private void CreateCenterIcons()
        {
            IconChar[] icons = {
                IconChar.Home,
                IconChar.UserGroup,
                IconChar.Calendar,
                IconChar.Trophy
            };
            string[] actions = { "home", "users", "calendar", "trophy" };
            int iconWidth = 60;
            int iconHeight = 60;

            for (int i = 0; i < icons.Length; i++)
            {
                Panel iconPanel = new Panel
                {
                    Size = new Size(iconWidth, iconHeight),
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand,
                };

                IconPictureBox iconPicture = new IconPictureBox
                {
                    IconChar = icons[i],
                    IconColor = Color.FromArgb(65, 65, 65),
                    IconSize = 32,
                    Size = new Size(40, 40),
                    Location = new Point((iconWidth - 40) / 2, (iconHeight - 40) / 2),
                    BackColor = Color.Transparent
                };

                iconPanel.Controls.Add(iconPicture);
                UIHelper.AddHoverEffect(iconPanel, Color.FromArgb(240, 242, 245), Color.Transparent);

                int index = i;
                iconPanel.Click += (s, e) => OnMenuItemClick?.Invoke(this, actions[index]);
                iconPicture.Click += (s, e) => OnMenuItemClick?.Invoke(this, actions[index]);

                this.Controls.Add(iconPanel);
                centerIcons.Add(iconPanel);
            }

            UpdateCenterIconsPosition();
            this.Resize += (s, e) => UpdateCenterIconsPosition();
        }

        private void UpdateCenterIconsPosition()
        {
            int iconWidth = 80;
            int spacing = 30;
            int totalWidth = centerIcons.Count * iconWidth + (centerIcons.Count - 1) * spacing;
            int startX = (this.Width - totalWidth) / 2;

            for (int i = 0; i < centerIcons.Count; i++)
            {
                centerIcons[i].Location = new Point(startX + i * (iconWidth + spacing), 5);
            }
        }
        #endregion

        #region Right Icons
        private void CreateRightIcons()
        {
            IconChar[] icons = {
                IconChar.Plus,
                IconChar.EllipsisVertical,
                IconChar.Message,
                IconChar.Bell,
                IconChar.CaretDown
            };
            string[] categories = { "create", "menu", "messages", "notifications", "profile" };
            string[][] dropdowns = {
                new string[] { "Tạo bài viết", "Tạo nhóm", "Tạo sự kiện" },
                new string[] { "Thêm nhân sự", "Thêm sinh viên", "Thêm hóa đơn", "Thêm lớp học", "Thêm lịch học" },
                new string[] { "Tin nhắn 1", "Tin nhắn 2", "Xem tất cả" },
                new string[] { "Thông báo 1", "Thông báo 2", "Xem tất cả" },
                new string[] { "Hồ sơ", "Cài đặt", "Hỗ trợ", "Tài liệu hướng dẫn", "Chế độ tối" ,"Đăng xuất" }
            };

            for (int i = 0; i < icons.Length; i++)
            {
                Panel iconContainer = new Panel
                {
                    Size = new Size(60, 60),
                    BackColor = Color.FromArgb(228, 230, 235),
                    Cursor = Cursors.Hand
                };
                UIHelper.MakeRounded(iconContainer, 50);

                IconPictureBox iconPicture = new IconPictureBox
                {
                    IconChar = icons[i],
                    IconColor = Color.FromArgb(65, 65, 65),
                    IconSize = 24,
                    Size = new Size(40, 40),
                    Location = new Point(10, 10),
                    BackColor = Color.Transparent
                };

                iconContainer.Controls.Add(iconPicture);
                UIHelper.AddHoverEffect(iconContainer, Color.FromArgb(210, 212, 217), Color.FromArgb(228, 230, 235));

                int index = i;
                iconContainer.Click += (s, e) => ShowDropdown(iconContainer, dropdowns[index], categories[index]);
                iconPicture.Click += (s, e) => ShowDropdown(iconContainer, dropdowns[index], categories[index]);

                this.Controls.Add(iconContainer);
                rightIcons.Add(iconContainer);
            }

            UpdateRightIconsPosition();
            this.Resize += (s, e) => UpdateRightIconsPosition();
        }

        private void UpdateRightIconsPosition()
        {
            int iconSize = 45;
            int spacing = 30;
            int totalWidth = rightIcons.Count * (iconSize + spacing);
            int startX = this.Width - totalWidth - 15;

            for (int i = 0; i < rightIcons.Count; i++)
            {
                rightIcons[i].Location = new Point(startX + i * (iconSize + spacing), 12);
            }
        }
        #endregion

        #region Dropdown

        

        private void ShowDropdown(Control parent, string[] items, string category)
        {
            HideDropdown(); // đóng nếu đang mở

            dropdownPanel = new Panel
            {
                Size = new Size(200, items.Length * 45 + 10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            UIHelper.MakeRounded(dropdownPanel, 10);

            // Tạo các item trong dropdown
            for (int i = 0; i < items.Length; i++)
            {
                int index = i;
                Button itemBtn = new Button
                {
                    Text = items[i],
                    Location = new Point(5, 5 + i * 45),
                    Size = new Size(188, 40),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10),
                    Cursor = Cursors.Hand,
                    Padding = new Padding(15, 0, 0, 0)
                };
                itemBtn.FlatAppearance.BorderSize = 0;
                UIHelper.AddHoverEffect(itemBtn, Color.FromArgb(240, 242, 245), Color.White);

                itemBtn.Tag = new { Category = category, Item = items[index] };
                itemBtn.Click += ItemBtn_Click;


                dropdownPanel.Controls.Add(itemBtn);
            }

            // Tính vị trí dropdown theo form cha
            Form parentForm = this.FindForm();
            parentForm.Controls.Add(dropdownPanel);
            dropdownPanel.BringToFront();

            Point screenPos = parent.PointToScreen(new Point(0, parent.Height + 5));
            dropdownPanel.Location = parentForm.PointToClient(screenPos);

            // Reset opacity
            dropdownOpacity = 0f;
            fadeIn = true;
            StartFadeEffect();

            // Bắt sự kiện click ngoài
            parentForm.Click += ParentForm_Click;
            this.Click += HeaderControl_Click;
        }
        private void ItemBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            dynamic tag = btn.Tag;

            string category = tag.Category;
            string item = tag.Item;

            // Gửi sự kiện ra ngoài
            OnMenuItemClick?.Invoke(this, $"{category}:{item}");

            HideDropdown();
        }

        private void StartFadeEffect()
        {
            if (fadeTimer == null)
            {
                fadeTimer = new System.Windows.Forms.Timer();
                fadeTimer.Interval = 15;
                fadeTimer.Tick += FadeTimer_Tick;
            }
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (dropdownPanel == null) return;

            if (fadeIn)
            {
                dropdownOpacity += 0.12f;
                if (dropdownOpacity >= 1f)
                {
                    dropdownOpacity = 1f;
                    fadeTimer.Stop();
                }
            }
            else
            {
                dropdownOpacity -= 0.12f;
                if (dropdownOpacity <= 0f)
                {
                    dropdownOpacity = 0f;
                    fadeTimer.Stop();
                    dropdownPanel.Visible = false;
                    dropdownPanel.Dispose();
                    dropdownPanel = null;
                    return;
                }
            }

            dropdownPanel.BackColor = Color.FromArgb((int)(dropdownOpacity * 255), Color.White);
        }

        private void HideDropdown()
        {
            if (dropdownPanel != null)
            {
                fadeIn = false;
                dropdownPanel.Visible = false;
                StartFadeEffect();
            }
        }

        private void ParentForm_Click(object sender, EventArgs e)
        {
            HideDropdown();
            Form parentForm = this.FindForm();
            parentForm.Click -= ParentForm_Click;
        }

        private void HeaderControl_Click(object sender, EventArgs e)
        {
            HideDropdown();
            this.Click -= HeaderControl_Click;
        }

        #endregion


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
    }
}