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
    public class NewsReponsitory:IRepository<News>, IDisposable
    {
        private DBEntityContext context;
        public NewsReponsitory(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            var item = context.News.Where(x => x.ID == id).SingleOrDefault();
            if (item.Status == false)
            {
                context.News.Remove(item);
                context.SaveChanges();
            }
            return 1;
        }

       

        public IEnumerable<News> GetAll()
        {
           return context.News.ToList();
        }

        public News GetById(int id)
        {
            return context.News.Where(x => x.ID == id).SingleOrDefault();
        }

        public News GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(News t)
        {
            t.CreateDate = DateTime.Now;
            context.News.Add(t);
            return context.SaveChanges();

        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> Search(string searchString, int Page, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public int Update(News t)
        {

            var productnews = context.News.ToList();
            var currentItem = context.News.Find(t.ID);
            productnews.Remove(currentItem);
            if (currentItem != null)
            {
                currentItem.Images = t.Images;
                currentItem.Summary = t.Summary;
                currentItem.Content = t.Content;
                currentItem.Slug = t.Slug;
                currentItem.Status = t.Status;
                context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
            }

            return context.SaveChanges();
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
    }
}
