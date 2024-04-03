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
                    string header = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Start/header.txt"));
                    string footer = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Start/footer.txt"));
                    string main = String.Format(@"<h2 class='title'>Nội Thất Hồng Ngọc -Xác Nhận Đơn Hàng</h2>
                <p>
					<b>Họ tên người nhận:</b>
					<span>{0}</span>
				</p>
				<p>
					<b>Email:</b>
					<span>{1}</span>
				</p>
				<p>
					<b>SĐT:</b>
					<span>{2}</span>
				</p>
				<p>
					<b>Địa chỉ:</b>
					<span>{3}</span>
				</p>
				<p>
					<b>Ngày mua:</b>
					<span>{4}</span>
				</p>", currentUser.FullName, currentUser.Email  , currentUser.Phone, currentUser.Address, DateTime.Now);
                    main += @"<table class='table text-center'>
					<thead>
						<tr>
							<th>Sản phẩm</th>
							<th>Đơn giá</th>
							<th>Số lượng</th>
							<th>Thành tiền</th>
                            <th>Tổng Tiền</th>
						</tr>
					</thead>
					<tbody>";
                    foreach (var item in cart)
                    {
                        var total = 0;
                        var money = (item.Quantity * item.Product.Price);
                        var price = item.Product.Price = (item.Product.Sale_Price != null && item.Product.Sale_Price < item.Product.Price) ? float.Parse(item.Product.Sale_Price.ToString()) : float.Parse(item.Product.Price.ToString());
                        total += (int)money;
                        main += "    <tr>";
                        main += "	 <td>" + item.Product.Name + "</td>";
                        main += "    <td>" + item.Product.Price + " VNĐ</td>";
                        main += "    <td>" + item.Quantity + "</td>";
                        main += "    <td>" + (item.Quantity * price) + "</td>";
                        main += "    <td>" + total + "</td>";
                        main += "</tr>";
                    }
                    main += @"</tbody>
				</table>";
                    HelpMail.SendEmail(currentUser.Email, "danhminhhm@gmail.com", "danhngoc99", "[Nội Thất Hồng Ngọc]_Đơn hàng", header + main + footer);
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