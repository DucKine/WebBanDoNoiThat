using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using DAL;
using Repository;
using Repository.Interface;

namespace Service
{
   public class CategoryService : IServices<Category>
    {
        private IRepository<Category> repository;
        public CategoryService()
        {
            repository = new CategoryReponsitory(new DBEntityContext());
        }
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Category> Filter(Category t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return repository.GetAll();
        }

        public Category GetById(int id)
        {
            return repository.GetById(id);
        }

        public Category GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Category t)
        {
            return repository.Insert(t);
        }

      

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Category> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(Category t)
        {
            return repository.Update(t);
        }
    }
}
