using CloudinaryDotNet.Core;
using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services;
using EnglishCenterManagement.UI.Views.Admin.Pages.Classes;
using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Classes
{
    public partial class StudentsPagePanel : BasePagePanel
    {
        private readonly ServiceHub _service;
        private List<Student> _student;
        public StudentsPagePanel(ServiceHub service)
        {
            InitializeComponent();
            _service = service;

            // Gán sự kiện Load
            LoadStudentsAsync();
        }

        private void LoadStudentsAsync()
        {
            try
            {
                _student = _service.StudentService.GetAllStudents().ToList();

                lblTotalStudents.Text = "Tổng số " + _student.Count.ToString() + " sinh viên";

                DisplayStudents(_student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải danh sách sinh viên:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
           
        }

        private void DisplayStudents(List<Student> students)
        {
            dgvStudents.Rows.Clear();

            foreach (var student in students)
            {
                int rowIndex = dgvStudents.Rows.Add();
                var row = dgvStudents.Rows[rowIndex];

                // Gán giá trị
                row.Cells["colId"].Value = student.StudentId;
                row.Cells["colFullName"].Value = student.FullName;
                row.Cells["colEmail"].Value = student.Email;
                row.Cells["colPhoneNumber"].Value = student.PhoneNumber;
                row.Cells["colDateOfBirth"].Value = student.DateOfBirth;
                row.Cells["colGender"].Value = student.Gender ? "Nam" : "Nữ";
                row.Cells["colPhoneNumberOfParent"].Value = student.PhoneNumberOfParents;

                // Gán tag để truy xuất đối tượng
                row.Tag = student;

                // Căn giữa cho tất cả các ô
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // Header căn giữa
            foreach (DataGridViewColumn col in dgvStudents.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var studentForm = new StudentAddEditForm(_service);
            var result = studentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadStudentsAsync();
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentsAsync();
        }

        private void btnEdit_click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
                return;
            }
            DataGridViewRow selectedStudent = dgvStudents.CurrentRow;

            Student s = _service.StudentService.GetById((int)selectedStudent.Cells["colId"].Value);

            var studentForm = new StudentAddEditForm(_service, s);

            var result = studentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadStudentsAsync();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Xử lý xóa sinh viên
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
                return;
            }

            if(!MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn xóa sinh viên này không?"))
            {
                return;
            }

            DataGridViewRow selectedStudent = dgvStudents.CurrentRow;

            try
            {
                Student s = _service.StudentService.GetById((int)selectedStudent.Cells["colId"].Value);

                _service.StudentService.Delete(s.StudentId);

                MessageHelper.ShowSuccess("Xóa sinh viên thành công!");

                LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi khi xóa sinh viên:\n" + ex.Message);
            }
        }
    }
}
