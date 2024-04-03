using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class NewsController : Controller
    {
        private NewsService news;
        public NewsController()
        {
            news = new NewsService();
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam ="id")]
        public ActionResult GetById(int id)
        {
            return View(news.GetById(id));
        }
    }
}