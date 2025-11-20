using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.UI.Views.SystemAcess.Pages.Register;
using EnglishCenterManagement.UI.Views.SystemAcess.Pages.ForgetForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EnglishCenterManagement.UI.Views.SystemAcess.Pages.Login
{
    public partial class LoginForm : Form
    {
        private readonly string _connectionString;
        public LoginForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }
        private bool CheckLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string[] tables = { "students", "teachers", "admins" };

                foreach (string table in tables)
                {
                    string query = $"SELECT password FROM {table} WHERE email = @e";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@e", email);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string dbPassword = result.ToString();

                            if (dbPassword == password)
                            {
                                MessageBox.Show($"Đăng nhập thành công! (Vai trò: {table})");
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Sai mật khẩu!");
                                return false;
                            }
                        }
                    }
                }

                MessageBox.Show("Email không tồn tại trong hệ thống!");
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbEmailLogin.Text.Trim();
            string password = txbPassLogin.Text.Trim();
            bool check = CheckLogin(username, password);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

            pnBackgroundLogin.Visible = false;
            pnBackgroundRegister.Visible = true;
            txbEmailLogin.Text = "";
            txbPassLogin.Text = "";
        }

        private void lblNavigationLogin_Click(object sender, EventArgs e)
        {
            pnBackgroundRegister.Visible = false;
            pnBackgroundLogin.Visible = true;
        }
        private void clearRegisterForm()
        {
            txbHoRegister.Text = "";
            txbTenRegister.Text = "";
            txbUsernameRegister.Text = "";
            txbPassRegister.Text = "";
            txbConfirmPass.Text = "";
            txbDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cbxGioiTinh.SelectedIndex = -1;
            txbSdt.Text = "";
            txbSdtPhuHuynh.Text = "";
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsernameRegister.Text.Trim();
            string password = txbPassRegister.Text.Trim();
            string firstName = txbHoRegister.Text.Trim();
            string lastName = txbTenRegister.Text.Trim();
            string confirmPassword = txbConfirmPass.Text.Trim();
            string address = txbDiaChi.Text.Trim();
            DateTime dob = dtpNgaySinh.Value;
            bool gender;
            if (cbxGioiTinh.Text.Trim() == "Nam") gender = true;
            else gender = false;
            string phone = txbSdt.Text.Trim();
            string parentPhone = txbSdtPhuHuynh.Text.Trim();
            bool check = RegisterUser(firstName, lastName, username, password, confirmPassword, address, dob, gender, phone, parentPhone);
            if (check)
            {
                pnBackgroundRegister.Visible = false;
                pnBackgroundLogin.Visible = true;
            }
            else MessageBox.Show("Đăng kí thất bại!");
        }
        private bool RegisterUser(
            string firstName,
            string lastName,
            string email,
            string password,
            string confirmPassword,
            string address,
            DateTime dob,
            bool gender,
            string phone,
            string parentPhone)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!");
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return false;
                }
                // Kiểm tra định dạng thêm: phải có @ và .domain
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ, phải đúng định dạng example@domain.com!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ!");
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!");
                return false;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải từ 6 ký tự trở lên!");
                return false;
            }

            string phonePattern = @"^0\d{9}$"; // bắt đầu bằng 0 và đúng 10 chữ số

            if (!string.IsNullOrEmpty(phone) && !System.Text.RegularExpressions.Regex.IsMatch(phone, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải bắt đầu bằng 0 và đúng 10 chữ số.");
                return false;
            }

            if (!string.IsNullOrEmpty(parentPhone) && !System.Text.RegularExpressions.Regex.IsMatch(parentPhone, phonePattern))
            {
                MessageBox.Show("Số điện thoại phụ huynh không hợp lệ! Phải bắt đầu bằng 0 và đúng 10 chữ số.");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string checkQuery = @"
                    SELECT COUNT(*) FROM (
                        SELECT email FROM students WHERE email = @e
                        UNION
                        SELECT email FROM teachers WHERE email = @e
                        UNION
                        SELECT email FROM admins WHERE email = @e
                    ) AS all_users";

                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@e", email);
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Email đã tồn tại trong hệ thống!");
                        return false;
                    }
                }
                string fullName = firstName + " " + lastName;
                // 5b️⃣ Chèn dữ liệu vào bảng students (ví dụ bạn muốn đăng ký học sinh)
                string insertQuery = @"
                    INSERT INTO students
                    (full_name,user_name, email, password, address, date_of_birth, gender, phone_number, phone_number_of_parents, is_active)
                    VALUES
                    (@fn,@userN, @em, @pw, @addr, @dob, @gender, @phone, @pphone, @isAc)";

                using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@fn", fullName);
                    cmdInsert.Parameters.AddWithValue("@userN", email);
                    cmdInsert.Parameters.AddWithValue("@em", email);
                    cmdInsert.Parameters.AddWithValue("@pw", password);
                    cmdInsert.Parameters.AddWithValue("@addr", address ?? "");
                    cmdInsert.Parameters.AddWithValue("@dob", dob);
                    cmdInsert.Parameters.AddWithValue("@gender", gender);
                    cmdInsert.Parameters.AddWithValue("@phone", phone ?? "");
                    cmdInsert.Parameters.AddWithValue("@pphone", parentPhone ?? "");
                    cmdInsert.Parameters.AddWithValue("@isAc", true);
                    cmdInsert.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đăng ký thành công!");
            clearRegisterForm();
            return true;
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblForgetPass_Click(object sender, EventArgs e)
        {
            var forgetForm = new ForgetForm.ForgetForm();
            forgetForm.ShowDialog();
        }
    }
}
