using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views.Admin.Pages.Classes
{
    partial class StudentAddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneParents;
        private System.Windows.Forms.TextBox txtPhoneParents;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblCourseSection;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.ComboBox cboDiscountType;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.NumericUpDown numDiscountValue;
        private System.Windows.Forms.Label lblDiscountNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelCourseInfo;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblPhoneParents = new Label();
            txtPhoneParents = new TextBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblIsActive = new Label();
            chkIsActive = new CheckBox();
            panelCourseInfo = new Panel();
            lblCourseSection = new Label();
            lblCourse = new Label();
            cboCourse = new ComboBox();
            lblDiscountType = new Label();
            cboDiscountType = new ComboBox();
            lblDiscountValue = new Label();
            numDiscountValue = new NumericUpDown();
            lblDiscountNote = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelCourseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscountValue).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(63, 81, 181);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(700, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(312, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thêm sinh viên vào lớp";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserName.Location = new Point(30, 90);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(141, 23);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Tên đăng nhập *";
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 11F);
            txtUserName.Location = new Point(30, 118);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(300, 32);
            txtUserName.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.Location = new Point(360, 90);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu *";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(360, 118);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 32);
            txtPassword.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFullName.Location = new Point(30, 165);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 23);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Họ và tên *";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.Location = new Point(30, 193);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(630, 32);
            txtFullName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(30, 240);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(67, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(30, 268);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(630, 32);
            txtEmail.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.Location = new Point(30, 315);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(129, 23);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Số điện thoại *";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.Location = new Point(30, 343);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(300, 32);
            txtPhone.TabIndex = 4;
            // 
            // lblPhoneParents
            // 
            lblPhoneParents.AutoSize = true;
            lblPhoneParents.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhoneParents.Location = new Point(360, 315);
            lblPhoneParents.Name = "lblPhoneParents";
            lblPhoneParents.Size = new Size(133, 23);
            lblPhoneParents.TabIndex = 6;
            lblPhoneParents.Text = "SĐT phụ huynh";
            // 
            // txtPhoneParents
            // 
            txtPhoneParents.Font = new Font("Segoe UI", 11F);
            txtPhoneParents.Location = new Point(360, 343);
            txtPhoneParents.Name = "txtPhoneParents";
            txtPhoneParents.Size = new Size(300, 32);
            txtPhoneParents.TabIndex = 5;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDateOfBirth.Location = new Point(30, 390);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(102, 23);
            lblDateOfBirth.TabIndex = 7;
            lblDateOfBirth.Text = "Ngày sinh *";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 11F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(30, 418);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 32);
            dtpDateOfBirth.TabIndex = 6;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGender.Location = new Point(260, 390);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(93, 23);
            lblGender.TabIndex = 8;
            lblGender.Text = "Giới tính *";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 11F);
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(260, 418);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(200, 33);
            cboGender.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddress.Location = new Point(30, 465);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(65, 23);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 11F);
            txtAddress.Location = new Point(30, 493);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(630, 70);
            txtAddress.TabIndex = 9;
            // 
            // lblIsActive
            // 
            lblIsActive.AutoSize = true;
            lblIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsActive.Location = new Point(490, 390);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(92, 23);
            lblIsActive.TabIndex = 9;
            lblIsActive.Text = "Trạng thái";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 10F);
            chkIsActive.Location = new Point(490, 422);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(114, 27);
            chkIsActive.TabIndex = 8;
            chkIsActive.Text = "Hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // panelCourseInfo
            // 
            panelCourseInfo.BackColor = Color.FromArgb(250, 250, 250);
            panelCourseInfo.BorderStyle = BorderStyle.FixedSingle;
            panelCourseInfo.Controls.Add(lblCourseSection);
            panelCourseInfo.Controls.Add(lblCourse);
            panelCourseInfo.Controls.Add(cboCourse);
            panelCourseInfo.Controls.Add(lblDiscountType);
            panelCourseInfo.Controls.Add(cboDiscountType);
            panelCourseInfo.Controls.Add(lblDiscountValue);
            panelCourseInfo.Controls.Add(numDiscountValue);
            panelCourseInfo.Controls.Add(lblDiscountNote);
            panelCourseInfo.Location = new Point(15, 580);
            panelCourseInfo.Name = "panelCourseInfo";
            panelCourseInfo.Size = new Size(660, 190);
            panelCourseInfo.TabIndex = 11;
            // 
            // lblCourseSection
            // 
            lblCourseSection.AutoSize = true;
            lblCourseSection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCourseSection.ForeColor = Color.FromArgb(63, 81, 181);
            lblCourseSection.Location = new Point(15, 10);
            lblCourseSection.Name = "lblCourseSection";
            lblCourseSection.Size = new Size(196, 28);
            lblCourseSection.TabIndex = 0;
            lblCourseSection.Text = "Thông tin khóa học";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCourse.Location = new Point(15, 50);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(96, 23);
            lblCourse.TabIndex = 1;
            lblCourse.Text = "Khóa học *";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.Font = new Font("Segoe UI", 11F);
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(15, 78);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(620, 33);
            cboCourse.TabIndex = 10;
            // 
            // lblDiscountType
            // 
            lblDiscountType.AutoSize = true;
            lblDiscountType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiscountType.Location = new Point(15, 125);
            lblDiscountType.Name = "lblDiscountType";
            lblDiscountType.Size = new Size(132, 23);
            lblDiscountType.TabIndex = 2;
            lblDiscountType.Text = "Loại giảm giá *";
            // 
            // cboDiscountType
            // 
            cboDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDiscountType.Font = new Font("Segoe UI", 11F);
            cboDiscountType.FormattingEnabled = true;
            cboDiscountType.Items.AddRange(new object[] { "None", "FixedAmount", "Percentage" });
            cboDiscountType.Location = new Point(15, 153);
            cboDiscountType.Name = "cboDiscountType";
            cboDiscountType.Size = new Size(250, 33);
            cboDiscountType.TabIndex = 11;
            //cboDiscountType.SelectedIndexChanged += cboDiscountType_SelectedIndexChanged;
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiscountValue.Location = new Point(285, 125);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(136, 23);
            lblDiscountValue.TabIndex = 3;
            lblDiscountValue.Text = "Giá trị giảm giá";
            // 
            // numDiscountValue
            // 
            numDiscountValue.DecimalPlaces = 2;
            numDiscountValue.Font = new Font("Segoe UI", 11F);
            numDiscountValue.Location = new Point(285, 153);
            numDiscountValue.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDiscountValue.Name = "numDiscountValue";
            numDiscountValue.Size = new Size(200, 32);
            numDiscountValue.TabIndex = 12;
            // 
            // lblDiscountNote
            // 
            lblDiscountNote.AutoSize = true;
            lblDiscountNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDiscountNote.ForeColor = Color.Gray;
            lblDiscountNote.Location = new Point(500, 128);
            lblDiscountNote.Name = "lblDiscountNote";
            lblDiscountNote.Size = new Size(152, 60);
            lblDiscountNote.TabIndex = 4;
            lblDiscountNote.Text = "FixedAmount: VNĐ\r\nPercentage: %\r\nNone: Không giảm giá";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(245, 245, 245);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 785);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(700, 75);
            panelButtons.TabIndex = 12;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(117, 117, 117);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(560, 18);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 42);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "❌ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 125, 50);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(430, 18);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 42);
            btnSave.TabIndex = 13;
            btnSave.Text = "💾 Lưu";
            btnSave.UseVisualStyleBackColor = false;
            //btnSave.Click += btnSave_Click;
            // 
            // StudentAddEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(700, 860);
            Controls.Add(panelButtons);
            Controls.Add(panelCourseInfo);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(chkIsActive);
            Controls.Add(lblIsActive);
            Controls.Add(cboGender);
            Controls.Add(lblGender);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(lblDateOfBirth);
            Controls.Add(txtPhoneParents);
            Controls.Add(lblPhoneParents);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentAddEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm sinh viên vào lớp học";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCourseInfo.ResumeLayout(false);
            panelCourseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscountValue).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}