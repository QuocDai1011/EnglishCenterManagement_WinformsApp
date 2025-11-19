using EnglishCenterManagement.UI.Views.Student.assets;
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

namespace EnglishCenterManagement.UI.Views.Student
{
    public partial class teacherForm : Form
    {
        public teacherForm()
        {
            InitializeComponent();
        }

        private void index_Load(object sender, EventArgs e)
        {
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
            // position panel ngay dưới button
            var pt = btnDownHeader.PointToScreen(Point.Empty);
            var formPt = this.PointToClient(pt);
            panelDropDown.Location = new Point(formPt.X, formPt.Y + btnDownHeader.Height);
            panelDropDown.BringToFront();
            panelDropDown.Visible = !panelDropDown.Visible;
        }

        private void LoadUC(UserControl uc)
        {
            pnContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnContent.Controls.Add(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_Profile());
        }

        private void btnAssignmentHomeworkSidebar_Click(object sender, EventArgs e)
        {

        }

        private void btnMyClassSidebar_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_MyClass());
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
    }
}
