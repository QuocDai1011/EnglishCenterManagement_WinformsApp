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

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Classes
{
    public partial class StudentOfClass : UserControl
    {
        private Class _classes;
        public StudentOfClass(Class classes)
        {
            InitializeComponent();
            _classes = classes;
        }
    }
}
