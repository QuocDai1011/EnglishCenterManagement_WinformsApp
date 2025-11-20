using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.UI.Controllers;

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public partial class DetailStudent : UserControl
    {
        public DetailStudent()
        {
            InitializeComponent();
        }

        public void LoadDetailStudent(int id)
        {
            var studentController = new StudentController();
            var student = studentController.Get(id);
            string genderValue = student.Gender == true ? "Nam" : "Nữ";

            if (student == null) { throw new Exception(); }
            guna2HtmlLabelUserName.Text = student.UserName;
            guna2TextBoxFullName.Text = student.FullName;
            guna2TextBoxEmail.Text = student.Email;
            guna2TextBoxGender.Text = genderValue;
            guna2TextBoxDateBirth.Text = student.DateOfBirth.ToString();
            guna2TextBoxPhone.Text = student.PhoneNumber;
            guna2TextBoxPhoneParent.Text = student.PhoneNumberOfParents.ToString();
            guna2TextBoxAddress.Text = student.Address;
        }
    }
}
