using System;
using System.Linq;
using System.Web.Mvc;
using DAL;
using Service;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        private OrderService _orderService;
        private FeedBackService backService;
        private UserService userService;
        private ProductService productService;
        private NewsService newsService;
        private BaogiaService baogiaService;
        public HomeAdminController()
        {
            baogiaService = new BaogiaService();
            newsService = new NewsService();
            userService = new UserService();
            backService = new FeedBackService();
            _orderService = new OrderService();
            productService = new ProductService();
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.ListNew = newsService.GetAll();
            ViewBag.ListPro = productService.GetAll();
            ViewBag.listUser = userService.GetAll().Where(a=>a.RoleId != 1).ToList();
            ViewBag.ListFeeback = backService.GetAll();
            ViewBag.ListOrder = _orderService.GetAll().Where(s => s.Status == 0).ToList();
            ViewBag.ListBaogia = baogiaService.GetAll().Where(s => s.Status == 0).ToList();
            return View(_orderService.GetAll().Where(s=>s.Status ==0));
        }
        public ActionResult Error()
        {
	        return View();
        }

	}
}