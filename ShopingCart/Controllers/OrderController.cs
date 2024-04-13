using Model;
using Service;
using ShopingCart.Common;
using ShopingCart.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShopingCart.Controllers
{
    public class OrderController : Controller
    {
		private UserService _userService;
		private OrderService _orderService;
		private OrderDetailService _orderDetailService;
		public OrderController()
		{
			_userService = new UserService();
			_orderService = new OrderService();
			_orderDetailService = new OrderDetailService();
		}
        // GET: Order
        public ActionResult Index()
        {
	        if (Session["User"] != null)
			{
				var currentUser =(User)Session["User"];
				var user =_userService.GetById(currentUser.UserId);
				ViewBag.User = user;
			}
            return View();
        }
		[HttpPost]
		public ActionResult Index(Order order)
		{
			if (Session["User"] != null)
			{
				var currentUser = (User)Session["User"];
				var user = _userService.GetById(currentUser.UserId);
				ViewBag.User = user;
			}
			if (ModelState.IsValid)
			{
                var currentUser = (User)Session["User"];
                var cart =(List<CartItem>) Session[Common.CommonConstants.SESSION_CART];
				var orderDetails = new List<OrderDetail>();
				foreach (var item in cart)
				{
					var orderDetail = new OrderDetail {
					Price = (item.Product.Sale_Price !=null&&item.Product.Sale_Price<item.Product.Price) ? float.Parse(item.Product.Sale_Price.ToString()): float.Parse( item.Product.Price.ToString()),
					Product_Id=item.Product.Id,
					Quantity=item.Quantity,
					
					};
					orderDetails.Add(orderDetail);

				}
			    var result=	_orderDetailService.Inserts(order,orderDetails);
                if (result > 0)
                {
                    TempData["message"] = "Added";
                    TempData["DataSuccess"] = "Đặt hàng thành công";
					Session[Common.CommonConstants.SESSION_CART] = null;
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index","Home");
			}
			return View();
		}
    }
}