using CloudinaryDotNet.Core;
using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services;
using EnglishCenterManagement.UI.Views.Admin.Pages.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Classes
{
    public partial class StudentOfClass : UserControl
    {
        private Class _classes;
        private List<Student> students;
        private List<Student> _filteredStudents;
        private readonly ServiceHub _service;

        public StudentOfClass(Class classes, ServiceHub service)
        {
            InitializeComponent();
            _classes = classes;
            _service = service;

            // Gán sự kiện Load
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;
            LoadStudentsAsync();
            lblTitle.Text = $"Danh sách sinh viên - {_classes.ClassName}";
        }

        private void LoadStudentsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnAdd.Enabled = false;
                btnRefresh.Enabled = false;

                var studentsList =  _service.StudentService.GetAllStudentsByClassId(_classes.ClassId);
                students = studentsList.ToList();
                _filteredStudents = students;

                DisplayStudents(_filteredStudents);
                UpdateStudentCount();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(
                    $"Lỗi khi tải danh sách sinh viên:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnAdd.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void DisplayStudents(List<Student> students)
        {
            dgvStudents.Rows.Clear();

            foreach (var student in students)
            {
                int rowIndex = dgvStudents.Rows.Add();
                var row = dgvStudents.Rows[rowIndex];
                var course = _service.CourseService.getCourseByStudentId(student.StudentId).CourseName;

                row.Cells["Gender"].Value = student.Gender == true ? "Nam" : "Nữ";
                row.Cells["colCourse"].Value = course;
                row.Cells["colFullName"].Value = student.FullName;
                row.Cells["colEmail"].Value = student.Email;
                row.Cells["colPhone"].Value = student.PhoneNumber;
                row.Cells["colDateOfBirth"].Value = student.DateOfBirth;
                row.Cells["phoneNumberOfParent"].Value = student.PhoneNumberOfParents;
                row.Tag = student;
            }
        }

        private void UpdateStudentCount()
        {
            lblTotalStudents.Text = $"Tổng số: {_filteredStudents.Count} sinh viên";
        }

        // Event Handlers
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _filteredStudents = students;
            }
            else
            {
                _filteredStudents = students.Where(s =>
                    s.FullName.ToLower().Contains(searchText) ||
                    s.Email.ToLower().Contains(searchText) ||
                    s.PhoneNumber.Contains(searchText) ||
                    s.StudentId.ToString().Contains(searchText)
                ).ToList();
            }

            DisplayStudents(_filteredStudents);
            UpdateStudentCount();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new StudentAddEditForm(_service, _classes);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Thêm sinh viên thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadStudentsAsync();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var selectedStudent = dgvStudents.SelectedRows[0].Tag as Student;
            if (selectedStudent == null) return;

            var editForm = new StudentAddEditForm(_service, _classes, selectedStudent);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Cập nhật thông tin sinh viên thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadStudentsAsync();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var selectedStudent = dgvStudents.SelectedRows[0].Tag as Student;
            if (selectedStudent == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên:\n\n" +
                $"Mã SV: {selectedStudent.StudentId}\n" +
                $"Họ tên: {selectedStudent.FullName}\n\n" +
                $"Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                     _service.StudentService.Delete(selectedStudent.StudentId);

                    MessageBox.Show(
                        "Xóa sinh viên thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadStudentsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Lỗi khi xóa sinh viên:\n{ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            LoadStudentsAsync();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Lưu danh sách sinh viên";
                    saveFileDialog.FileName = $"DanhSachSinhVien_Lop{_classes.ClassId}_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // TODO: Implement Excel export using EPPlus or ClosedXML
                        MessageBox.Show(
                            "Chức năng xuất Excel đang được phát triển!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi xuất file:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvStudents.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void DgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEdit_Click(sender, e);
            }
        }
    }
}
