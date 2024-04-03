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
    public class BaogiaController : Controller
    {

        private BaogiaService service;

        public BaogiaController()
        {
            service = new BaogiaService();
        }
        // GET: Admin/Baogia

        [HasCredential(ActionId = 46)]
        [HttpGet]
        public ActionResult Index()
        {
            return View(service.GetAll());
        }
        [HasCredential(ActionId = 47)]
        [HttpGet]
        public ActionResult Edit(int id)
        {

            Baogia baogia = service.GetById(id);
            if (baogia == null)
            {
                return HttpNotFound();
            }
            return View(baogia);
        }
        [HasCredential(ActionId = 47)]
        [HttpPost]
        public ActionResult Edit(Baogia b)
        {
            if (ModelState.IsValid)
            {
                var result = service.Update(b);
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
        [HasCredential(ActionId = 48)]
   
        public ActionResult Delete(int id)
        {
            var result = service.Delete(id);
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