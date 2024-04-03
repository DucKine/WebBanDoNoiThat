using Model;
using Service;
using System.Web.Mvc;
using ShopingCart.Common;
using System;

namespace ShopingCart.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class NewsController : BaseController
	{
		private NewsService newsService;
		public NewsController()
		{
			newsService = new NewsService();
		}
		// GET: Admin/News
		[HasCredential(ActionId = 31)]
		public ActionResult Index()
		{
			return View(newsService.GetAll());
		}
		public ActionResult GetById(int id)
		{
			return View(newsService.GetById(id));
		}
		[HttpGet]
		[HasCredential(ActionId = 32)]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[HasCredential(ActionId = 32)]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News n)
		{
      
                if (ModelState.IsValid)
                {
                    var result = newsService.Insert(n);
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
		[HasCredential(ActionId = 33)]
        [HttpGet]
		public ActionResult Edit(int id)
		{
			return View(newsService.GetById(id));
		}
		[HasCredential(ActionId = 33)]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News n)
		{
			if (ModelState.IsValid)
			{
				var result = newsService.Update(n);
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
		[HasCredential(ActionId = 34)]
		public ActionResult Delete(int id)
		{
			var result = newsService.Delete(id);
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