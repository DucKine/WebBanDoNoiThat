using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
    public class MenuService : IServices<Menu>
    {
        private IRepository<Menu> repository;
        public MenuService()
        {
            repository = new MenuReponsitory(new DBEntityContext());
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

      

        public IEnumerable<Menu> GetAll()
        {
            return repository.GetAll();
        }

        public Menu GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Menu GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Menu t)
        {
            throw new NotImplementedException();
        }

   

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> Search(string searchString)
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Menu> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(Menu t)
        {
            throw new NotImplementedException();
        }
    }
}
