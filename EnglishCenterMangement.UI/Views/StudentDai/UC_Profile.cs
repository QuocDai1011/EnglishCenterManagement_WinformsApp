using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services;
using Microsoft.IdentityModel.Tokens;
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
    public partial class UC_Profile : UserControl
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        public UC_Profile(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _serviceHub = serviceHub;

            Render();
        }

        private void Render()
        {
            var teacher = _serviceHub._teacherService.GetById(_teacherId);
            if (teacher == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
                return;
            }
            lblNameProfile.Text = teacher.FullName;
            lblNameProfile.Location = new Point(
                pnHeaderProfile.Width / 2 - lblNameProfile.Width / 2,
                220
                );
            txtID.Text = teacher.TeacherID + "";
            txtUsername.Text = teacher.UserName;
            txtFullName.Text = teacher.FullName;
            txtEmail.Text = teacher.Email;
            if (teacher.Gender)
            {
                txtGender.Text = "Nam";
            }
            else
            {
                txtGender.Text = "Nữ";
            }
            txtDateOfBirth.Text = teacher.DateOfBirth + "";
            txtPhoneNumber.Text = teacher.PhoneNumber;
            txtAddress.Text = teacher.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var teacher = _serviceHub._teacherService.GetById(_teacherId);
            if (teacher == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
                return;
            }
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }
            else
            {
                teacher.FullName = txtFullName.Text;
            }

            if (txtGender.Text != "Nam" && txtGender.Text != "Nữ")
            {
                MessageBox.Show("Giới tính chỉ được nhập: 'Nam' hoặc 'Nữ'");
                return;
            }
            else if (txtGender.Text.Equals("Nam"))
            {
                teacher.Gender = true;
            }
            else
            {
                teacher.Gender = false;
            }

            if (!DateOnly.TryParse(txtDateOfBirth.Text, out DateOnly dob))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập theo dạng yyyy-MM-dd hoặc dd/MM/yyyy.");
                return;
            }

            if (dob >= DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.");
                return;
            }

            teacher.DateOfBirth = dob;

            if (txtPhoneNumber.Text.Count() != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 chữ số.");
                return;
            }
            else
            {
                if (!txtPhoneNumber.Text.StartsWith('0'))
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng chữ số '0'.");
                    return;
                }
                teacher.PhoneNumber = txtPhoneNumber.Text;
            }

            teacher.Address = txtAddress.Text;

            int success = _serviceHub._teacherService.Update(_teacherId, teacher);
            if (success == 0)
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công.");
                Render();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang trong quá trình phát triển!");
        }
    }
}
