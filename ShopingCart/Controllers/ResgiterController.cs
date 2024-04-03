using Model;
using Service;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Controllers
{
	public class ResgiterController : Controller
	{
		private UserService userService;

		public ResgiterController()
		{
			userService = new UserService();
		}
		// GET: Resgiter
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[CaptchaValidationActionFilter("CaptchaCode", "registerCaptcha", "Mã Xác Nhận Không Đúng!")]
		public ActionResult Index(User user)
		{
			if (ModelState.IsValid)
			{
				user.Password = Encryptor.MD5Hash(user.Password);
				var result = userService.Insert(user);
				if (result > 0)
				{
					TempData["message"] = "Added";
					TempData["DataSuccess"] = "Đăng ký thành công";
				}
				else if (result == -1)
				{
					ModelState.AddModelError("Username", "Tài Khoản Đã Tồn Tại");
					return View();
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Email", "Email Đã Tồn Tại");
					return View();
				}
				else if (result == -3)
				{
					ModelState.AddModelError("Phone", "Số điện thoại Đã Tồn Tại");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index","Home");
			}
			return View();
			
		}
	}
}