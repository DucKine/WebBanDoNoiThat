using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
	public class OrderService : IServices<Order>
	{
		private IRepository<Order> repository;
		public OrderService()
		{
			repository = new OrderRepository(new DBEntityContext());
		}
		public int Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Order> Filter(Order t)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Order> GetAll()
		{
			return repository.GetAll();
		}

		public Order GetById(int id)
		{
			return repository.GetById(id);
		}

		public Order GetByUserName(string UserName)
		{
			return repository.GetByUserName(UserName);
		}

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Order t)
		{
			return repository.Insert(t);
		}

	

		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Order> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(Order t)
		{
			return repository.Update(t);
		}
	}
}
