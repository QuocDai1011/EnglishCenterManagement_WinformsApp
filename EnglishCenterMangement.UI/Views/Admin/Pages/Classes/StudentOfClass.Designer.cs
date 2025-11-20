namespace EnglishCenterMangement.UI.Views.Admin.Pages.Classes
{
    partial class StudentOfClass
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelActions;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblTotalStudents = new Label();
            panelActions = new Panel();
            searchBox = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnExport = new Button();
            dgvStudents = new DataGridView();
            colCourse = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colDateOfBirth = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            phoneNumberOfParent = new DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblTotalStudents);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 15, 20, 15);
            panelHeader.Size = new Size(1580, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(448, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh sách sinh viên - [Tên lớp]";
            // 
            // lblTotalStudents
            // 
            lblTotalStudents.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalStudents.Font = new Font("Segoe UI", 12F);
            lblTotalStudents.ForeColor = Color.FromArgb(117, 117, 117);
            lblTotalStudents.Location = new Point(1261, 25);
            lblTotalStudents.Name = "lblTotalStudents";
            lblTotalStudents.Size = new Size(299, 25);
            lblTotalStudents.TabIndex = 1;
            lblTotalStudents.Text = "Tổng số: 0 sinh viên";
            lblTotalStudents.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(250, 250, 250);
            panelActions.Controls.Add(searchBox);
            panelActions.Controls.Add(btnAdd);
            panelActions.Controls.Add(btnEdit);
            panelActions.Controls.Add(btnDelete);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(btnExport);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(0, 80);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(20, 15, 20, 15);
            panelActions.Size = new Size(1580, 70);
            panelActions.TabIndex = 1;
            // 
            // searchBox
            // 
            searchBox.Font = new Font("Segoe UI", 11F);
            searchBox.Location = new Point(20, 18);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "🔍 Tìm kiếm theo tên, email, SĐT...";
            searchBox.Size = new Size(350, 32);
            searchBox.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 125, 50);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(390, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(25, 118, 210);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Enabled = false;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(555, 15);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 38);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(211, 47, 47);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(690, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 38);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(117, 117, 117);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(825, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 38);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BackColor = Color.FromArgb(0, 150, 136);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1420, 15);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 38);
            btnExport.TabIndex = 5;
            btnExport.Text = "📥 Xuất Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AllowUserToResizeRows = false;
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.ColumnHeadersHeight = 45;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { colCourse, colFullName, colEmail, colPhone, colDateOfBirth, Gender, phoneNumberOfParent });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(232, 234, 246);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvStudents.DefaultCellStyle = dataGridViewCellStyle4;
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.GridColor = Color.FromArgb(224, 224, 224);
            dgvStudents.Location = new Point(20, 165);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvStudents.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 40;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1540, 315);
            dgvStudents.TabIndex = 2;
            // 
            // colCourse
            // 
            colCourse.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCourse.DataPropertyName = "colCourse";
            colCourse.FillWeight = 26.6317978F;
            colCourse.HeaderText = "Khóa học";
            colCourse.MinimumWidth = 6;
            colCourse.Name = "colCourse";
            colCourse.ReadOnly = true;
            colCourse.Width = 169;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 40F;
            colFullName.HeaderText = "Họ và tên";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 40F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Phone";
            colPhone.FillWeight = 33.2897453F;
            colPhone.HeaderText = "Số điện thoại";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colDateOfBirth
            // 
            colDateOfBirth.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            colDateOfBirth.DefaultCellStyle = dataGridViewCellStyle2;
            colDateOfBirth.FillWeight = 33.2897453F;
            colDateOfBirth.HeaderText = "Ngày sinh";
            colDateOfBirth.MinimumWidth = 6;
            colDateOfBirth.Name = "colDateOfBirth";
            colDateOfBirth.ReadOnly = true;
            // 
            // Gender
            // 
            Gender.FillWeight = 33.2897453F;
            Gender.HeaderText = "Giới tính";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            Gender.ReadOnly = true;
            // 
            // phoneNumberOfParent
            // 
            phoneNumberOfParent.DataPropertyName = "phoneNumberOfParent";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            phoneNumberOfParent.DefaultCellStyle = dataGridViewCellStyle3;
            phoneNumberOfParent.FillWeight = 36.61872F;
            phoneNumberOfParent.HeaderText = "Số điện thoại phụ huynh";
            phoneNumberOfParent.MinimumWidth = 6;
            phoneNumberOfParent.Name = "phoneNumberOfParent";
            phoneNumberOfParent.ReadOnly = true;
            // 
            // StudentOfClass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvStudents);
            Controls.Add(panelActions);
            Controls.Add(panelHeader);
            Name = "StudentOfClass";
            Size = new Size(1580, 500);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn colCourse;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colDateOfBirth;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn phoneNumberOfParent;
    }
}