using DAL;
using Model;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
	public class HomeController : Controller
	{

		private MenuService menuService;
		private ProductService productService;
		private SliderService sliderService;
		private CategoryService categoryService;

        private NewsService newsService;
        private BannerService bannerService;
        private ProjectService projectService; 
		public HomeController()
		{
            projectService = new ProjectService();
            newsService = new NewsService();
            sliderService = new SliderService();
			productService = new ProductService();
			menuService = new MenuService();
			categoryService = new CategoryService();
	
            bannerService = new BannerService();
		}
		public ActionResult Index()
		{
			var user = (User)Session["User"];
			
			if (user == null) ViewBag.ListNotInUser = Session[Common.CommonConstants.DATA_WISH];
            //ViewBag.ListProductHot = productService.ListProductHot();
            ViewBag.ListProject = projectService.GetAll();
			ViewBag.ListProductNew = productService.ListProductNew();
            ViewBag.ListNews = newsService.GetAll();
			ViewBag.ListProductSale = productService.ListProductSale();
            ViewBag.ListBanner = bannerService.GetAll().Where(s=>s.Status).OrderByDescending(s=>s.Created).Take(2).ToList();
			return View(productService.ListProductHot());
		}



        public PartialViewResult LoadChilden(int parentID)
		{
			List<Category> lst = new List<Category>();
			using (var context = new DBEntityContext())
			{
				lst = context.Categories.Where(s => s.ParentID == parentID).ToList();
			}
			ViewBag.Count = lst.Count();
			return PartialView("LoadChilden", lst);
		}


        [ChildActionOnly]
        public ActionResult ShowProject()
        {
            return PartialView(projectService.GetAll());
        }

		[ChildActionOnly]
  
		public ActionResult MainMenu()
		{
			List<Category> lst = new List<Category>();
			using (var context = new DBEntityContext())
			{
				lst = context.Categories.Where(s => s.ParentID == null).ToList();
			}
			return PartialView(lst);
		}
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new Footer();
            using (var context = new DBEntityContext())
            {
                 model = context.Footers.FirstOrDefault(x => x.Status == true);
            }
            return PartialView(model);
        }

		[ChildActionOnly]
        public ActionResult Slider()
		{
			return PartialView(sliderService.GetAll());
		}

		[ChildActionOnly]
     
        public ActionResult HeaderCart()
		{
			var cart = Session[Common.CommonConstants.SESSION_CART];
			var list = new List<CartItem>();
			if (cart != null)
			{
				list = (List<CartItem>)cart;
			}
			return PartialView(list);
		}
		public ActionResult About()
		{
			

			return View();
		}
		
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Error404()
		{
			return View();
		}
		public ActionResult Error500()
		{
			return View();
		}
	}
}