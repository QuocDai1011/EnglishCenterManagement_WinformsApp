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

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public partial class UC_Course : UserControl
    {
        public UC_Course()
        {
            InitializeComponent();
        }

        public void LoadCorse(Course c)
        {
            LabelNameCourse.Text = c.CourseName;
            LabelLession.Text = c.NumberSessions.ToString();
            LabelLevel.Text = c.level;
            LabelPrice.Text = c.TutitionFee.ToString();
        }
    }
}
