using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectService : IServices<Projected>
    {
        private IRepository<Projected> repository;
        public ProjectService()
        {
            repository = new ProjectedReponsitory(new DBEntityContext());
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Projected> GetAll()
        {
            return repository.GetAll();
        }

        public Projected GetById(int id)
        {
            return repository.GetById(id);
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
            return repository.Insert(t);
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
            return repository.Update(t);
        }
    }
}
