using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI
{
    public class UIHelper
    {
        /// <summary>
        /// Bo góc cho Panel với bán kính cho trước
        /// </summary>
        public static void SetPanelBorderRadius(Panel panel, int radius)
        {
            if (panel == null || radius <= 0)
                return;

            panel.Region = new Region(CreateRoundedRectanglePath(panel.ClientRectangle, radius));
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Góc trái trên
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Góc phải trên
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Góc phải dưới
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            // Góc trái dưới
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }

        public static void SetButtonRadius(Button btn, int radius)
        {
            Rectangle rect = btn.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Góc trái trên
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Góc phải trên
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Góc phải dưới
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            // Góc trái dưới
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            btn.Region = new Region(path);
        }


        public static void SetRoundedPictureBox(PictureBox pic, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(0, 0, radius, radius, 180, 90); // top-left
            path.AddArc(pic.Width - radius, 0, radius, radius, 270, 90); // top-right
            path.AddArc(pic.Width - radius, pic.Height - radius, radius, radius, 0, 90); // bottom-right
            path.AddArc(0, pic.Height - radius, radius, radius, 90, 90); // bottom-left
            path.CloseFigure();

            pic.Region = new Region(path);
        }


        public static void RoundIconPictureBox(IconPictureBox iconPic, int radius)
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = iconPic.ClientRectangle;

                int d = radius * 2;

                // Bo góc 4 phía
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseAllFigures();

                iconPic.Region = new Region(path);
            }
        }
}
