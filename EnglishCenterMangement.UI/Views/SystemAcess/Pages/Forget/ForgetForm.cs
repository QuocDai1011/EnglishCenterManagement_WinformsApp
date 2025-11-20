using EnglishCenterManagement.Models.Services;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace EnglishCenterManagement.UI.Views.SystemAcess.Pages.ForgetForm
{
    public partial class ForgetForm : Form
    {
        private readonly IEmailService _emailService;
        private readonly string jsonFilePath = "appsettings.json";
        public ForgetForm()
        {
            InitializeComponent();
            _emailService = new EmailService();
        }

        private void ForgetForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();
                if (ctl is Guna2TextBox gtb)
                {
                    gtb.MaxLength = 1;
                    gtb.TextAlign = HorizontalAlignment.Center;
                    gtb.KeyDown += Txb_KeyDown;
                }
            }

            this.Controls.Find("txbOTPcode0", true).FirstOrDefault()?.Focus();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string email = txbCurrentEmail.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            string otp = new Random().Next(100000, 999999).ToString();

            OtpStorage.CurrentOtp = otp;
            OtpStorage.CurrentEmail = email;
            OtpStorage.ExpireAt = DateTime.UtcNow.AddMinutes(2); 
            OtpStorage.AttemptCount = 0;
            try
            {
                _emailService.SendOtpEmail(email, otp);
                MessageBox.Show("Mã OTP đã được gửi vào email của bạn.");
                pnB2.Visible = true;
                pnB1.Visible = false;
                this.Controls.Find("txbOTPcode0", true).FirstOrDefault()?.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi email thất bại: " + ex.Message);
                //OtpStorage.Clear();
            }
        }
        private void otpClear()
        {
            for (int i = 0; i < 6; i++)
            {
                var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault() as TextBox;
                if (ctl != null)
                    ctl.Text = ""; // Set rỗng
            }
        }
        private void Txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string clipboardText = Clipboard.GetText().Trim();
                if (clipboardText.Length == 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();
                        if (ctl is Guna2TextBox gtb)
                            gtb.Text = clipboardText[i].ToString();
                    }
                }
                e.Handled = true;
                return;
            }
            if (sender is Guna2TextBox current)
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (string.IsNullOrEmpty(current.Text))
                    {
                        var name = current.Name;
                        if (name.StartsWith("txbOTPcode"))
                        {
                            if (int.TryParse(name.Substring("txbOTPcode".Length), out int idx) && idx > 0)
                            {
                                var prev = this.Controls.Find("txbOTPcode" + (idx - 1), true).FirstOrDefault() as Guna2TextBox;
                                prev?.Focus();
                            }
                        }
                    }
                }
                else
                {
                    if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            var name = current.Name;
                            if (name.StartsWith("txbOTPcode"))
                            {
                                if (int.TryParse(name.Substring("txbOTPcode".Length), out int idx) && idx < 5)
                                {
                                    var next = this.Controls.Find("txbOTPcode" + (idx + 1), true).FirstOrDefault() as Guna2TextBox;
                                    next?.Focus();
                                }
                            }
                        }));
                    }
                }
            }
        }

        private void btnConfirmOPT_Click(object sender, EventArgs e)
        {
            string inputOtp = "";
            for (int i = 0; i < 6; i++)
            {
                Control ctl = null;
                if (guna2Panel2 != null)
                    ctl = guna2Panel2.Controls.Find("txbOTPcode" + i, false).FirstOrDefault();
                if (ctl == null)
                    ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();

                if (ctl is Guna2TextBox gtb)
                    inputOtp += gtb.Text.Trim();
                else
                    inputOtp += "";
            }
            if (OtpStorage.ExpireAt.HasValue && DateTime.UtcNow > OtpStorage.ExpireAt.Value)
            {
                MessageBox.Show("OTP đã hết hạn. Vui lòng yêu cầu gửi lại.");
                OtpStorage.Clear();
                return;
            }

            OtpStorage.AttemptCount++;
            if (OtpStorage.AttemptCount > 5)
            {
                MessageBox.Show("Bạn đã thử quá nhiều lần. Vui lòng gửi lại OTP.");
                OtpStorage.Clear();
                return;
            }

            if (!string.IsNullOrEmpty(inputOtp) && inputOtp == OtpStorage.CurrentOtp)
            {
                MessageBox.Show("Xác thực OTP thành công!");
                OtpStorage.Clear();
                otpClear();
                pnB2.Visible = false;
                pnB1.Visible = true;
            }
            else
            {
                MessageBox.Show("OTP không đúng, vui lòng thử lại.");
                for (int i = 0; i < 6; i++)
                {
                    var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();
                    if (ctl is Guna2TextBox gtb) gtb.Text = "";
                }
                this.Controls.Find("txbOTPcode0", true).FirstOrDefault()?.Focus();
            }
        }
    }
}