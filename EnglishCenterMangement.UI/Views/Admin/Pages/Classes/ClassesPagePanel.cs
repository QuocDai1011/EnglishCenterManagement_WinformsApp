using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using EnglishCenterManagement.Models.Services;
using EnglishCenterManagement.Models.Entities;
using Microsoft.VisualBasic.Logging;
using System.Threading.Tasks;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Classes
{
    public partial class ClassesPagePanel : BasePagePanel
    {
        public override string PageTitle => "Lớp học của tôi";
        private TextBox searchBox;
        private FlowLayoutPanel classesFlowPanel;
        private List<Class> allClasses;

        private readonly ServiceHub _service;

        public ClassesPagePanel(ServiceHub service)
        {
            _service = service;

            InitializeComponent();
            allClasses = getAllClass(); 
        }

        private List<Class> getAllClass()
        {
            return _service.ClassService.GetAllClasses().ToList();
           
        }

        protected override void LoadContent()
        {
            // Remove default padding
            contentPanel.Padding = new Padding(0);

            // Initialize class data
            //InitializeClassData();

            // Search bar container
            Panel searchContainer = new Panel
            {
                Location = new Point(40, 20),
                Size = new Size(300, 50),
                BackColor = Color.White
            };

            Panel searchBoxPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(240, 242, 245)
            };
            UIHelper.MakeRounded(searchBoxPanel, 25);

            // Search icon
            IconPictureBox searchIcon = new IconPictureBox
            {
                IconChar = IconChar.Search,
                IconColor = Color.Gray,
                IconSize = 20,
                Size = new Size(20, 20),
                Location = new Point(18, 15),
                BackColor = Color.Transparent
            };
            searchBoxPanel.Controls.Add(searchIcon);

            // Search textbox
            searchBox = new TextBox
            {
                Location = new Point(50, 13),
                Size = new Size(235, 24),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 11),
                Text = "Nhấn Enter để tìm kiếm",
                ForeColor = Color.Gray,
                BackColor = Color.FromArgb(240, 242, 245)
            };

            searchBox.GotFocus += (s, e) =>
            {
                if (searchBox.Text == "Nhấn Enter để tìm kiếm")
                {
                    searchBox.Text = "";
                    searchBox.ForeColor = Color.Black;
                }
            };

            searchBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchBox.Text))
                {
                    searchBox.Text = "Nhấn Enter để tìm kiếm";
                    searchBox.ForeColor = Color.Gray;
                }
            };

            searchBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FilterClasses(searchBox.Text);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            searchBoxPanel.Controls.Add(searchBox);
            searchContainer.Controls.Add(searchBoxPanel);
            contentPanel.Controls.Add(searchContainer);

            // Filter icon button (optional)
            Panel filterButton = new Panel
            {
                Location = new Point(360, 20),
                Size = new Size(50, 50),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            UIHelper.MakeRounded(filterButton, 8);

            IconPictureBox filterIcon = new IconPictureBox
            {
                IconChar = IconChar.Filter,
                IconColor = Color.FromArgb(65, 65, 65),
                IconSize = 24,
                Size = new Size(24, 24),
                Location = new Point(13, 13),
                BackColor = Color.Transparent
            };
            filterButton.Controls.Add(filterIcon);
            UIHelper.AddHoverEffect(filterButton, Color.FromArgb(240, 242, 245), Color.White);
            contentPanel.Controls.Add(filterButton);

            // Flow panel for class cards
            classesFlowPanel = new FlowLayoutPanel
            {
                Location = new Point(40, 90),
                Size = new Size(contentPanel.Width - 80, contentPanel.Height - 130),
                BackColor = Color.White,
                AutoScroll = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Padding = new Padding(0),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            contentPanel.Controls.Add(classesFlowPanel);

            // Load all classes
            LoadClassCards(allClasses);

            // Handle resize to recalculate card sizes
            contentPanel.Resize += (s, e) =>
            {
                classesFlowPanel.Size = new Size(contentPanel.Width - 80, contentPanel.Height - 130);
                RefreshClassCards();
            };
        }

        private void LoadClassCards(List<Class> classes)
        {
            classesFlowPanel.Controls.Clear();

            int cardWidth = CalculateCardWidth();

            foreach (var classInfo in classes)
            {
                Panel card = CreateClassCard(classInfo, cardWidth);
                classesFlowPanel.Controls.Add(card);
            }
        }

        private int CalculateCardWidth()
        {
            int availableWidth = classesFlowPanel.ClientSize.Width - 20; // minus scrollbar
            int spacing = 20; // khoảng cách giữa các card
            int cardWidth = (availableWidth - (spacing * 3)) / 4; // 4 columns với 20px gap

            // Đảm bảo card đủ lớn
            if (cardWidth < 280)
            {
                cardWidth = (availableWidth - spacing) / 3; // fallback to 3 columns
            }
            if (cardWidth < 280)
            {
                cardWidth = (availableWidth - spacing) / 2; // fallback to 2 columns
            }

            return cardWidth;
        }

        private void RefreshClassCards()
        {
            int newWidth = CalculateCardWidth();
            foreach (Control control in classesFlowPanel.Controls)
            {
                if (control is Panel card)
                {
                    card.Width = newWidth;
                }
            }
        }

        private Panel CreateClassCard(Class classInfo, int cardWidth)
        {
            Panel card = new Panel
            {
                Size = new Size(cardWidth, 420),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 20, 20),
                BorderStyle = BorderStyle.None // Remove default border
            };

            // Sử dụng MakeRoundedWithBorder thay vì BorderStyle
            UIHelper.MakeRoundedWithBorder(card, 12, Color.FromArgb(220, 220, 220), 1);

            string baseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\");
            string imagePath = Path.Combine(baseFolder, classInfo.pathImage);

            // Image/Thumbnail - tăng chiều cao
            PictureBox thumbnail = new PictureBox
            {
                Location = new Point(0, 0),
                Size = new Size(cardWidth, 240),
                Image = File.Exists(imagePath)
                        ? Image.FromFile(imagePath)
                        : Properties.Resources.defaultBanner2,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            //Add placeholder icon or image
           //IconPictureBox bookIcon = new IconPictureBox
           //{
           //    IconChar = IconChar.Book,
           //    IconColor = Color.White,
           //    IconSize = 72,
           //    Size = new Size(72, 72),
           //    Location = new Point((cardWidth - 72) / 2, 84),
           //    BackColor = Color.Transparent
           //};
           // thumbnail.Controls.Add(bookIcon);
            card.Controls.Add(thumbnail);

            // Price label
            //Label priceLabel = new Label
            //{
            //    Text = classInfo.Price,
            //    Location = new Point(20, 255),
            //    Size = new Size(cardWidth - 40, 40),
            //    Font = new Font("Segoe UI", 12, FontStyle.Bold),
            //    ForeColor = Color.FromArgb(50, 50, 50),
            //    TextAlign = ContentAlignment.TopLeft,
            //    AutoSize = false
            //};
            //card.Controls.Add(priceLabel);

            // Class name label
            Label nameLabel = new Label
            {
                Text = classInfo.ClassCode,
                Location = new Point(20, 300),
                Size = new Size(cardWidth - 40, 35),
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                TextAlign = ContentAlignment.TopLeft
            };
            card.Controls.Add(nameLabel);

            // Type label
            Label typeLabel = new Label
            {
                Text = "Loại khóa hoc: Lớp học",
                Location = new Point(20, 340),
                Size = new Size(cardWidth - 40, 30),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopLeft
            };
            card.Controls.Add(typeLabel);

            // Hover effect với border color change
            Color normalBorderColor = Color.FromArgb(220, 220, 220);
            Color hoverBorderColor = Color.FromArgb(180, 180, 180);

            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(248, 249, 250);
                // Redraw với border color mới
                card.Invalidate();
            };

            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                card.Invalidate();
            };

            // Click event
            card.Click += (s, e) => Card_Click(s,e, classInfo);
            thumbnail.Click += (s, e) => Card_Click(s, e, classInfo);
            //priceLabel.Click += (s, e) => MessageBox.Show($"Đã chọn lớp: {classInfo.Name}\nGiá: {classInfo.Price}");
            nameLabel.Click += (s, e) => Card_Click(s, e, classInfo);
            typeLabel.Click += (s, e) => Card_Click(s, e, classInfo);

            return card;
        }
        void Card_Click(object sender, EventArgs e, Class classObj)
        {
            contentPanel.Controls.Clear(); // Xóa các control hiện tại

        }
        private void FilterClasses(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || searchText == "Nhấn Enter để tìm kiếm")
            {
                LoadClassCards(allClasses);
                return;
            }

            var filteredClasses = allClasses.Where(c =>
                c.ClassCode.ToLower().Contains(searchText.ToLower())
            ).ToList();

            LoadClassCards(filteredClasses);
        }

    }
}