using DAL;
using Model;
using PagedList;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{
    public class ProductReponsitory : IRepository<Product>, IDisposable, IListProduct<Product>
    {
        private DBEntityContext context;
        public ProductReponsitory(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
			var orderDetailList = context.OrderDetails.ToList();
	

			if (orderDetailList.Any(x => x.Product_Id == id)) return -1;



			var item = context.Products.FirstOrDefault(c => c.Id == id);

			if (item != null && item.Status == false)
			{
				context.Products.Remove(item);
				return context.SaveChanges();
			}

			return -1;
		}


        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

  

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.SingleOrDefault(s => s.Id == id);
        }

        public Product GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product product)
        {
	        var productList = context.Products.ToList();
	        if (productList.Any(x => x.Name.ToLower().Equals(product.Name.ToLower()))) return -2;
	        product.Created = DateTime.Now;
	        context.Products.Add(product);
	        return context.SaveChanges();
		}

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Product t)
        {
	        var productList = context.Products.ToList();
	        var currentItem = context.Products.Find(t.Id);
	        productList.Remove(currentItem);
	        if (productList.Any(x => x.Name.ToLower().Equals(t.Name.ToLower()))) return -2;
	        if (currentItem != null)
	        {
		        currentItem.ModifileDate = DateTime.Now;
		        currentItem.Images = t.Images;
		        currentItem.MoreImages = t.MoreImages;
		        currentItem.Name = t.Name;
		        currentItem.Price = t.Price;
		        currentItem.Sale_Price = t.Sale_Price;
		        currentItem.Slug = t.Slug;
		        currentItem.Status = t.Status;
		        currentItem.TopHot = t.TopHot;
		        currentItem.Content = t.Content;
		        currentItem.Category_ID = t.Category_ID;
		        context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
	        }

	        return context.SaveChanges();
		}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Product> ListProductHot()
        {

            return context.Products.Where(s => s.TopHot == true && s.Status == true).OrderByDescending(s => s.Created).Take(8).ToList();
        }
        //public IEnumerable<Product> ListWishLists( int id)
        //{

        //    return context.wishLists.Where(s => s.UserID == id).ToList();

        //    //return context.Products.Include(x => x.w).Where(s => s.TopHot == true && s.Status == true).OrderByDescending(s => s.Created).Take(8).ToList();
        //}

        public IEnumerable<Product> ListProductrRadom()
        {
            var randomItem = context.Products.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            return randomItem;
        }
       

        public IEnumerable<Product> ListProductNew()
        {
            return context.Products.Where(s => s.Status == true).OrderByDescending(s => s.Created).Take(8).ToList();
        }

		public IEnumerable<Product> Search(string searchString, int Page, int Pagesize)
		{
			var model = context.Products.ToList();
			if (!string.IsNullOrEmpty(searchString))
			{
				model = model.Where(x => x.Name.Contains(searchString)).ToList();
			}
			return model.OrderByDescending(x => x.Created).ToPagedList(Page, Pagesize);
		}

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ListProductGetByCategory(int id, int pageIndex , int pageSize )
        {
            return context.Products.Where(x => x.Category_ID == id).OrderByDescending(x => x.Created).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Product> ListProductSale()
        {    
           return  context.Products.Where(s => s.Sale_Price != null && s.Sale_Price < s.Price).Take(8).ToList();
        }

        //public IEnumerable<Product> SearchName(string searchString, int? Page)
        //{
        //    var model = context.Products.ToList();
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Name.Contains(searchString)).ToList();
        //    }
        //    return model.OrderByDescending(x => x.Created).ToList().ToPagedList(Page ?? 1,3);
        //}
    }
}
