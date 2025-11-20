using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services
{
    public class EmailService : IEmailService
    {
        public void SendOtpEmail(string toEmail, string otp)
        {
            string fromEmail = "6451071022@st.utc2.edu.vn";  // email gửi
            string password = "gqyy jlnz pkuf mtsm";          // App Password Gmail

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(toEmail);
            mail.Subject = "Mã OTP để đặt lại mật khẩu";
            mail.Body = $"Mã OTP của bạn là: {otp}";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
