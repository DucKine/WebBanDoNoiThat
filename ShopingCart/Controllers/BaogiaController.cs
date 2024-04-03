using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class BaogiaController : Controller
    {
        private BaogiaService service;
        public BaogiaController()
        {
            service = new BaogiaService();
        }
        // GET: Baogia
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Send(string name, string email, int phone, string message)
        {
            var bg = new Baogia();
            bg.Name = name;
            bg.Email = email;
            bg.Phone = phone;
            bg.Content = message;
            bg.Created = DateTime.Now;
            bg.Status = 0;
            service.Insert(bg);

            return Json(new
            {
                status = true
            });
             
            
        }
    }
}