using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.UIHelper
{
    public class RoundedTextBox : UserControl
    {
        private TextBox textBox = new TextBox();
        public int BorderRadius { get; set; } = 15;
        public int BorderSize { get; set; } = 2;
        public Color BorderColor { get; set; } = Color.Gray;
        public Color BorderFocusColor { get; set; } = Color.DodgerBlue;

        private bool isFocused = false;

        public string Texts
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        

        public RoundedTextBox()
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = new Point(10, 7);
            textBox.Width = this.Width - 20;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.TextChanged += (s, e) => this.OnTextChanged(e);
            textBox.GotFocus += (s, e) => { isFocused = true; this.Invalidate(); };
            textBox.LostFocus += (s, e) => { isFocused = false; this.Invalidate(); };

            this.Controls.Add(textBox);
            this.Padding = new Padding(10);
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Resize += (s, e) => AdjustTextBoxHeight();
        }

        private void AdjustTextBoxHeight()
        {
            if (textBox.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, txtHeight);
                textBox.Multiline = false;
                this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectF = new RectangleF(0.5f, 0.5f, this.Width - 1f, this.Height - 1f);

            using (GraphicsPath path = GetRoundedPath(rectF, BorderRadius))
            using (Pen pen = new Pen(isFocused ? BorderFocusColor : BorderColor, BorderSize))
            {
                this.Region = new Region(path);
                e.Graphics.DrawPath(pen, path);
            }
        }


        private GraphicsPath GetRoundedPath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
