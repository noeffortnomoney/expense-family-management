using System;
using System.Net.Mail;
using System.Configuration;

namespace EFM.Common.Helpers
{
    public class Mail
    {
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                // Đọc cấu hình từ appSettings
                var host = ConfigurationManager.AppSettings["SMTPHost"];
                var port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
                var fromEmail = ConfigurationManager.AppSettings["FromEmailAddress"];
                var appPassword = ConfigurationManager.AppSettings["FromEmailPassword"]; // App Password
                var fromName = ConfigurationManager.AppSettings["FromName"];

                // Thiết lập SMTP Client với App Password
                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, appPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true, // Sử dụng SSL để bảo mật kết nối
                    Timeout = 100000
                };

                // Thiết lập Mail Message
                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName),
                    BodyEncoding = System.Text.Encoding.UTF8,
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };

                // Thêm địa chỉ email người nhận
                mail.To.Add(new MailAddress(toEmail));

                // Gửi email
                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException ex)
            {
                // Xử lý lỗi gửi email
                Console.WriteLine($"SMTP Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                Console.WriteLine($"General Error: {ex.Message}");
                return false;
            }
        }
    }
}
