using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace ShopingCart.Controllers
{
    public class ProjectedController : Controller
    {
        private ProjectService projectService;
        public ProjectedController()
        {
            projectService = new ProjectService();
        }
        // GET: Projected
        public ActionResult Index(int?page)
        {
            var listP = projectService.GetAll().Where(s => s.Status == true).ToList();
            if (listP.Count() == 0)
            {
                return HttpNotFound();
            }
            int PageSize = 6;
            int PageNumber = (page ?? 1);

            return View(listP.ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Detail(int id)
        {
            return View(projectService.GetById(id));
        }
    }
}