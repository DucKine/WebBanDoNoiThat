using DAL;
using Model;
using Repository.Interface;
using Repository.Properties;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BannerService : IServices<Banner>
    {
        private IRepository<Banner> repository;
        public BannerService()
        {
            repository = new BannerRepository(new DBEntityContext());
        }
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Banner> GetAll()
        {
            return repository.GetAll();
        }

        public Banner GetById(int id)
        {
            return repository.GetById(id);
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
            return repository.Insert(t);
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
            return repository.Update(t);
        }
    }
}
