using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using PagedList.Mvc;
using PagedList;

namespace ShopingCart.Controllers
{
    public class SearchController : Controller
    {
        private ProductService service;
        private CategoryService category;
        private DBEntityContext db;
        public SearchController()
        {

            db = new DBEntityContext();
            category = new CategoryService();
            service = new ProductService();
        }
        
		
    // GET: Search
    public ActionResult ResultSearch(string searchString, int?Page)
        {
            ViewBag.ListCategory = category.GetAll();
            ViewBag.searchString = searchString;

            if (Request.HttpMethod!="GET")
            {
                Page = 1;
            }
            int PageSize = 9;
            int pageNumber = (Page ?? 1);



            var lisP = db.Products.Where(s => s.Name.Contains(searchString));
            return View(lisP.OrderBy(x => x.Name).ToPagedList(pageNumber,PageSize));

            //var model = service.GetAll();
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    model = model.Where(x => x.Name.Contains(searchString)).ToList();
            //}
            //return View(model.OrderBy(x=>x.Name));
        }
    }
}