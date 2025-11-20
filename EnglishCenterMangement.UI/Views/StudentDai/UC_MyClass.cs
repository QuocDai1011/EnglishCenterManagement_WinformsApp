using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views.StudentDai
{
    public partial class UC_MyClass : UserControl
    {
        private readonly ILogger _logger;
        private readonly ServiceHub _serviceHub;
        private readonly int _teacherId;

        public UC_MyClass(ServiceHub serviceHub, int teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;

            LoadCourse();
        }


        private void LoadCourse()
        {
            flowPnContent.Controls.Clear();
            var classes = _serviceHub._classService.GetClassByIdTeacher(_teacherId);
            if (classes == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
            }
            flowPnContent.FlowDirection = FlowDirection.LeftToRight;
            foreach (var c in classes)
            {
                var course = _serviceHub._courseService.GetCourseByIdClass(c.ClassId);
                if (course == null)
                {
                    continue;
                }

                var courseCard = new UC_CourseCard(course, c);
                flowPnContent.Controls.Add(courseCard);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowPnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
        }
    }
}
