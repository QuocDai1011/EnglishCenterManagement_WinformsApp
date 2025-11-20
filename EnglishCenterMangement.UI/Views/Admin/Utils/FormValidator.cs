using EnglishCenterManagement.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterMangement.UI.Views.Admin.Utils
{
    public class FormValidator
    {
        public static bool ValidateStudentForm(
            string userName,
            string password,
            string fullName,
            string email,
            string phone,
            string phoneParents,
            DateTime dateOfBirth,
            int genderIndex,
            int courseIndex,
            int discountTypeIndex,
            decimal discountValue,
            out string errorMessage)
        {
            StringBuilder errors = new StringBuilder();

            // Username
            if (string.IsNullOrWhiteSpace(userName))
                errors.AppendLine("• " + ErrorMessages.REQUIRED_USERNAME);
            else if (!ValidationUtils.IsValidUserName(userName))
                errors.AppendLine("• " + ErrorMessages.INVALID_USERNAME);

            // Password
            if (string.IsNullOrWhiteSpace(password))
                errors.AppendLine("• " + ErrorMessages.REQUIRED_PASSWORD);
            else if (!ValidationUtils.IsValidPassword(password))
                errors.AppendLine("• " + ErrorMessages.INVALID_PASSWORD);

            // Full Name
            if (string.IsNullOrWhiteSpace(fullName))
                errors.AppendLine("• " + ErrorMessages.REQUIRED_FULLNAME);
            else if (!ValidationUtils.IsValidFullName(fullName))
                errors.AppendLine("• " + ErrorMessages.INVALID_FULLNAME);

            // Email
            if (string.IsNullOrWhiteSpace(email))
                errors.AppendLine("• " + ErrorMessages.REQUIRED_EMAIL);
            else if (!ValidationUtils.IsValidEmail(email))
                errors.AppendLine("• " + ErrorMessages.INVALID_EMAIL);

            // Phone
            if (string.IsNullOrWhiteSpace(phone))
                errors.AppendLine("• " + ErrorMessages.REQUIRED_PHONE);
            else if (!ValidationUtils.IsValidPhone(phone))
                errors.AppendLine("• " + ErrorMessages.INVALID_PHONE);

            // Parent Phone (optional)
            if (!string.IsNullOrWhiteSpace(phoneParents) && !ValidationUtils.IsValidPhone(phoneParents))
                errors.AppendLine("• Số điện thoại phụ huynh không hợp lệ!");

            // Date of Birth
            if (dateOfBirth > DateTime.Now)
                errors.AppendLine("• Ngày sinh không thể là ngày trong tương lai!");
            else
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now < dateOfBirth.AddYears(age)) age--;

                if (age < 5)
                    errors.AppendLine("• Học viên phải từ 5 tuổi trở lên!");
                else if (age > 100)
                    errors.AppendLine("• Tuổi học viên không hợp lệ!");
            }

            // Gender
            if (genderIndex < 0)
                errors.AppendLine("• Vui lòng chọn giới tính!");

            // Course
            if (courseIndex < 0)
                errors.AppendLine("• Vui lòng chọn khóa học!");

            // Discount
            if (discountTypeIndex < 0)
                errors.AppendLine("• Vui lòng chọn loại giảm giá!");

            errorMessage = errors.ToString();
            return errors.Length == 0;
        }
    }
}
