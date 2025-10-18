using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views
{
    public partial class IconCustom : UserControl
    {
        private IconPictureBox iconBox;
        public event EventHandler IconClick;

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    this.Size = new System.Drawing.Size(20, 20);
        //    this.ResumeLayout(false);
        //}

        public IconCustom()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return; // tránh lỗi khi đang mở Designer

            iconBox = new IconPictureBox
            {
                Dock = DockStyle.Fill,
                IconChar = IconChar.User,
                IconColor = Color.Gray,
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.Transparent
            };

            this.Controls.Add(iconBox);

            this.Padding = new Padding(0);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.None;

            iconBox.Click += IconBox_Click;
            this.Click += IconBox_Click;
        }

        public void ForceUpdateIcon(IconChar newIcon)
        {
            if (iconBox == null) return;
            iconBox.SuspendLayout();
            iconBox.IconChar = newIcon;
            iconBox.ResumeLayout();
            iconBox.Refresh();
            this.Refresh();
        }

        private void IconBox_Click(object sender, EventArgs e)
        {
            IconClick?.Invoke(this, e);
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Chọn icon muốn hiển thị")]
        public IconChar Icon
        {
            get => iconBox?.IconChar ?? IconChar.None;
            set
            {
                if (iconBox == null) return;
                if (iconBox.IconChar != value)
                {
                    iconBox.IconChar = value;
                    iconBox.Invalidate();
                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Màu của icon")]
        public Color IconColor
        {
            get => iconBox?.IconColor ?? Color.Gray;
            set
            {
                if (iconBox == null) return;
                iconBox.IconColor = value;
                iconBox.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Kích thước icon")]
        public int IconSize
        {
            get => iconBox?.IconSize ?? 16;
            set
            {
                if (iconBox == null) return;
                if (value <= 0) return; // tránh lỗi Designer

                iconBox.IconSize = value;
                this.Width = value + 10;
                this.Height = value + 10;
                iconBox.Invalidate();
            }
        }
    }
}
