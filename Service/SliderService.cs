using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SliderService : IServices<Slider>
    {
        private IRepository<Slider> repository;
        public SliderService()
        {
            repository = new SliderReponsitory(new DBEntityContext());
        }
        
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Slider> GetAll()
        {
            return repository.GetAll();
        }

        public Slider GetById(int id)
        {
            return repository.GetById(id);
        }

        public Slider GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Slider t)
        {
            return repository.Insert(t);
        }

       

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

      

		public IEnumerable<Slider> Search(string searchString, int Page, int Pagesize)
		{
			return repository.Search(searchString, Page, Pagesize);
		}

		public int Update(Slider t)
        {
            return repository.Update(t);
        }
    }
}
