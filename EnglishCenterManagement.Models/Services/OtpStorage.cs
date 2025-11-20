using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services
{
    public static class OtpStorage
    {
        public static string CurrentOtp { get; set; } = string.Empty;
        public static string CurrentEmail { get; set; } = string.Empty;
        public static DateTime? ExpireAt { get; set; }
        public static int AttemptCount { get; set; } = 0;

        public static void Clear()
        {
            CurrentOtp = string.Empty;
            CurrentEmail = string.Empty;
            ExpireAt = null;
            AttemptCount = 0;
        }
    }
}
