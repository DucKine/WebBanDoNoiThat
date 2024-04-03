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
    public class ProjectedController : BaseController
    {
        private ProjectService projject;
        // GET: Admin/Projected
        public ProjectedController()
        {
            projject = new ProjectService();
        }
        [HasCredential(ActionId = 42)]
        public ActionResult Index()
        {
            return View(projject.GetAll());
        }

        [HttpGet]
        [HasCredential(ActionId = 43)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [HasCredential(ActionId = 43)]
        public ActionResult Create(Projected p)
        {
            if (ModelState.IsValid)
            {
                projject.Insert(p);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [HasCredential(ActionId = 44)]
        public ActionResult Edit(int Id)
        {
            return View(projject.GetById(Id));
        }
        [HttpPost]
        [HasCredential(ActionId = 44)]
        public ActionResult Edit(Projected p)
        {
            if(ModelState.IsValid)
            {
                projject.Update(p);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HasCredential(ActionId = 45)]
        public ActionResult Delete(int Id)
        {
            projject.Delete(Id);
            return RedirectToAction("Index");
        }




    }
}