using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterMangement.UI.UIHelper
{
    public class RoundedButton : Button
    {
        public float BorderRadius { get; set; } = 18f;
        public float BorderThickness { get; set; } = 1.5f;
        public Color BorderColor { get; set; } = Color.Transparent;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Orange;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            DoubleBuffered = true; // Giảm nhấp nháy
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float width = this.ClientSize.Width;
            float height = this.ClientSize.Height;
            float radius = BorderRadius;

            using (GraphicsPath path = CreateRoundedPath(width, height, radius))
            {
                // Gán vùng bo góc
                this.Region = new Region(path);

                // Nền
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Viền
                if (BorderThickness > 0f && BorderColor != Color.Transparent)
                {
                    using (Pen pen = new Pen(BorderColor, BorderThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                // Text ở giữa, không bị nhòe
                TextRenderer.DrawText(
                    e.Graphics,
                    this.Text,
                    this.Font,
                    Rectangle.Round(new RectangleF(0, 0, width, height)),
                    this.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

            }
        }

        private GraphicsPath CreateRoundedPath(float w, float h, float r)
        {
            GraphicsPath path = new GraphicsPath();
            float d = r * 2f;

            path.StartFigure();
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(w - d - 1, 0, d, d, 270, 90);
            path.AddArc(w - d - 1, h - d - 1, d, d, 0, 90);
            path.AddArc(0, h - d - 1, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
