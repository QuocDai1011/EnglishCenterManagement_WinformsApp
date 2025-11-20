using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.UI.Controllers;
using EnglishCenterManagement.UI.Views.Student.Component;
using Guna.UI2.WinForms;

namespace EnglishCenterManagement.UI.Views
{
    public partial class StudentFrom : Form
    {
        public StudentFrom()
        {
            InitializeComponent();

            RenderActions();
            RenderRightActions();

            RenderSideBarAction();
        }

        private void RenderActions()
        {
            List<ActionItem> actions = new List<ActionItem>()
            {
                new ActionItem()
                {

                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\home.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\group.png"),
                    OnClick = () => MessageBox.Show("Trang Group")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\calendar.png"),
                    OnClick = () => MessageBox.Show("Trang Calendar")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\classroom.png"),
                    OnClick = () => MessageBox.Show("Trang People")
                }
            };
            FlowLayoutPanel flowActions = panelHeader.Controls
                                             .OfType<FlowLayoutPanel>()
                                             .FirstOrDefault(f => f.Name == "flowActions");
            if (flowActions == null) return;

            foreach (var item in actions)
            {
                Button btn = new Button();
                Image image = new Bitmap(item.Icon, new Size(40, 40));
                btn.Image = image;
                btn.Size = new Size(70, 70);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Text = "";
                btn.Cursor = Cursors.Hand;
                btn.Margin = new Padding(30, 0, 0, 30);

                ToolTip tip = new ToolTip();
                tip.SetToolTip(btn, item.Text ?? "");

                btn.Click += (s, e) => item.OnClick();

                flowActions.Controls.Add(btn);
            }

            // Căn giữa flowActions sau khi đã có button
            flowActions.Left = (panelHeader.Width - flowActions.Width) / 2;
            flowActions.Top = (panelHeader.Height - flowActions.Height) / 2;
            flowActions.BringToFront(); // không bị flowRightActions đè
        }

        private void RenderRightActions()
        {
            FlowLayoutPanel flowRightActions = panelHeader.Controls.OfType<FlowLayoutPanel>()
                                                .FirstOrDefault(f => f.Name == "flowRightActions");
            if (flowRightActions == null) return;

            flowRightActions.Controls.Clear();

            // List button tương ứng ảnh bạn gửi: +, grid, message, bell, arrow
            List<ActionItem> icons = new List<ActionItem>()
            {
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\user.png"),
                    Text = "Đại",
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\add.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\multiButton.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\chat.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\bell.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
            };

            foreach (var icon in icons)
            {
                Guna2CircleButton btn = new Guna2CircleButton();
                Image image = new Bitmap(icon.Icon, new Size(40, 40));
                btn.Image = image;
                btn.FillColor = Color.LightGray; // Màu nền bạn mu
                btn.Size = new Size(40, 40);
                btn.HoverState.FillColor = Color.Gray; // Màu khi hover
                //btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.BorderSize = 0;
                btn.Text = "";
                btn.Cursor = Cursors.Hand;
                btn.Margin = new Padding(5, 20, 20, 5);

                flowRightActions.Controls.Add(btn);
            }
        }

        private void RenderSideBarAction()
        {
            // Xóa FlowLayoutPanel cũ nếu có
            foreach (Control c in this.Controls.OfType<FlowLayoutPanel>().ToList())
            {
                this.Controls.Remove(c);
                c.Dispose();
            }

            // Tạo FlowLayoutPanel mới
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Name = "flowPanelSidebar";
            flowPanel.Location = new Point(0, 100);
            flowPanel.Size = new Size(263, 400); // chỉnh theo panel bạn muốn
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.WrapContents = false;     // không xuống hàng ngang
            flowPanel.AutoScroll = true;        // bật cuộn nếu nút nhiều
            flowPanel.Padding = new Padding(5); // padding xung quanh
            // Danh sách các nút
            List<SidebarItem> sidebarItems = new List<SidebarItem>()
            {
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\user.png"), Text = "Quốc Đại", OnClick = () => renderDetailStudent(15) },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\store.png"), Text = "Marketplace", OnClick = () => {} },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\classroom.png"), Text = "Lớp học của tôi", OnClick = () => renderClassStudent(1) },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\calendar.png"), Text = "Lịch cá nhân", OnClick = () => { } },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\details.png"), Text = "Bài tập về nhà", OnClick = () => { } },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\shopping-cart.png"), Text = "Đơn hàng", OnClick = () => { } },
            };

            int buttonWidth = flowPanel.ClientSize.Width - flowPanel.Padding.Horizontal; // rộng theo panel
            int buttonHeight = 50; // chiều cao cố định

            foreach (var item in sidebarItems)
            {
                Button btn = new Button();
                Image image = new Bitmap(item.Icon, new Size(24, 24));
                btn.Image = image;
                btn.Text = "       " + item.Text;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Click += (s, e) => item.OnClick();
                btn.Margin = new Padding(0, 0, 0, 5); // khoảng cách giữa các nút

                flowPanel.Controls.Add(btn);
            }

            // Thêm FlowLayoutPanel vào Form
            this.Controls.Add(flowPanel);
        }

        private void renderDetailStudent(int id)
        {
            var control = new DetailStudent();
            control.LoadDetailStudent(id);

            control.Dock = DockStyle.Fill; // chiếm toàn bộ panelControl
            control.Margin = new Padding(0);

            panelControl.Controls.Clear();
            panelControl.Controls.Add(control);
        }

        private void renderClassStudent(int studentId)
        {
            panelControl.Controls.Clear();

            // Tạo FlowLayoutPanel bên trong panelControl
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.AutoScroll = true;
            flowPanel.WrapContents = true; // khi hết hàng thì xuống hàng mới
            flowPanel.FlowDirection = FlowDirection.LeftToRight;
            flowPanel.Padding = new Padding(10);
            flowPanel.AutoSize = false;

            var controller = new Student_Class();
            var classes = controller.Get(studentId); // List<Class>

            foreach (var c in classes)
            {
                var item = new ClassStudent();
                item.SetData(c);
                item.Width = 300;  // chiều rộng item
                item.Height = 400; // chiều cao item
                item.Margin = new Padding(10);

                flowPanel.Controls.Add(item);
            }

            panelControl.Controls.Add(flowPanel);
        }


    }
}
