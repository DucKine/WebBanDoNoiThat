using System.Web.Mvc;
using Model;
using Service;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class OrdersController : BaseController
    {
		private OrderService _orderService;
		private OrderDetailService _orderDetailService;
		public OrdersController()
		{
			_orderService = new OrderService();
			_orderDetailService = new OrderDetailService();
		}

		// GET: Admin/Orders
		[HasCredential(ActionId = 35)]
		public ActionResult Index()
        {
            return View(_orderService.GetAll());
        }
		[HttpPost]
		[HasCredential(ActionId = 36)]
		public ActionResult Details(Order order)
		{
			var result= _orderService.Update(order);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Details");
		}
		// GET: Admin/Orders/Details/5
		[HasCredential(ActionId = 36)]
		public ActionResult Details(int id)
        {  
           var orderDetail = _orderDetailService.GetAll(id);
			ViewBag.Order = _orderService.GetById(orderDetail[0].Oder_ID);
			return View(orderDetail);
        }
    }
}
