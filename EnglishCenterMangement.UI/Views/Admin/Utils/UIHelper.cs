using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Utils
{
    public static class UIHelper
    {
        // Vẽ tròn cho control
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public static void MakeRounded(Control control, int radius)
        {
            IntPtr ptr = CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius);
            control.Region = Region.FromHrgn(ptr);
        }

        // Vẽ border bo góc tùy chỉnh
        public static void MakeRoundedWithBorder(Control control, int radius, Color borderColor, int borderWidth = 1)
        {
            // Remove BorderStyle nếu có
            if (control is Panel panel)
            {
                panel.BorderStyle = BorderStyle.None;
            }

            // Bo góc control
            MakeRounded(control, radius);

            // Thêm event vẽ border
            control.Paint += (s, e) =>
            {
                DrawRoundedBorder(e.Graphics, control.ClientRectangle, radius, borderColor, borderWidth);
            };

            // Refresh khi resize
            control.Resize += (s, e) =>
            {
                MakeRounded(control, radius);
                control.Invalidate();
            };
        }

        private static void DrawRoundedBorder(Graphics graphics, Rectangle bounds, int radius, Color borderColor, int borderWidth)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectPath(bounds, radius))
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ border
                graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // Top left arc
            path.AddArc(arc, 180, 90);

            // Top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Tạo button tròn với icon
        public static Button CreateRoundButton(string text, int x, int y, int size, Color bgColor)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(size, size),
                FlatStyle = FlatStyle.Flat,
                BackColor = bgColor,
                Font = new Font("Segoe UI", 12),
                Cursor = Cursors.Hand,
                ForeColor = Color.FromArgb(65, 65, 65)
            };
            btn.FlatAppearance.BorderSize = 0;
            MakeRounded(btn, size / 2);
            return btn;
        }

        // Thêm hiệu ứng hover cho button
        public static void AddHoverEffect(Button button, Color hoverColor, Color normalColor)
        {
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = normalColor;
        }

        // Thêm hiệu ứng hover cho panel
        public static void AddHoverEffect(Panel panel, Color hoverColor, Color normalColor)
        {
            panel.MouseEnter += (s, e) => panel.BackColor = hoverColor;
            panel.MouseLeave += (s, e) => panel.BackColor = normalColor;

            // Áp dụng cho tất cả controls con
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.MouseEnter += (s, e) => panel.BackColor = hoverColor;
                ctrl.MouseLeave += (s, e) => panel.BackColor = normalColor;
            }
        }

        // Tạo rounded panel
        public static Panel CreateRoundedPanel(int x, int y, int width, int height, int radius, Color bgColor)
        {
            Panel panel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = bgColor
            };
            MakeRounded(panel, radius);
            return panel;
        }

        // Tạo rounded panel với border
        public static Panel CreateRoundedPanelWithBorder(int x, int y, int width, int height, int radius, Color bgColor, Color borderColor, int borderWidth = 1)
        {
            Panel panel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = bgColor,
                BorderStyle = BorderStyle.None
            };
            MakeRoundedWithBorder(panel, radius, borderColor, borderWidth);
            return panel;
        }

        public static void SetFormBusy(Form form, bool isBusy)
        {
            form.Enabled = !isBusy;
            form.Cursor = isBusy ? Cursors.WaitCursor : Cursors.Default;
        }

        public static void SetControlsBusy(Control[] controls, bool isBusy)
        {
            foreach (var control in controls)
            {
                control.Enabled = !isBusy;
            }
        }

        public static void ClearTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        public static void ResetComboBoxes(params ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
        }
    }
}