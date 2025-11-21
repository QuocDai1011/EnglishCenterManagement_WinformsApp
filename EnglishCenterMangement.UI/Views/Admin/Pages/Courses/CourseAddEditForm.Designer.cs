// ========== CourseAddEditForm.Designer.cs ==========
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Courses
{
    partial class CourseAddEditForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.gbCourseInfo = new System.Windows.Forms.GroupBox();
            this.txtCourseCode = new System.Windows.Forms.TextBox();
            this.lblCourseCode = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.numTuitionFee = new System.Windows.Forms.NumericUpDown();
            this.lblTuitionFee = new System.Windows.Forms.Label();
            this.numNumberSessions = new System.Windows.Forms.NumericUpDown();
            this.lblNumberSessions = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtAvatarLink = new System.Windows.Forms.TextBox();
            this.lblAvatarLink = new System.Windows.Forms.Label();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbCourseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTuitionFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberSessions)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(700, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm Khóa Học Mới";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Controls.Add(this.gbCourseInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBody.Size = new System.Drawing.Size(700, 490);
            this.pnlBody.TabIndex = 1;
            // 
            // gbCourseInfo
            // 
            this.gbCourseInfo.Controls.Add(this.btnBrowseImage);
            this.gbCourseInfo.Controls.Add(this.txtAvatarLink);
            this.gbCourseInfo.Controls.Add(this.lblAvatarLink);
            this.gbCourseInfo.Controls.Add(this.txtDescription);
            this.gbCourseInfo.Controls.Add(this.lblDescription);
            this.gbCourseInfo.Controls.Add(this.cboLevel);
            this.gbCourseInfo.Controls.Add(this.lblLevel);
            this.gbCourseInfo.Controls.Add(this.numNumberSessions);
            this.gbCourseInfo.Controls.Add(this.lblNumberSessions);
            this.gbCourseInfo.Controls.Add(this.numTuitionFee);
            this.gbCourseInfo.Controls.Add(this.lblTuitionFee);
            this.gbCourseInfo.Controls.Add(this.txtCourseName);
            this.gbCourseInfo.Controls.Add(this.lblCourseName);
            this.gbCourseInfo.Controls.Add(this.txtCourseCode);
            this.gbCourseInfo.Controls.Add(this.lblCourseCode);
            this.gbCourseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCourseInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbCourseInfo.Location = new System.Drawing.Point(20, 20);
            this.gbCourseInfo.Name = "gbCourseInfo";
            this.gbCourseInfo.Padding = new System.Windows.Forms.Padding(15);
            this.gbCourseInfo.Size = new System.Drawing.Size(660, 450);
            this.gbCourseInfo.TabIndex = 0;
            this.gbCourseInfo.TabStop = false;
            this.gbCourseInfo.Text = "Thông tin khóa học";
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCourseCode.Location = new System.Drawing.Point(180, 40);
            this.txtCourseCode.MaxLength = 20;
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(450, 25);
            this.txtCourseCode.TabIndex = 1;
            // 
            // lblCourseCode
            // 
            this.lblCourseCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCourseCode.Location = new System.Drawing.Point(20, 40);
            this.lblCourseCode.Name = "lblCourseCode";
            this.lblCourseCode.Size = new System.Drawing.Size(150, 25);
            this.lblCourseCode.TabIndex = 0;
            this.lblCourseCode.Text = "Mã khóa học: *";
            this.lblCourseCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCourseName.Location = new System.Drawing.Point(180, 80);
            this.txtCourseName.MaxLength = 200;
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(450, 25);
            this.txtCourseName.TabIndex = 3;
            // 
            // lblCourseName
            // 
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCourseName.Location = new System.Drawing.Point(20, 80);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(150, 25);
            this.lblCourseName.TabIndex = 2;
            this.lblCourseName.Text = "Tên khóa học: *";
            this.lblCourseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTuitionFee
            // 
            this.numTuitionFee.DecimalPlaces = 0;
            this.numTuitionFee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTuitionFee.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTuitionFee.Location = new System.Drawing.Point(180, 120);
            this.numTuitionFee.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTuitionFee.Name = "numTuitionFee";
            this.numTuitionFee.Size = new System.Drawing.Size(200, 25);
            this.numTuitionFee.TabIndex = 5;
            this.numTuitionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTuitionFee.ThousandsSeparator = true;
            // 
            // lblTuitionFee
            // 
            this.lblTuitionFee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTuitionFee.Location = new System.Drawing.Point(20, 120);
            this.lblTuitionFee.Name = "lblTuitionFee";
            this.lblTuitionFee.Size = new System.Drawing.Size(150, 25);
            this.lblTuitionFee.TabIndex = 4;
            this.lblTuitionFee.Text = "Học phí (VNĐ): *";
            this.lblTuitionFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNumberSessions
            // 
            this.numNumberSessions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numNumberSessions.Location = new System.Drawing.Point(180, 160);
            this.numNumberSessions.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numNumberSessions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberSessions.Name = "numNumberSessions";
            this.numNumberSessions.Size = new System.Drawing.Size(200, 25);
            this.numNumberSessions.TabIndex = 7;
            this.numNumberSessions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNumberSessions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberSessions
            // 
            this.lblNumberSessions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNumberSessions.Location = new System.Drawing.Point(20, 160);
            this.lblNumberSessions.Name = "lblNumberSessions";
            this.lblNumberSessions.Size = new System.Drawing.Size(150, 25);
            this.lblNumberSessions.TabIndex = 6;
            this.lblNumberSessions.Text = "Số buổi học: *";
            this.lblNumberSessions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Items.AddRange(new object[] {
            "Beginner",
            "Elementary",
            "Intermediate",
            "Upper Intermediate",
            "Advanced",
            "Proficiency"});
            this.cboLevel.Location = new System.Drawing.Point(180, 200);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(200, 25);
            this.cboLevel.TabIndex = 9;
            // 
            // lblLevel
            // 
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLevel.Location = new System.Drawing.Point(20, 200);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(150, 25);
            this.lblLevel.TabIndex = 8;
            this.lblLevel.Text = "Trình độ: *";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(180, 240);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(450, 100);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(20, 240);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(150, 25);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Mô tả:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAvatarLink
            // 
            this.txtAvatarLink.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAvatarLink.Location = new System.Drawing.Point(180, 360);
            this.txtAvatarLink.MaxLength = 500;
            this.txtAvatarLink.Name = "txtAvatarLink";
            this.txtAvatarLink.Size = new System.Drawing.Size(350, 25);
            this.txtAvatarLink.TabIndex = 13;
            // 
            // lblAvatarLink
            // 
            this.lblAvatarLink.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAvatarLink.Location = new System.Drawing.Point(20, 360);
            this.lblAvatarLink.Name = "lblAvatarLink";
            this.lblAvatarLink.Size = new System.Drawing.Size(150, 25);
            this.lblAvatarLink.TabIndex = 12;
            this.lblAvatarLink.Text = "Ảnh đại diện:";
            this.lblAvatarLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.White;
            this.btnBrowseImage.Location = new System.Drawing.Point(540, 360);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(90, 25);
            this.btnBrowseImage.TabIndex = 14;
            this.btnBrowseImage.Text = "Chọn ảnh...";
            this.btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 550);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(700, 70);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(400, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(550, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // CourseAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 620);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý khóa học";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.gbCourseInfo.ResumeLayout(false);
            this.gbCourseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTuitionFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberSessions)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox gbCourseInfo;
        private System.Windows.Forms.TextBox txtCourseCode;
        private System.Windows.Forms.Label lblCourseCode;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.NumericUpDown numTuitionFee;
        private System.Windows.Forms.Label lblTuitionFee;
        private System.Windows.Forms.NumericUpDown numNumberSessions;
        private System.Windows.Forms.Label lblNumberSessions;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtAvatarLink;
        private System.Windows.Forms.Label lblAvatarLink;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}