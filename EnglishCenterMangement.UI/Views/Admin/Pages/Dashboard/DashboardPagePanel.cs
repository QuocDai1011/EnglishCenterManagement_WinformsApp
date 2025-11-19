using EnglishCenterManagement.Models.Services;
using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Dashboard
{
    public partial class DashboardPagePanel : BasePagePanel
    {
        public override string PageTitle => "DashBoard";

        private readonly IClassService _classService;
        public DashboardPagePanel(IClassService classService)
        {
            InitializeComponent();
            _classService = classService;
        }

        protected override void LoadContent()
        {
            contentPanel.Padding = new Padding(0);
            contentPanel.AutoScroll = true;

            CreateTitleSection();
            CreateStatCards();
            CreateChartSection();
            CreateRevenueChart();
            CreatePieChartAndProgress();
            CreateRecentActivities();

            contentPanel.Resize += ContentPanel_Resize;
        }

        #region Title Section

        private void CreateTitleSection()
        {
            Label titleLabel = new Label
            {
                Text = "Tổng quan hệ thống",
                Location = new Point(0, 0),
                Size = new Size(contentPanel.Width, 40),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            contentPanel.Controls.Add(titleLabel);
        }

        #endregion

        #region Statistics Cards

        private void CreateStatCards()
        {
            int cardWidth = (contentPanel.Width - 45) / 4;
            int yPos = 60;

            CreateStatCard("Tổng học viên", "1,234", "+12% so với tháng trước",
                IconChar.UserGraduate, Color.FromArgb(52, 152, 219), 0, yPos, cardWidth);

            CreateStatCard("Lớp học", "48", "12 lớp đang mở đăng ký",
                IconChar.Chalkboard, Color.FromArgb(46, 204, 113), cardWidth + 15, yPos, cardWidth);

            CreateStatCard("Doanh thu", "2.5 tỷ", "+18% so với tháng trước",
                IconChar.MoneyBill, Color.FromArgb(241, 196, 15), (cardWidth + 15) * 2, yPos, cardWidth);

            CreateStatCard("Giáo viên", "78", "5 giáo viên mới tháng này",
                IconChar.ChalkboardTeacher, Color.FromArgb(155, 89, 182), (cardWidth + 15) * 3, yPos, cardWidth);
        }

        private void CreateStatCard(string label, string value, string subtitle, IconChar icon, Color bgColor, int x, int y, int width)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, 120),
                BackColor = bgColor
            };
            UIHelper.MakeRounded(card, 12);

            IconPictureBox iconBox = new IconPictureBox
            {
                IconChar = icon,
                IconColor = Color.White,
                IconSize = 35,
                Size = new Size(35, 35),
                Location = new Point(width - 50, 15),
                BackColor = Color.Transparent
            };
            card.Controls.Add(iconBox);

            Label valueLabel = new Label
            {
                Text = value,
                Location = new Point(20, 15),
                Size = new Size(width - 85, 40),
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false
            };
            card.Controls.Add(valueLabel);

            Label labelText = new Label
            {
                Text = label,
                Location = new Point(20, 58),
                Size = new Size(width - 40, 28),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false
            };
            card.Controls.Add(labelText);

            Label subtitleLabel = new Label
            {
                Text = subtitle,
                Location = new Point(20, 88),
                Size = new Size(width - 40, 25),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(240, 240, 240),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false
            };
            card.Controls.Add(subtitleLabel);

            contentPanel.Controls.Add(card);
        }

        #endregion

        #region Chart Section

        private void CreateChartSection()
        {
            Label chartTitle = new Label
            {
                Text = "Biểu đồ thống kê",
                Location = new Point(0, 200),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            contentPanel.Controls.Add(chartTitle);
        }

        #endregion

        #region Revenue Bar Chart

        private void CreateRevenueChart()
        {
            Panel chartPanel = new Panel
            {
                Location = new Point(0, 250),
                Size = new Size((contentPanel.Width - 15) / 2, 300),
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            UIHelper.MakeRoundedWithBorder(chartPanel, 12, Color.FromArgb(220, 220, 220), 1);

            Label chartTitle = new Label
            {
                Text = "Doanh thu theo tháng (triệu VNĐ)",
                Location = new Point(20, 15),
                Size = new Size(chartPanel.Width - 40, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            chartPanel.Controls.Add(chartTitle);

            string[] months = { "T1", "T2", "T3", "T4", "T5", "T6" };
            int[] revenues = { 180, 220, 250, 280, 300, 250 };

            chartPanel.Paint += (s, e) => DrawBarChart(e.Graphics, chartPanel, months, revenues);

            contentPanel.Controls.Add(chartPanel);
        }

        private void DrawBarChart(Graphics g, Panel panel, string[] labels, int[] values)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int chartX = 50;
            int chartY = 60;
            int chartWidth = panel.Width - 80;
            int chartHeight = panel.Height - 100;

            int maxValue = values.Max();

            using (Pen axisPen = new Pen(Color.FromArgb(200, 200, 200), 2))
            {
                g.DrawLine(axisPen, chartX, chartY + chartHeight, chartX + chartWidth, chartY + chartHeight);
                g.DrawLine(axisPen, chartX, chartY, chartX, chartY + chartHeight);
            }

            int barWidth = chartWidth / (labels.Length * 2);
            Color[] barColors = {
                Color.FromArgb(52, 152, 219), Color.FromArgb(46, 204, 113),
                Color.FromArgb(241, 196, 15), Color.FromArgb(155, 89, 182),
                Color.FromArgb(231, 76, 60), Color.FromArgb(52, 152, 219)
            };

            for (int i = 0; i < labels.Length; i++)
            {
                int barHeight = (int)((double)values[i] / maxValue * chartHeight);
                int x = chartX + (i * 2 + 1) * barWidth;
                int y = chartY + chartHeight - barHeight;

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(x, y, barWidth, barHeight),
                    barColors[i],
                    Color.FromArgb(barColors[i].A,
                        Math.Min(255, barColors[i].R + 30),
                        Math.Min(255, barColors[i].G + 30),
                        Math.Min(255, barColors[i].B + 30)),
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }

                using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
                {
                    string valueText = values[i].ToString();
                    SizeF textSize = g.MeasureString(valueText, font);
                    g.DrawString(valueText, font, textBrush,
                        x + (barWidth - textSize.Width) / 2,
                        y - textSize.Height - 5);
                }

                using (Font font = new Font("Segoe UI", 9))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(100, 100, 100)))
                {
                    SizeF textSize = g.MeasureString(labels[i], font);
                    g.DrawString(labels[i], font, textBrush,
                        x + (barWidth - textSize.Width) / 2,
                        chartY + chartHeight + 10);
                }
            }
        }

        #endregion

        #region Pie Chart

        private void CreatePieChartAndProgress()
        {
            Panel piePanel = new Panel
            {
                Location = new Point((contentPanel.Width - 15) / 2 + 15, 250),
                Size = new Size((contentPanel.Width - 15) / 2, 300),
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            UIHelper.MakeRoundedWithBorder(piePanel, 12, Color.FromArgb(220, 220, 220), 1);

            Label pieTitle = new Label
            {
                Text = "Phân bố học viên theo trình độ",
                Location = new Point(20, 15),
                Size = new Size(piePanel.Width - 40, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };
            piePanel.Controls.Add(pieTitle);

            string[] categories = { "Beginner", "Intermediate", "Advanced", "IELTS" };
            int[] studentCounts = { 450, 380, 250, 154 };
            Color[] pieColors = {
                Color.FromArgb(52, 152, 219), Color.FromArgb(46, 204, 113),
                Color.FromArgb(241, 196, 15), Color.FromArgb(155, 89, 182)
            };

            piePanel.Paint += (s, e) => DrawPieChart(e.Graphics, piePanel, categories, studentCounts, pieColors);

            contentPanel.Controls.Add(piePanel);
        }

        private void DrawPieChart(Graphics g, Panel panel, string[] labels, int[] values, Color[] colors)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int total = values.Sum();
            int pieSize = 160;
            int pieX = (panel.Width - pieSize) / 2 - 50;
            int pieY = 60;

            Rectangle pieRect = new Rectangle(pieX, pieY, pieSize, pieSize);
            float startAngle = 0;

            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = (float)values[i] / total * 360;

                using (SolidBrush brush = new SolidBrush(colors[i]))
                {
                    g.FillPie(brush, pieRect, startAngle, sweepAngle);
                }

                using (Pen pen = new Pen(Color.White, 2))
                {
                    g.DrawPie(pen, pieRect, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
            }

            int legendX = pieX + pieSize + 30;
            int legendY = pieY + 20;

            for (int i = 0; i < labels.Length; i++)
            {
                using (SolidBrush brush = new SolidBrush(colors[i]))
                {
                    g.FillRectangle(brush, legendX, legendY + i * 35, 20, 20);
                }

                float percentage = (float)values[i] / total * 100;
                string text = $"{labels[i]} ({percentage:F1}%)";

                using (Font font = new Font("Segoe UI", 9))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
                {
                    g.DrawString(text, font, textBrush, legendX + 30, legendY + i * 35);
                }

                using (Font font = new Font("Segoe UI", 8))
                using (SolidBrush textBrush = new SolidBrush(Color.Gray))
                {
                    g.DrawString($"{values[i]} học viên", font, textBrush, legendX + 30, legendY + i * 35 + 15);
                }
            }
        }

        #endregion

        #region Recent Activities

        private void CreateRecentActivities()
        {
            Label activitiesTitle = new Label
            {
                Text = "Hoạt động gần đây",
                Location = new Point(0, 570),
                Size = new Size(contentPanel.Width, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            contentPanel.Controls.Add(activitiesTitle);

            string[] activities = {
                "Học viên Nguyễn Văn A đã đăng ký khóa học IELTS Advanced",
                "Giáo viên Trần Thị B đã tạo bài kiểm tra giữa kỳ cho lớp English 101",
                "Lớp học Business English đã hoàn thành buổi học số 15",
                "Học viên Lê Văn C đã đạt điểm 8.0 IELTS",
                "5 học viên mới đã đăng ký khóa học Beginner"
            };

            IconChar[] icons = {
                IconChar.UserPlus, IconChar.FilePen, IconChar.CheckCircle,
                IconChar.Trophy, IconChar.Users
            };

            int activityY = 620;
            for (int i = 0; i < activities.Length; i++)
            {
                CreateActivityItem(activities[i], icons[i], activityY);
                activityY += 80;
            }
        }

        private void CreateActivityItem(string text, IconChar icon, int y)
        {
            Panel item = new Panel
            {
                Location = new Point(0, y),
                Size = new Size(contentPanel.Width, 70),
                BackColor = Color.FromArgb(248, 249, 250),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            UIHelper.MakeRounded(item, 10);

            Panel iconBg = new Panel
            {
                Location = new Point(15, 15),
                Size = new Size(40, 40),
                BackColor = Color.FromArgb(52, 152, 219)
            };
            UIHelper.MakeRounded(iconBg, 20);

            IconPictureBox iconBox = new IconPictureBox
            {
                IconChar = icon,
                IconColor = Color.White,
                IconSize = 20,
                Size = new Size(20, 20),
                Location = new Point(10, 10),
                BackColor = Color.Transparent
            };
            iconBg.Controls.Add(iconBox);
            item.Controls.Add(iconBg);

            Label timeLabel = new Label
            {
                Text = "5 phút trước",
                Location = new Point(70, 18),
                Size = new Size(item.Width - 90, 18),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            item.Controls.Add(timeLabel);

            Label activityLabel = new Label
            {
                Text = text,
                Location = new Point(70, 38),
                Size = new Size(item.Width - 90, 25),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            item.Controls.Add(activityLabel);

            contentPanel.Controls.Add(item);
        }

        #endregion

        #region Resize Handler

        private void ContentPanel_Resize(object sender, EventArgs e)
        {
            UpdateChartsWidth();
        }

        private void UpdateChartsWidth()
        {
            int cardWidth = (contentPanel.Width - 45) / 4;
            int yPos = 60;

            var statCards = contentPanel.Controls.OfType<Panel>()
                .Where(p => p.Location.Y == yPos).ToList();

            foreach (var card in statCards)
            {
                contentPanel.Controls.Remove(card);
                card.Dispose();
            }

            CreateStatCards();

            foreach (Control ctrl in contentPanel.Controls)
            {
                if (ctrl is Panel panel && panel.Location.Y == 250)
                {
                    if (panel.Location.X == 0)
                    {
                        panel.Width = (contentPanel.Width - 15) / 2;
                    }
                    else
                    {
                        panel.Location = new Point((contentPanel.Width - 15) / 2 + 15, 250);
                        panel.Width = (contentPanel.Width - 15) / 2;
                    }
                    panel.Invalidate();
                }
            }
        }

        #endregion
    }
}