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
        private readonly ServiceHub _service;
        private readonly Student _student;
        private readonly Class _classes;
        private List<Course> _courses;
        private bool _isEditMode = false;

        public StudentAddEditForm(ServiceHub service, Class classes, Student student = null)
        {
            InitializeComponent();
            _service = service;
            _classes = classes;
            _student = student;
            _isEditMode = student != null;

            InitializeForm();
        }

        private void InitializeForm()
        {
            try
            {
                LoadCourses();
                SetupEventHandlers();

                if (_isEditMode)
                    LoadStudentData();
                else
                    SetDefaultValues();

                UpdateDiscountAccessibility();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khởi tạo form:\n{ex.Message}");
                this.Close();
            }
        }

        private void LoadCourses()
        {
            _courses = _service.CourseService.GetAllCourses().ToList();

            if (_courses == null || !_courses.Any())
            {
                MessageHelper.ShowWarning("Không có khóa học nào trong hệ thống!");
                this.Close();
                return;
            }

            cboCourse.Items.Clear();
            foreach (Course c in _courses)
            {
                cboCourse.Items.Add(c.CourseName);
            }
        }

        private void SetupEventHandlers()
        {
            cboDiscountType.SelectedIndexChanged += (s, e) => UpdateDiscountAccessibility();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void SetDefaultValues()
        {
            lblTitle.Text = $"Thêm sinh viên mới - Lớp {_classes.ClassName}";
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);

            UIHelper.ResetComboBoxes(cboCourse, cboDiscountType, cboGender);
        }

        private void LoadStudentData()
        {
            if (_student == null) return;

            lblTitle.Text = $"Cập nhật sinh viên - Lớp {_classes.ClassName}";

            txtUserName.Text = _student.UserName;
            txtPassword.Text = _student.Password;
            txtFullName.Text = _student.FullName;
            txtEmail.Text = _student.Email;
            txtPhone.Text = _student.PhoneNumber;
            txtPhoneParents.Text = _student.PhoneNumberOfParents;
            txtAddress.Text = _student.Address;

            cboGender.SelectedIndex = _student.Gender ? 0 : 1;
            chkIsActive.Checked = _student.IsActive;

            if (_student.DateOfBirth.HasValue)
                dtpDateOfBirth.Value = _student.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue);
        }

        private void UpdateDiscountAccessibility()
        {
            string value = cboDiscountType.SelectedItem?.ToString();
            bool enabled = value == "FixedAmount" || value == "Percentage";

            numDiscountValue.Enabled = enabled;
            lblDiscountValue.Enabled = enabled;

            if (!enabled)
                numDiscountValue.Value = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAndConfirm()) return;

            try
            {
                UIHelper.SetControlsBusy(new Control[] { btnSave, btnCancel }, true);
                this.Cursor = Cursors.WaitCursor;

                Student student = BuildStudentFromForm();
                string result = SaveStudent(student);

                if (result != null)
                {
                    MessageHelper.ShowError(result);
                    return;
                }

                if (!_isEditMode)
                {
                    string courseResult = SaveStudentCourse(student);
                    if (courseResult != null)
                    {
                        MessageHelper.ShowWarning(
                            $"Sinh viên đã được tạo nhưng có lỗi khi đăng ký khóa học:\n{courseResult}"
                        );
                    }
                }

                MessageHelper.ShowSuccess(
                    _isEditMode
                        ? "Cập nhật thông tin sinh viên thành công!"
                        : $"Thêm sinh viên vào lớp {_classes.ClassName} thành công!"
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi không mong muốn:\n{ex.Message}");
            }
            finally
            {
                UIHelper.SetControlsBusy(new Control[] { btnSave, btnCancel }, false);
                this.Cursor = Cursors.Default;
            }
        }

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
                cboCourse.SelectedIndex,
                cboDiscountType.SelectedIndex,
                numDiscountValue.Value,
                out errors
            );

            if (!isValid)
            {
                MessageHelper.ShowValidationErrors(errors);
                return false;
            }

            string confirmMsg = _isEditMode
                ? "Bạn có chắc chắn muốn cập nhật thông tin sinh viên này?"
                : $"Bạn có chắc chắn muốn thêm sinh viên vào lớp {_classes.ClassName}?";

            return MessageHelper.ShowConfirmation(confirmMsg);
        }

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

        private string SaveStudent(Student student)
        {
            //return _isEditMode
            //    ? _service.StudentService.Update(student)
            //    : _service.StudentService.Create(student);
            return "";
        }

        private string SaveStudentCourse(Student student)
        {
            try
            {
                var selectedCourse = _courses[cboCourse.SelectedIndex];

                var studentCourse = new StudentCourse
                {
                    StudentId = student.StudentId,
                    CourseId = selectedCourse.CourseId,
                    DiscountType = cboDiscountType.SelectedItem?.ToString() ?? "None",
                    DicountValue = numDiscountValue.Value,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                //return _service.StudentCourseService.Create(studentCourse);
                return "";
            }
            catch (Exception ex)
            {
                return $"Lỗi khi đăng ký khóa học: {ex.Message}";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ShowConfirmation(
                "Bạn có chắc chắn muốn hủy?\nMọi thay đổi sẽ không được lưu!"))
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
