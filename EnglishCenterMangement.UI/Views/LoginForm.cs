using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Resize += (s, e) => CenterTabControl();
            tbcLogin.Width = 399;
            for (int i = 1; i <= 31; i++)
                cbxDayOfBirth.Items.Add(i);

            // --- Sinh tháng ---
            for (int i = 1; i <= 12; i++)
                cbxMonthOfBirth.Items.Add(i);

            // --- Sinh năm ---
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= 1900; i--)
                cbxYearOfBirth.Items.Add(i);

        }
        private void CenterTabControl()
        {
            tbcLogin.Left = (this.ClientSize.Width - tbcLogin.Width) / 2;
            tbcLogin.Top = 10 + (this.ClientSize.Height - tbcLogin.Height) / 10;
        }
        private void CapNhatChieuCaoTheoTab()
        {
            if (tbcLogin.SelectedTab == tpSignUp)
                tbcLogin.Height = 900;
            else
                tbcLogin.Height = 533;
        }
            
        private void LoginForm_Load(object sender, EventArgs e)
        {
            tpSignIn.Text = "Đăng nhập";
            tpSignUp.Text = "Đăng ký";
            tbcLogin.ItemSize = new Size(197, 53);
            CapNhatChieuCaoTheoTab();
            tbcLogin.Left = (this.ClientSize.Width - tbcLogin.Width) / 2;
            tbcLogin.Top = 100 + (this.ClientSize.Height - tbcLogin.Height) / 10;
        }
        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự
            }
        }
        private void cbxMonthOfBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNgay();
        }

        private void cbxYearOfBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNgay();
        }

        private void UpdateNgay()
        {
            if (cbxMonthOfBirth.SelectedIndex == -1)
                return;

            int thang = (int)cbxMonthOfBirth.SelectedItem;
            int nam = cbxYearOfBirth.SelectedIndex == -1 ? DateTime.Now.Year : (int)cbxYearOfBirth.SelectedItem;
            int soNgay = DateTime.DaysInMonth(nam, thang);

            // Lưu ngày hiện tại (nếu có)
            int ngayHienTai = cbxDayOfBirth.SelectedIndex != -1 ? (int)cbxDayOfBirth.SelectedItem : 1;

            // Cập nhật lại danh sách ngày
            cbxDayOfBirth.Items.Clear();
            for (int i = 1; i <= soNgay; i++)
                cbxDayOfBirth.Items.Add(i);

            // Nếu ngày cũ vẫn hợp lệ => giữ nguyên, ngược lại => set về ngày cuối cùng
            if (ngayHienTai <= soNgay)
                cbxDayOfBirth.SelectedItem = ngayHienTai;
            else
                cbxDayOfBirth.SelectedItem = soNgay;
        }
        private void tbcLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatChieuCaoTheoTab();
        }

        private void icusHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar)
            {
                txbPassword.UseSystemPasswordChar = false;
                icusHide.Icon = IconChar.Eye;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
                icusHide.Icon = IconChar.EyeSlash;
            }
        }
        private void txbEmail_Leave(object sender, EventArgs e)
        {
            string email = txbNewEmail.Text.Trim();

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbNewEmail.Focus();
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbNewEmail.Text) || string.IsNullOrWhiteSpace(txbNewPass.Text)
                || string.IsNullOrWhiteSpace(txbConfirmPass.Text) || string.IsNullOrWhiteSpace(txbName.Text)
                || string.IsNullOrWhiteSpace(txbPhoneNumber.Text) || cbxAddress.SelectedIndex == -1
                || cbxDayOfBirth.SelectedIndex == -1 || cbxMonthOfBirth.SelectedIndex == -1 || cbxYearOfBirth.SelectedIndex == -1 
                || string.IsNullOrWhiteSpace(txbCertificer.Text) || string.IsNullOrWhiteSpace(txbNote.Text)) {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbcLogin.SelectedTab = tpSignIn;
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbUsername.Text) || string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txbConfirmPass_Leave(object sender, EventArgs e)
        {
            if (txbConfirmPass.Text != txbNewPass.Text)
                MessageBox.Show("Mật khẩu không đúng, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void txbPhoneNumber_Leave(object sender, EventArgs e)
        {
            string sdt = txbPhoneNumber.Text.Trim();

            if (!Regex.IsMatch(sdt, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbPhoneNumber.Focus();
            }
        }
    }
}
