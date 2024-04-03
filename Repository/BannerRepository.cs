using DAL;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Properties
{
   public class BannerRepository :IRepository<Banner>, IDisposable
    {
        private DBEntityContext context;
        public BannerRepository(DBEntityContext context)
        {
            this.context = context;
        }
        private bool disposed = false;

        public int Delete(int id)
        {
            var item = context.Banners.FirstOrDefault(s=>s.ID == id);
            if (item.Status)
            {
                context.Banners.Remove(item);
                context.SaveChanges();
            }
            return 1;

        }

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

        public IEnumerable<Banner> GetAll()
        {

            return context.Banners.ToList();
        }

        public Banner GetById(int id)
        {
            return context.Banners.Where(s => s.ID == id).FirstOrDefault();
        }

        public Banner GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Banner t)
        {
            t.Created = DateTime.Now;
             context.Banners.Add(t);
            return context.SaveChanges()
                ;
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Banner> Search(string searchString, int Page, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public int Update(Banner t)
        {

            var banner = context.Banners.ToList();
            var currentItem = context.Banners.Find(t.ID);
            banner.Remove(currentItem);
            if (currentItem != null)
            {
                currentItem.Images = t.Images;
                currentItem.Link = t.Link;
                currentItem.ModifileDate = DateTime.Now;
                currentItem.Status = t.Status;
                context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
            }

            return context.SaveChanges();

        }
    }
}
