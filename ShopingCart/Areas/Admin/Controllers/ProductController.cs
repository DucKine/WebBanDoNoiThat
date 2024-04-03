using Model;
using Service;
using System.Web.Mvc;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class ProductController : BaseController
	{
		private ProductService product;
		private CategoryService category;
		public ProductController()
		{
			category = new CategoryService();
			product = new ProductService();
		}
		// GET: Admin/Category
		[HasCredential(ActionId = 9)]
		public ActionResult Index(string searchString, int Page = 1, int PageSize = 10)
		{
			ViewBag.searchString = searchString;
			return View(product.Search(searchString, Page, PageSize));
		}
		[HttpGet]
		[HasCredential(ActionId = 10)]
		public ActionResult Create()
		{
			ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
			return View();
		}
		//public ActionResult Detail(int id)
		//{
		//	return View(product.GetById(id));
		//}
		[HttpPost]

        
        [HasCredential(ActionId = 10)]
		public ActionResult Create(Product p)
		{
			if (ModelState.IsValid)
			{
				if (p.Sale_Price != null && p.Sale_Price > p.Price)
				{
					ModelState.AddModelError("Price", "Giá gốc không được nhỏ hơn giá khuyến mãi");
					ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
					return View();
				}
				var result = product.Insert(p);
				
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Name", "Product Name Đã Tồn Tại");
					ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
					return View();
				}
				else
				{
					TempData["message"] = "false";
				}

				return RedirectToAction("Index");
			}
			ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
			return View();
		}
		[HttpGet]
		[HasCredential(ActionId = 11)]
		public ActionResult Edit(int id)
		{
			ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name", product.GetById(id).Category_ID);
			return View(product.GetById(id));
		}
		[HttpPost]
		[ValidateInput(false)]
		[ValidateAntiForgeryToken]
		[HasCredential(ActionId = 11)]
		public ActionResult Edit(Product p)
		{
			if (ModelState.IsValid)
			{
				if (p.Sale_Price != null && p.Sale_Price > p.Price)
				{
					ModelState.AddModelError("Price", "Giá gốc không được nhỏ hơn giá khuyến mãi");
					ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
					return View();
				}
				var result = product.Update(p);
				
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else if (result == -2)
				{
					ModelState.AddModelError("Name", "Product Name Đã Tồn Tại");
					ViewBag.Category_ID = new SelectList(category.GetAll(), "ID", "Name");
					return View();
				}

				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
			}
			ViewBag.Category_ID = new SelectList(product.GetAll(), "ID", "Name", product.GetById(p.Category_ID));
			return View();

		}
		[HasCredential(ActionId = 12)]
		public ActionResult Delete(int id)
		{
			var result = product.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else if (result == -1)
			{
				TempData["message"] = "Ex";
				TempData["data"] = "Sản phẩm đang được sử dụng! Bạn không thể xóa";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Index");
		}

        [HasCredential(ActionId = 41)]
        public ActionResult Details(int id)
        {
            var products = product.GetById(id);
            ViewBag.Category = product.GetById(id);

            return View(products);
        }


    }
}