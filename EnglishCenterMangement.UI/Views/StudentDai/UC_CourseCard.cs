using EnglishCenterManagement.Models.Entities;
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
    public partial class UC_CourseCard : UserControl
    {
        private Course _course;
        private Class _class;
        public UC_CourseCard(Course course, Class classTemp)
        {
            InitializeComponent();
            _course = course;
            _class = classTemp;
            RenderCourse();
        }

        private void RenderCourse()
        {
            lblClassCode.Text = $"{_course.CourseCode}";
            lblNumberOfStudent.Text = $"{_class.CurrentStudent}/{_class.MaxStudent}";
            lblStartDate.Text = _class.StartDate.ToString("dd/MM/yyyy");
            lblEndate.Text = _class.EndDate.ToString("dd/MM/yyyy");
            if (_class.Shift == 1)
            {
                lblHours.Text = "8:00";
            }
            else if (_class.Shift == 2)
            {
                lblHours.Text = "14:00";
            }
            else
            {
                lblHours.Text = "18:00";
            }
            if (_class.Status == false)
            {
                lblStatusValue.Text = "Đã kết thúc";
                lblStatusValue.ForeColor = Color.Red;
            }
            else
            {
                lblStatusValue.Text = "Đang hoạt động";
            }
        }

        private void UC_CourseCard_Load(object sender, EventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            
        }
    }
}
