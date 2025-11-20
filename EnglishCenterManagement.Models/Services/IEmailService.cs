using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services
{
    public interface IEmailService
    {
        void SendOtpEmail(string toEmail, string otp);
    }
}
