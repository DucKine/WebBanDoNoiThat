using System.Web.Mvc;
using Model;
using Service;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class AboutsController : BaseController
    {
		private AboutService _aboutService;
		public AboutsController()
		{
			_aboutService = new AboutService();

		}
		[HasCredential(ActionId = 27)]
		// GET: Abouts
		public ActionResult Index()
		{
			return View(_aboutService.GetAll());
		}


		[HasCredential(ActionId = 28)]
		// GET: Abouts/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Abouts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[HasCredential(ActionId = 28)]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Name,Slug,Detail,CreatedDate,ModifileDate,Image,Status")] About about)
		{
			if (ModelState.IsValid)
			{
				var result  = _aboutService.Insert(about);
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

			return View(about);
		}

		// GET: Abouts/Edit/5
		[HasCredential(ActionId = 29)]
		public ActionResult Edit(int id)
		{
			About about = _aboutService.GetById(id);
			if (about == null)
			{
				return HttpNotFound();
			}
			return View(about);
		}

		// POST: Abouts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[HasCredential(ActionId = 29)]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Name,Slug,Detail,CreatedDate,ModifileDate,Image,Status")] About about)
		{
			if (ModelState.IsValid)
			{
				var result = _aboutService.Update(about);
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
			return View(about);
		}

		// GET: Abouts/Delete/5
		[HasCredential(ActionId = 30)]
		public ActionResult Delete(int id)
		{
			var result=_aboutService.Delete(id);
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
