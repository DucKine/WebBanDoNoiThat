using Model;
using Service;
using System.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
	public class SliderController : BaseController
	{
		private SliderService sliderService;
		public SliderController()
		{
			sliderService = new SliderService();
		}
		// GET: Admin/Slider
		[HasCredential(ActionId = 19)]
		public ActionResult Index(string searchString, int Page = 1, int PageSize = 10)
		{
			return View(sliderService.Search(searchString,Page,PageSize));
		}
		[HttpGet]
		[HasCredential(ActionId = 20)]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[HasCredential(ActionId = 20)]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider s)
		{
			if (ModelState.IsValid)
			{
				var result = sliderService.Insert(s);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		[HasCredential(ActionId = 21)]
		public ActionResult Edit(int id)
		{
			return View(sliderService.GetById(id));
		}
		[HasCredential(ActionId = 21)]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider s)
		{
			if (ModelState.IsValid)
			{
				var result = sliderService.Update(s);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			return View();
		}
		[HasCredential(ActionId = 22)]
		public ActionResult Delete(int id)
		{
			var result = sliderService.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Index");
		}
	}
}