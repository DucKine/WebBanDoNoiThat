using DAL;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryReponsitory : IRepository<Category>, IDisposable
    {
        private DBEntityContext context;
        public CategoryReponsitory(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
			var productList = context.Products.ToList();
			var item = context.Categories.FirstOrDefault(c => c.ID == id);
           
			if (productList.Any(x => x.Category_ID == id)) return -1;
            
            if (item!=null&&item.Status == false)
            {
                context.Categories.Remove(item);
              return  context.SaveChanges();
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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

   

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }


        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.ID == id);
        }

        public int Insert(Category t)
        {
			var categories = context.Categories.ToList();

			if (categories.Any(x => x.Name.ToLower().Equals(t.Name.ToLower()))) return -2;

			t.CreatedDate = DateTime.Now;
            context.Categories.Add(t);

            return context.SaveChanges();
        }

        public IEnumerable<Category> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Category t)
        {
			var currentItem = context.Categories.Find(t.ID);
			var categories = context.Categories.ToList();
			categories.Remove(currentItem);

			if (categories.Any(x => x.Name.ToLower().Equals(t.Name.ToLower()))) return -2;
			if (currentItem != null)
			{
				currentItem.ModifileDate = DateTime.Now;
				currentItem.Name = t.Name;
				currentItem.ParentID = t.ParentID;
				currentItem.Slug = t.Slug;
				currentItem.Status = t.Status;
			}
			
            context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }

        public Category GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

     

		public IEnumerable<Category> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }
    }
}
