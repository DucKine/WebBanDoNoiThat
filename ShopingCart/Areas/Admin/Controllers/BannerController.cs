using Model;
using Service;
using ShopingCart.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class BannerController : BaseController
    {
        private BannerService banners;
        public BannerController()
        {
            banners = new BannerService();
        }
        // GET: Admin/Banner
        [HasCredential(ActionId = 37)]
        [HttpGet]
        public ActionResult Index()
        {
            return View(banners.GetAll());
        }

        [HttpGet]
        [HasCredential(ActionId = 38)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [HasCredential(ActionId = 38)]
        public ActionResult Create(Banner b)
        {
            if (ModelState.IsValid)
            {
                var result = banners.Insert(b);
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
            return View(b);
        }
        [HttpGet]
        [HasCredential(ActionId = 39)]
        public ActionResult Edit(int id)
        {
            Banner banner = banners.GetById(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);

        }
        [HttpPost]
        [HasCredential(ActionId = 39)]
        public ActionResult Edit(Banner b)
        {
            if (ModelState.IsValid)
            {
                var result = banners.Update(b);
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
            return View(b);
        }
        [HasCredential(ActionId = 40)]
        public ActionResult Delete(int id)
        {
            var result = banners.Delete(id);
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