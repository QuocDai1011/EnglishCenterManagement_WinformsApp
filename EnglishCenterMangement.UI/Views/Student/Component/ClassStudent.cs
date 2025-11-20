using EnglishCenterManagement.Models.Entities;
using System.Drawing;

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public partial class ClassStudent : UserControl
    {
        public ClassStudent()
        {
            InitializeComponent();
        }

        public void SetData(Class c)
        {
            LabelClassName.Text = c.ClassName;
            LabelStudent.Text = $"{c.CurrentStudent}/{c.MaxStudent}";
            LabelDateCourse.Text = $"{c.StartDate:dd/MM/yyyy} - {c.EndDate:dd/MM/yyyy}";

            // Kiểm tra ngày kết thúc so với ngày hiện tại
            bool isActive = c.EndDate >= DateTime.Today; // còn hoạt động nếu EndDate >= hôm nay
            LabelStatus.Text = isActive ? "Đang hoạt động" : "Đã kết thúc";
            LabelStatus.ForeColor = isActive ? Color.Green : Color.Red;
        }
    }
}
