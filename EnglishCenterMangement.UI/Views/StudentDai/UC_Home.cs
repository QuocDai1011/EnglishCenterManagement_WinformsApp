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
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }
        

        private void btnCreatePosting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã nhấn vào nút tạo bài viết");
        }
    }
}
