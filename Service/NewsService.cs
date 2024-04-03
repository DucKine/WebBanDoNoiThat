using DAL;
using Model;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NewsService : IServices<News>
    {
        private NewsReponsitory repository;
        public NewsService()
        {
            repository = new NewsReponsitory(new DBEntityContext());
        }
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<News> GetAll()
        {
            return repository.GetAll();
        }

        public News GetById(int id)
        {
            return repository.GetById(id);
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
            return repository.Insert(t);
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
            return repository.Update(t);
        }
    }
}
