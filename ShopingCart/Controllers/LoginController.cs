using BotDetect.Web.Mvc;
using DAL;
using Model;
using Model.ViewModel;
using Service;
using ShopingCart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class LoginController : Controller
    {
		private UserService _userService;
	
		public LoginController()
		{
			_userService = new UserService();
			
		}


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       
		[HttpPost]
		public ActionResult Index(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var res = _userService.Login(model.UserName, Encryptor.MD5Hash(model.Password));
				if (res)
				{
					var user = _userService.GetByUserName(model.UserName);
                    Session["User"] = user;
                    if (!user.Status)
					{
						ModelState.AddModelError("", "Tài khoản của bạn hiện đang bị khóa");
						return View("Index");
					}

                    if (Session[Common.CommonConstants.SESSION_CART] != null)
                    {
                        return RedirectToAction("Index", "Cart");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
					
				}
				else
				{
					ModelState.AddModelError("", "Tên Tài Khoản Hoặc Mật Khẩu Không Chính Xác");
				}
			}
			return View("Index");
		}
		public ActionResult LogOut()
		{
			Session["User"] = null;
            Session[Common.CommonConstants.SESSION_CART] = null;
			return Redirect("/");
		}
        public ActionResult ForgotPassWord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassWord(string EmailAddress)
        {
            string mesage = "";
            //bool status = false;
            using (DBEntityContext db = new DBEntityContext())
            {
                var acc = db.Users.Where(x => x.Email == EmailAddress).FirstOrDefault();
                if (acc!=null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(acc.Email, resetCode, "ResetPassword");
                    acc.RessetPasswordCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    mesage = "Chúng tôi đã gửi 1 đường link về tài khoản của bạn để đặt lại mật khẩu";
                }
                else
                {
                    mesage = "Không tìm thấy tài khoản";
                }
            }
            ViewBag.Message = mesage;
            return View();
        }
        [NonAction]
        public void SendVerificationLinkEmail(string EmailAddress, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Login/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("danhminhhm@gmail.com", "Nội Thất Đồ Gỗ");
            var toEmail = new MailAddress(EmailAddress);
            var fromEmailPassword = "danhngoc99"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Xin Chào ,<br/><br/>Chúng tôi nhận được yêu cầu đặt lại mật khẩu tài khoản của bạn. Vui lòng nhấp vào liên kết dưới đây để thiết lập lại mật khẩu của bạn" +
                    "<br/><br/><a href=" + link + ">Đặt Lại Mật Khẩu</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 10000,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);
        }
        public ActionResult ResetPassword(string id)
        {
            using(DBEntityContext db = new DBEntityContext())
            {
                var user = db.Users.Where(s => s.RessetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPassWord model = new ResetPassWord();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPassWord model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (DBEntityContext db = new DBEntityContext())
                {
                    var user = db.Users.Where(s => s.RessetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user !=null)
                    {
                        user.Password = Encryptor.MD5Hash(model.NewPassword);
                        user.RessetPasswordCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "Cập Nhập Mật Khẩu Thành Công";
                        
                    }

                }
            }
            else
            {
                message = "Cập Nhập Mật Khẩu Thất Bại";
                
            }
            ViewBag.Message = message;
            return View(model);
            
        }


    }
}