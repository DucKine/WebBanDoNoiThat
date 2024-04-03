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
	public class OrderRepository : IRepository<Order>, IDisposable
	{
		private DBEntityContext context;
		public OrderRepository(DBEntityContext context)
		{
			this.context = context;
		}
		public int Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
		}

		public IEnumerable<Order> Filter(Order t)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Order> GetAll()
		{
		 return	context.Orders.ToList();

		}

		public Order GetById(int id)
		{
			return context.Orders.FirstOrDefault(x => x.ID == id);
		}

		public Order GetByUserName(string UserName)
		{
			throw new NotImplementedException();
		}

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Order t)
		{
			context.Orders.Add(t);
		return	context.SaveChanges();
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
			var currentItem = context.Orders.FirstOrDefault(s => s.ID==t.ID);
			if (currentItem != null)
			{
				currentItem.ID = t.ID;
				currentItem.Name = t.Name;
				currentItem.Phone = t.Phone;
				currentItem.Status = t.Status;
				currentItem.Email = t.Email;
				currentItem.Created = t.Created;
				currentItem.Address = t.Address;
			}
			
			context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
			return context.SaveChanges();
		}
	}
}
