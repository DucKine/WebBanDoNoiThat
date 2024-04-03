using Model;
using Service;
using System.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
	public class UserController : BaseController
	{
		private RoleService roleService;
		private UserService userService;
		private LoginService loginService;
		public UserController()
		{
			loginService=new LoginService();
			roleService = new RoleService();
			userService = new UserService();
		}
		// GET: Admin/User
		[HasCredential(ActionId = 23)]
		public ActionResult Index(string searchString, int Page = 1, int PageSize = 15)
		{
			ViewBag.searchString = searchString;
			return View(userService.Search(searchString, Page, PageSize));
		}

		[HttpGet]
		[HasCredential(ActionId = 24)]
		public ActionResult Create()
		{
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
			return View();
		}

		[HttpPost]
		[HasCredential(ActionId = 24)]
		public ActionResult Create(User user)
		{
			if (ModelState.IsValid)
			{
				user.Password = Encryptor.MD5Hash(user.Password);
				var result = loginService.AddUser(user);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -1)
				{
					ModelState.AddModelError("Username", "Tài Khoản Đã Tồn Tại");
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Email", "Email Đã Tồn Tại");
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else if (result == -3)
				{
					ModelState.AddModelError("Phone", "Số điện thoại Đã Tồn Tại");
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");

				return RedirectToAction("Index");
			}
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
			ViewBag.user = userService.GetById(user.UserId);
			return View();
		}
		[HttpGet]
		[HasCredential(ActionId = 25)]
		public ActionResult Edit(int id)
		{
			var user = userService.GetById(id);
			
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName", user.RoleId);
			ViewBag.user = user;
			return View(user);
		}
		[HttpPost]
		[ValidateInput(false)]
		[HasCredential(ActionId = 25)]
		public ActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				var userDetail = userService.GetById(user.UserId);
				if(!userDetail.Password.Equals(user.Password)) user.Password = Encryptor.MD5Hash(user.Password);

				var result = userService.Update(user);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -1)
				{
					ModelState.AddModelError("Username", "Tài Khoản Đã Tồn Tại");
					ViewBag.user = userService.GetById(user.UserId);
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Email", "Email Đã Tồn Tại");
					ViewBag.user = userService.GetById(user.UserId);
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else if (result == -3)
				{
					ModelState.AddModelError("Phone", "Số điện thoại Đã Tồn Tại");
					ViewBag.user = userService.GetById(user.UserId);
					ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.RoleId = new SelectList(roleService.GetAll(), "RoleId", "RoleName");
			ViewBag.user = userService.GetById(user.UserId);
			return View();
		}
		[HasCredential(ActionId = 26)]
		public ActionResult Delete(int id)
		{
			var result = userService.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else if (result == -1)
			{
				TempData["message"] = "Ex";
				TempData["data"] = "Tài khoản đang được sử dụng! Bạn không thể xóa";
			}
			else
			{
				TempData["message"] = "false";
			}

			return RedirectToAction("Index");
		}
	}
}