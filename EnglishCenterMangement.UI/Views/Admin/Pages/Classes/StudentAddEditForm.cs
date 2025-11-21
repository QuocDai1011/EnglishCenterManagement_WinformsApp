using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views.Admin.Pages.Classes
{
    public partial class StudentAddEditForm : Form
    {
        // ==================== FIELDS ====================
        private readonly ServiceHub _service;
        private readonly Student _student;
        private bool _isEditMode = false;

        // ==================== CONSTRUCTOR ====================
        public StudentAddEditForm(ServiceHub service, Student student = null)
        {
            InitializeComponent();
            InitializeForm();

            _service = service;
            _student = student;                // gán Student đúng kiểu
            _isEditMode = student != null;     // kiểm tra chế độ edit hay add

            if (_isEditMode)
                LoadStudentData();
        }

        // ==================== FORM INITIALIZATION ====================
        private void InitializeForm()
        {
            try
            {
                SetupEventHandlers();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khởi tạo form:\n{ex.Message}");
                this.Close();
            }
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        // ==================== LOAD DATA ====================
        private void LoadStudentData()
        {
            txtUserName.Text = _student.UserName;
            txtPassword.Text = _student.Password;
            txtFullName.Text = _student.FullName;
            txtEmail.Text = _student.Email;
            txtPhone.Text = _student.PhoneNumber;
            txtPhoneParents.Text = _student.PhoneNumberOfParents;
            txtAddress.Text = _student.Address;

            cboGender.SelectedItem = _student.Gender ? "Nam" : "Nữ";

            if (_student.DateOfBirth != null)
                dtpDateOfBirth.Text = _student.DateOfBirth.ToString();

            chkIsActive.Checked = _student.IsActive;
        }

        // ==================== BUTTON EVENTS ====================
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate form
                if (!ValidateAndConfirm())
                    return;

                // Build Student object từ form
                Student student = BuildStudentFromForm();

                if (_isEditMode)
                    UpdateStudent(student);
                else
                    AddStudent(student);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi không mong muốn:\n{ex.Message}\n\nChi tiết: {ex.InnerException?.Message}");
            }
        }

        // ==================== CRUD METHODS ====================
        private void AddStudent(Student student)
        {
            try
            {
                string result = _service.StudentService.Create(student);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageHelper.ShowError($"Lỗi khi thêm sinh viên:\n{result}");
                    return;
                }

                MessageHelper.ShowInfo("Thêm sinh viên thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi thêm sinh viên:\n{ex.Message}");
            }
        }

        private void UpdateStudent(Student student)
        {
            try
            {
                string result = _service.StudentService.Update(student);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageHelper.ShowError($"Lỗi khi cập nhật sinh viên:\n{result}");
                    return;
                }

                MessageHelper.ShowInfo("Cập nhật sinh viên thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi cập nhật sinh viên:\n{ex.Message}");
            }
        }

        // ==================== VALIDATION ====================
        private bool ValidateAndConfirm()
        {
            string errors;
            bool isValid = FormValidator.ValidateStudentForm(
                txtUserName.Text.Trim(),
                txtPassword.Text.Trim(),
                txtFullName.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtPhoneParents.Text.Trim(),
                dtpDateOfBirth.Value,
                cboGender.SelectedIndex,
                out errors
            );

            if (!isValid)
                MessageHelper.ShowValidationErrors(errors);

            return isValid;
        }

        // ==================== BUILD STUDENT OBJECT ====================
        private Student BuildStudentFromForm()
        {
            DateTime now = DateTime.Now;
            bool gender = cboGender.SelectedItem?.ToString() == "Nam";

            if (_isEditMode)
            {
                _student.UserName = txtUserName.Text.Trim();
                _student.Password = txtPassword.Text.Trim();
                _student.FullName = txtFullName.Text.Trim();
                _student.Email = txtEmail.Text.Trim();
                _student.PhoneNumber = txtPhone.Text.Trim();
                _student.PhoneNumberOfParents = txtPhoneParents.Text.Trim();
                _student.Gender = gender;
                _student.Address = txtAddress.Text.Trim();
                _student.DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);
                _student.UpdateAt = now;
                _student.IsActive = chkIsActive.Checked;
                return _student;
            }

            return new Student
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                PhoneNumberOfParents = txtPhoneParents.Text.Trim(),
                Gender = gender,
                Address = txtAddress.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                CreateAt = now,
                UpdateAt = now,
                IsActive = chkIsActive.Checked
            };
        }
    }
}
