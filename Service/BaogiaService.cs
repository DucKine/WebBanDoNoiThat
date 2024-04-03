using DAL;
using Model;
using Repository;
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
   public class BaogiaService : IServices<Baogia>
    {
        private IRepository<Baogia> repository;
        public BaogiaService()
        {
            repository = new BaogiaReponsitory(new DBEntityContext());
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Baogia> GetAll()
        {
            return repository.GetAll();
        }

        public Baogia GetById(int id)
        {
            return repository.GetById(id);
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
            return repository.Insert(t);
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
            return repository.Update(t);
        }
    }
}
