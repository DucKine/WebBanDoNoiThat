using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ShopingCart.Models
{
    public static class Helper
    {
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