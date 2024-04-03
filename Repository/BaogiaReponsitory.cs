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
    public class BaogiaReponsitory : IRepository<Baogia>, IDisposable
    {
        private DBEntityContext context;
        public BaogiaReponsitory(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            var item = context.Baogias.Where(s => s.ID == id).FirstOrDefault();
            context.Baogias.Remove(item);
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

        public IEnumerable<Baogia> GetAll()
        {
            return context.Baogias.ToList();
        }

        public Baogia GetById(int id)
        {
            return context.Baogias.Where(s => s.ID == id).FirstOrDefault();
        }

        public Baogia GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Baogia t)
        {
            context.Baogias.Add(t);
            return context.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Baogia> Search(string searchString, int Page, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public int Update(Baogia t)

        {
            var baogia = context.Baogias.ToList();
            var currentItem = context.Baogias.Find(t.ID);
            baogia.Remove(currentItem);
            if (currentItem != null)
            {
                currentItem.Status = t.Status;
                context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
            }

            return context.SaveChanges();
        }
    }
}
