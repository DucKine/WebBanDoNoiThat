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
    public class ProjectedReponsitory : IRepository<Projected>, IDisposable
    {
        private DBEntityContext context;
        public ProjectedReponsitory(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            var item = context.Projecteds.Where(x => x.ID == id).SingleOrDefault();
            if (item.Status == false)
            {
                context.Projecteds.Remove(item);
                context.SaveChanges();
            }
            return 1;
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

        public IEnumerable<Projected> GetAll()
        {
            return context.Projecteds.ToList();
        }

        public Projected GetById(int id)
        {
            return context.Projecteds.SingleOrDefault(s => s.ID == id);
        }

        public Projected GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Projected t)
        {
             context.Projecteds.Add(t);
            return context.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projected> Search(string searchString, int Page, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public int Update(Projected t)
        {
            context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
