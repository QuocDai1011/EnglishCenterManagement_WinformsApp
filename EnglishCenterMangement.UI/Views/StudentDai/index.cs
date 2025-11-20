using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views.StudentDai
{
    public partial class teacherForm : Form
    {
        private readonly ServiceHub _serviceHub;
        private readonly int teacherId = 1;
        public teacherForm(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            InitializeDropdown();
        }

        private void index_Load(object sender, EventArgs e)
        {
            var teacher = _serviceHub._teacherService.GetById(teacherId);
            if (teacher == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
                return;
            }
            btnProfileSidebar.Text = teacher.FullName;
            lblNameHeader.Text = teacher.FullName[^1].ToString();

            LoadUC(new UC_Home());
        }

        private void AutoCloseDropdown(object sender, EventArgs e)
        {
            if (panelDropDown.Visible)
                panelDropDown.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flpHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHomeHeader_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_Home());
        }

        private void btnCalendarHeader_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã nhấn vào Calendar btn");
        }

        private void btnAssignmentHeader_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã nhấn vào Assignment btn");
        }

        private void btnClassHeader_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã nhấn vào Class btn");
        }

        private void lblNameHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnDownHeader_Click(object sender, EventArgs e)
        {
            // Lấy vị trí của button trên màn hình
            var screenPoint = btnDownHeader.PointToScreen(Point.Empty);
            // Chuyển đổi sang tọa độ của form
            var formPoint = this.PointToClient(screenPoint);

            // Đặt dropdown ngay dưới button
            panelDropDown.Location = new Point(formPoint.X, formPoint.Y + btnDownHeader.Height);
            panelDropDown.BringToFront();
            panelDropDown.BackColor = Color.White;

            //Toggle hiển thị
            panelDropDown.Visible = !panelDropDown.Visible;
        }

        // Đóng dropdown khi click ra ngoài
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (panelDropDown.Visible)
            {
                // Nếu click không nằm trong dropdown & không trúng button mở dropdown
                if (!panelDropDown.Bounds.Contains(e.Location) &&
                    !btnDownHeader.Bounds.Contains(e.Location))
                {
                    panelDropDown.Visible = false;
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {

                MessageBox.Show("Đăng xuất thành công.");
                // Đóng form hiện tại
                //this.Hide();

                // Mở lại form đăng nhập
                //var loginForm = new LoginForm();
                //loginForm.Show();

                // Hoặc tốt hơn:
                // Application.Restart();
            }
        }

        private void LoadUC(UserControl uc)
        {
            pnContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnContent.Controls.Add(uc);

            panelDropDown.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_Profile(teacherId, _serviceHub));
        }

        private void btnAssignmentHomeworkSidebar_Click(object sender, EventArgs e)
        {

        }

        private void btnMyClassSidebar_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_MyClass(_serviceHub, teacherId));
        }

        private void flowPnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pnFlowDetailProfile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtIdValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (panelDropDown.Visible)
            {
                // Nếu click không nằm trong dropdown & không trúng button mở dropdown
                if (!panelDropDown.Bounds.Contains(e.Location) &&
                    !btnDownHeader.Bounds.Contains(e.Location))
                {
                    panelDropDown.Visible = false;
                }
            }
        }

        private void InitializeDropdown()
        {
            // Panel Dropdown
            panelDropDown.Size = new Size(330, 90);
            panelDropDown.Visible = false;
            panelDropDown.BackColor = Color.Transparent;

            
            this.Controls.Add(panelDropDown);
        }
        private void btnProfileHeader_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_Profile(teacherId, _serviceHub));
            panelDropDown.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
