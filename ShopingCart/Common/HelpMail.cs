using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ShopingCart.Common
{
    public static class HelpMail
    {
        
            /// <summary>
            /// Phương thức gửi email
            /// </summary>
            /// <param name="toEmail">Địa chỉ email nhận</param>
            /// <param name="fromEmail">Địa chỉ email gửi</param>
            /// <param name="passEmail">Mật khẩu email gửi</param>
            /// <param name="titleEmail">Tiêu đề email</param>
            /// <param name="contentEmail">Nội dung email</param>
            public static void SendEmail(string toEmail, string fromEmail, string passEmail, string titleEmail, string contentEmail)
            {
                MailMessage mail = new MailMessage(); // Tạo đối tượng mail
                mail.To.Add(toEmail); // Gửi đến email
                mail.From = new MailAddress(fromEmail);
                mail.Subject = titleEmail; // Tiêu đề email
                mail.Body = contentEmail;// phần thân của mail ở trên
                mail.IsBodyHtml = true; // Cho phép viết mã HTML trong email
                SmtpClient smtp = new SmtpClient(); // Tạo đối tượng gửi mail
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(fromEmail, passEmail);// tài khoản Gmail của bạn
                smtp.EnableSsl = true;
                smtp.Send(mail); // Gửi mail
            }

        
    }
}