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
    public class FeedBackReponsitory : IRepository<FeedBack>, IDisposable
    {
        private DBEntityContext context;
        public FeedBackReponsitory(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
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

        public IEnumerable<FeedBack> GetAll()
        {
            return context.FeedBacks.ToList();
        }

        public FeedBack GetById(int id)
        {
            throw new NotImplementedException();
        }

        public FeedBack GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(FeedBack t)
        {
            context.FeedBacks.Add(t);
            return context.SaveChanges();
        }

        

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeedBack> Search(string searchString, int Page, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public int Update(FeedBack t)
        {
            throw new NotImplementedException();
        }
    }
}
