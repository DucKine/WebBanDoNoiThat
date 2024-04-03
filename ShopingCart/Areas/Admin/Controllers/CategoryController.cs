using Model;
using Service;
using System.Linq;
using System.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
	public class CategoryController : BaseController
	{
		private CategoryService category;
		public CategoryController()
		{
			category = new CategoryService();
		}
		// GET: Admin/Category
		[HasCredential(ActionId = 1)]
		public ActionResult Index()
		{
			return View(category.GetAll());
		}
		[HttpGet]
		[HasCredential(ActionId = 2)]
		public ActionResult Create()
		{
            ViewBag.ParentID = new SelectList(category.GetAll().Where(s => s.ParentID == null), "ID", "Name");
            return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[HasCredential(ActionId = 2)]
		public ActionResult Create(Category c)
		{
			if (ModelState.IsValid)
			{
				var result = category.Insert(c);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Name", "category Name Đã Tồn Tại");
					ViewBag.ParentID = new SelectList(category.GetAll(), "ID", "Name");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.ParentID = new SelectList(category.GetAll().Where(s=>s.ParentID == null), "ID", "Name");
			return View();
		}
		[HttpGet]
		[HasCredential(ActionId = 3)]
		public ActionResult Edit(int id)
		{
			ViewBag.ParentID = new SelectList(category.GetAll().Where(s => s.ParentID == null), "ID", "Name", category.GetById(id).ParentID);
			return View(category.GetById(id));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[HasCredential(ActionId = 3)]
		public ActionResult Edit(Category c)
		{
			if (ModelState.IsValid)
			{
				var result = category.Update(c);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Name", "category Name Đã Tồn Tại");
					ViewBag.ParentID = new SelectList(category.GetAll().Where(s => s.ParentID == null), "ID", "Name", category.GetById(c.ID).ParentID);
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}

			return View();

		}
		[HasCredential(ActionId = 4)]
		public ActionResult Delete(int id)
		{
           
			var result = category.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else if (result == -1)
			{
				TempData["message"] = "Ex";
				TempData["data"] = "Role đang được sử dụng! Bạn không thể xóa";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Index");
		}

	}
}