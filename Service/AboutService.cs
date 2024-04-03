using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;

namespace Service
{
	public class AboutService : IServices<About>
	{
		private IRepository<About> repository;
		public AboutService()
		{
			repository = new AboutRepository(new DBEntityContext());
		}
		public IEnumerable<About> GetAll()
		{
			return repository.GetAll();
		}

		public IEnumerable<About> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Insert(About t)
		{
			return repository.Insert(t);
		}

		public int Update(About t)
		{
			return repository.Update(t);
		}

		public int Delete(int id)
		{
			return repository.Delete(id);
		}

		public About GetById(int id)
		{
			return repository.GetById(id);
		}

		public About GetByUserName(string UserName)
		{
			throw new NotImplementedException();
		}

		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public Contact GetContact()
		{
			throw new NotImplementedException();
		}
	}
}
