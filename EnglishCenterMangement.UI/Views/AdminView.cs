using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static  EnglishCenterManagement.UI.UIHelper;
using Timer = System.Windows.Forms.Timer;

namespace EnglishCenterMangement.UI.Views
{
    public partial class AdminView : Form
    {
        private List<Control> dropdownList = new List<Control>();
        private List<Control> btnControls = new List<Control>();

        private Panel currentHoveredPanel = null;
        private Color originalColor;

        public AdminView()
        {
            InitializeComponent();

            pbIconSearch.BringToFront();
            btnChevronLeft.BringToFront();
            SetButtonRadius(btnCreatePost, 20);


            initPanelBorderRadius();

            initScrollBar();

            initMenuItem();

            InitDropdownList();

            initButton();

            initIconPictureBoxBorderRadius();

            innitHoverPanel();


        }      

        private void innitHoverPanel()
        {

            Panel[] panelHover =
            {
                pnManagement, pnMarketPlace, pnGroup, pnEvent,
                pnMyClass, pnCalendar, pnReceipt, pnTask, pnTimeSheet,
                pnWrapContent, pnCaretGuideDoc, pnCaretLanguage, pnCaretLogout, pnCaretManage, pnCaretMode,
                pnCaretSupport, pnMenuItem1, pnMenuItem2, pnMenuItem3, pnMenuItem4, pnMenuItem5,pnLogoHeader
            };

            foreach(Panel ctrl in panelHover)
            {
                ApplyHoverToPanel(ctrl);
            }

        }

        private void initMenuItem()
        {
            AddMenuItem("Easy Space (Không gian chung)", "Không gian tương tác chung cho mọi thành viên trong Nhà trường", EnglishCenterMangement.UI.Properties.Resources.logo2019_png_1);
            AddMenuItem("Easy Order (Đơn hàng)", "Bán hàng tiện lợi, dễ dàng, hiệu quả, nhanh chóng", EnglishCenterMangement.UI.Properties.Resources.EasyOrder);
            AddMenuItem("Easy Omnichannel (Tương tác đa kênh)", "Chat real time nội bộ, quản lý tương tác qua Facebook, Zalo", EnglishCenterMangement.UI.Properties.Resources.EasySocial);
            AddMenuItem("Easy Store (Kho hàng)", "Quản lý xuất - nhâp - tồn kho nhanh chóng, đơn giản, hiệu quả", EnglishCenterMangement.UI.Properties.Resources.EasyStore);
            AddMenuItem("Easy Goal (Mục tiêu)", "Dễ dàng quản trị mục tiêu nhất quán trong doanh nghiệp qua công cụ OKRs, KPI và BSC", EnglishCenterMangement.UI.Properties.Resources.EasyGoal);
            AddMenuItem("Easy Drive (Tài liệu)", "Không gian lưu trữ File, Tài liệu, dễ dàng chia sẻ", EnglishCenterMangement.UI.Properties.Resources.EasyDrive);
            AddMenuItem("Easy CRM (Khách hàng)", "Tối ưu quy trình trước, trong và sau bán hàng hiệu quả", EnglishCenterMangement.UI.Properties.Resources.EasyCRM);
            AddMenuItem("Easy Games (Trò chơi)", "Hơn 30 Games giáo dục hiệu quả, hấp dẫn cho học sinh", EnglishCenterMangement.UI.Properties.Resources.EasyGames);
            AddMenuItem("Easy Education (Đào tạo)", "Dễ dàng vận hành mọi nghiệp vụ, mô hình đào tạo tùy biến, linh hoạt", EnglishCenterMangement.UI.Properties.Resources.EasyEducation);
            AddMenuItem("Easy Report (Báo cáo)", "Báo cáo chi tiết cho mọi chỉ số trong Doanh nghiệp", EnglishCenterMangement.UI.Properties.Resources.EasyReport);
            AddMenuItem("Easy Finance (Tài chính)", "Dễ dàng kiểm soát sức khỏe tài chính thông qua quản lý thu chi, công nợ, quỹ...", EnglishCenterMangement.UI.Properties.Resources.EasyFinance);
            AddMenuItem("Cấu hình", "Cấu hình cho Easy Platform, Phân quyền vai trò nhân sự", EnglishCenterMangement.UI.Properties.Resources.Settings);
            AddMenuItem("Easy Marketing (Tiếp thị)", "Thiết lập và Quản lý các chiến dịch Marketing (SMS, Email, Optin Form)", EnglishCenterMangement.UI.Properties.Resources.EasyMarketing);
            AddMenuItem("Easy HRM (Nhân sự)", "Dễ dàng xây dựng cơ chế, tối ưu nguồn lực nhân sự trong Doanh nghiệp", EnglishCenterMangement.UI.Properties.Resources.EasyHR);
            pnDropDownMenu.Controls.Add(tlpDropDownMenu);
        }

        private void initPanelBorderRadius()
        {// Các panel có cùng radius 28
            Panel[] panels28 = {
                    pnPlus, pnMenu, pnNotifications, pnMessage, pnCaretDown,
                    pnTop, pnNoData, pnLogoHeader,
                    pnWrapImage1, pnWrapImage2, pnWrapImage3, pnWrapImage4, pnWrapImage5
                    };

            foreach (var pn in panels28)
                SetPanelBorderRadius(pn, 28);

            // Các panel có radius 20
            Panel[] panels20 = {
                    pnSearchBox, pnBirthDayToDay, pnUpComingBirthDay, pnSocialMedia, pnEvents
                    };

            foreach (var pn in panels20)
                SetPanelBorderRadius(pn, 20);
        }


        private void initIconPictureBoxBorderRadius()
        {
            IconPictureBox[] icons = { iPbBook, iPbCircleQuestion, iPbMoon, iPbSignOut };

            foreach (var icon in icons)
                RoundIconPictureBox(icon, 23);
        }

        private void ConfigureScrollPanel(Panel panel)
        {
            panel.AutoScroll = true;
            panel.AutoScrollMinSize = new Size(0, 0);
            panel.HorizontalScroll.Maximum = 0;
            panel.HorizontalScroll.Visible = false;
            panel.AutoScrollPosition = new Point(0, 0);
            panel.VerticalScroll.Enabled = true;
            panel.VerticalScroll.Visible = true;
        }

        private void initScrollBar()
        {
            ConfigureScrollPanel(pnCaretDropDown);
            ConfigureScrollPanel(pnSideBar);
        }


        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Lấy vị trí chuột trên form
            Point clickPoint = this.PointToClient(Cursor.Position);

            // Kiểm tra xem click có nằm trong bất kỳ dropdown nào không
            bool clickedInsideDropdown = false;

            foreach (Control dropdown in dropdownList)
            {
                if (dropdown.Visible && dropdown.Bounds.Contains(clickPoint))
                {
                    clickedInsideDropdown = true;
                    break;
                }
            }

            // Nếu click bên ngoài tất cả dropdown → đóng tất cả
            if (!clickedInsideDropdown)
            {
                ResetAllDropdowns();
            }
        }

        private void InitDropdownList()
        {
            dropdownList.Add(pnDropDownMenu);
            dropdownList.Add(flpDropMenu);
            dropdownList.Add(pnMessageDropDown);
            dropdownList.Add(pnNotification);
            dropdownList.Add(pnCaretDropDown);
            // 👉 Thêm các dropdown khác vào đây
        }

        private void initButton()
        {
            btnControls.AddRange(new Control[]
            {
        rBtnAllNotifications,
        rBtnUnread,
        rBtnMentioned
            });
        }

        // Sự kiện click cho các nút filter
        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            SelectButton(clicked);
        }

        private void SelectButton(Button selectedBtn)
        {
            foreach (var btn in btnControls)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Orange;
            }

            selectedBtn.BackColor = Color.FromArgb(255, 175, 59);
            selectedBtn.ForeColor = Color.White;
        }

        private void ResetAllDropdowns()
        {
            foreach (Control ctrl in dropdownList)
            {
                if (ctrl.Visible)
                    ctrl.Visible = false;
            }
        }

        private void Hover_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            Panel panel = ctrl as Panel ?? ctrl.Parent as Panel;
            if (panel == null) return;

            if (panel.Tag == null)
                panel.Tag = panel.BackColor;

            originalColor = (Color)panel.Tag;
            panel.BackColor = Color.LightGray;

            currentHoveredPanel = panel;
        }


        private void Hover_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            Panel panel = ctrl as Panel ?? ctrl.Parent as Panel;
            if (panel == null) return;

            // Kiểm tra nếu chuột đã thật sự rời panel thì reset màu ngay
            if (!panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
            {
                if (panel.Tag is Color original)
                    panel.BackColor = original;

                currentHoveredPanel = null;
            }
        }


        // Hàm áp hiệu ứng hover cho panel và các control bên trong
        private void ApplyHoverToPanel(Panel panel)
        {
            panel.MouseEnter += Hover_MouseEnter;
            panel.MouseLeave += Hover_MouseLeave;

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label || ctrl is PictureBox)
                {
                    ctrl.MouseEnter += Hover_MouseEnter;
                    ctrl.MouseLeave += Hover_MouseLeave;
                }
            }
        }

        // Hàm hiển thị control
        private void ShowDropdown(Control ctrl)
        {
            if (ctrl == null) return;

            ctrl.BringToFront();
            ctrl.Visible = true;
        }

        // Hàm ẩn control
        private void HideDropdown(Control ctrl)
        {
            if (ctrl == null) return;

            ctrl.Visible = false;
        }

        // Hàm toggle control (ẩn/hiện)
        private void ToggleDropdown(Control ctrl)
        {
            if (ctrl == null) return;

            if (ctrl.Visible)
            {
                HideDropdown(ctrl);

            }
            else
            {
                ResetAllDropdowns(); // Ẩn tất cả trước
                ctrl.BringToFront();
                ShowDropdown(ctrl);

            }
        }

        // Sự kiện click cho các nút dropdown
        private void pnPlus_Click(object sender, EventArgs e)
        {
            ToggleDropdown(flpDropMenu);
        }

        private void pnMenu_Click(object sender, EventArgs e)
        {
            ToggleDropdown(pnDropDownMenu);
        }

        private void pnMessageDropDown_Click(object sender, EventArgs e)
        {
            ToggleDropdown(pnMessageDropDown);
        }

        private void pnNotifications_Click(object sender, EventArgs e)
        {
            ToggleDropdown(pnNotification);
        }

        private void pnCaretDown_Click(object sender, EventArgs e)
        {
            ToggleDropdown(pnCaretDropDown);
        }

        // tạo item menu cho dropdown 
        private Panel CreateMenuItemPanel(string title, string description, Image icon)
        {
            Panel itemPanel = new Panel
            {
                Height = 80,
                Width = 450,
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Padding = new Padding(10)
            };
            ApplyHoverToPanel(itemPanel);

            PictureBox pic = new PictureBox
            {
                Image = icon,
                Size = new Size(40, 40),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(10, 10)
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(60, 10),
                AutoSize = true,
                MaximumSize = new Size(350, 0)
            };

            itemPanel.Controls.Add(pic);
            itemPanel.Controls.Add(lblTitle);

            if (!string.IsNullOrEmpty(description))
            {
                Label lblDesc = new Label
                {
                    Text = description,
                    Font = new Font("Segoe UI", 8),
                    Location = new Point(60, 30),
                    MaximumSize = new Size(300, 0),
                    AutoSize = true
                };
                itemPanel.Controls.Add(lblDesc);
            }

            SetPanelBorderRadius(itemPanel, 10);
            return itemPanel;
        }

        // Hàm thêm item vào dropdown menu (table layout panel)
        private void AddMenuItem(string title, string description, Image icon)
        {
            Panel itemPanel = CreateMenuItemPanel(title, description, icon);
            int row = tlpDropDownMenu.RowCount++;
            tlpDropDownMenu.Controls.Add(itemPanel, row % 2, row / 2);
        }

        private void pnContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
