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
	public class FooterRepository : IRepository<Footer>
	{
		private DBEntityContext context;
		public FooterRepository(DBEntityContext context)
		{
			this.context =context;
		}
		public int Delete(int id)
		{
			context.Footers.Remove(GetById(id));
			return context.SaveChanges();
		}

		public IEnumerable<Footer> GetAll()
		{
			return context.Footers.ToList();
		}

		public Footer GetById(int id)
		{
			return context.Footers.Find(id);
		}

		public Footer GetByUserName(string UserName)
		{
			throw new NotImplementedException();
		}

		public Contact GetContact()
		{
			throw new NotImplementedException();
		}

		public int Insert(Footer t)
		{
			context.Footers.Add(t);
			return context.SaveChanges();
		}

		public IEnumerable<Footer> ListProductHot()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Footer> ListProductNew()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Footer> ListProductSale()
		{
			throw new NotImplementedException();
		}

		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Footer> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(Footer t)
		{
			context.Entry(t).State = System.Data.Entity.EntityState.Modified;
			return context.SaveChanges();
		}
	}
}
