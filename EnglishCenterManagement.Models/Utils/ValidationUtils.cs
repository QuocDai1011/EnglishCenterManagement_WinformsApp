using System.Text.RegularExpressions;

namespace EnglishCenterManagement.Models.Utils
{
    public static class ValidationUtils
    {
        // Validate email
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string pattern = @"^[\w\.\-]+@[\w\-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        // Validate họ và tên (không chứa số, không ký tự đặc biệt)
        public static bool IsValidFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return false;

            string pattern = @"^[A-Za-zÀ-ỹ\s]{2,50}$";
            return Regex.IsMatch(fullName, pattern);
        }

        // Validate số điện thoại VN (10 số, bắt đầu từ 03,05,07,08,09)
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            string pattern = @"^(03|05|07|08|09)[0-9]{8}$";
            return Regex.IsMatch(phone, pattern);
        }

        // Validate CCCD (12 số)
        public static bool IsValidCCCD(string cccd)
        {
            if (string.IsNullOrWhiteSpace(cccd)) return false;

            string pattern = @"^[0-9]{12}$";
            return Regex.IsMatch(cccd, pattern);
        }

        // Validate Username (không dấu, không khoảng trắng)
        public static bool IsValidUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            string pattern = @"^[a-zA-Z0-9_]{4,30}$";
            return Regex.IsMatch(username, pattern);
        }

        // Validate Password (tối thiểu 6 ký tự)
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }
}
