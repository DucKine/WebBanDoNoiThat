using Service;
using System;
using System.Linq;
using System.Web.Mvc;
using Model;
using PagedList;
using PagedList.Mvc;

namespace ShopingCart.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService;
        private CategoryService categoryService;
     


		public ProductController()
        {
            categoryService = new CategoryService();
            productService = new ProductService();
		
        }
        // GET: Product
        public ActionResult Index(int?Page)
        {
            var listP = productService.GetAll().Where(S => S.Status).ToList();
            if (listP.Count() ==0)
            {
                return HttpNotFound();
            }
            int PageSize = 9;
            int PageNumber = (Page ?? 1);
         
            ViewBag.ListCategory = categoryService.GetAll();

            return View(listP.ToPagedList(PageNumber,PageSize));
        }
        public ActionResult CategoryViewDetail(int id, int page = 1, int pageSize = 12)
        {

            //var index = Request.Params["page"];
            //double value;
            //ViewBag.ListCategory = categoryService.GetAll();
            //var category = categoryService.GetById(id);
            //ViewBag.Category = category;
            //if (!double.TryParse(index, out value) && index != null) return Redirect("/danh-muc-san-pham/4321-" + TempData["categoryId"] + "?page=" + TempData["GoBack"]);
            //TempData["GoBack"] = index;
            //TempData["categoryId"] = id;
            //var totalPage = 0;
            //var total = productService.GetAll().Count();
            //totalPage = (int)Math.Ceiling((double)(total / pageSize));
            //var convertIndex = 0;
            //if (index == null || double.Parse(index) <= 0) convertIndex = 1;
            //else convertIndex = (double.Parse(index) > totalPage) ? totalPage : int.Parse(index);
            //var model = productService.ListProductGetByCategory(id, convertIndex, pageSize).ToList();
            //ViewBag.Page = convertIndex;
            //ViewBag.TotalPage = totalPage;
            //ViewBag.Next = convertIndex + 1;
            //ViewBag.Prev = convertIndex - 1;
            //return View(model);

            ViewBag.ListCategory = categoryService.GetAll();
            var category = categoryService.GetById(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var total = productService.GetAll().Where(s=>s.Category_ID == id).Count();
            var model = productService.ListProductGetByCategory(id, page, pageSize);
            ViewBag.TotalPage = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(total / pageSize));
            ViewBag.Total = total;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            ViewBag.ListProductOther = productService.ListProductrRadom();
            var product = productService.GetById(id);
            ViewBag.Category = productService.GetById(id);
            return View(product);
        }

    }
}