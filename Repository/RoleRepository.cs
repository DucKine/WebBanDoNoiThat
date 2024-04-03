using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL;
using Model;
using Repository.Interface;

namespace Repository
{
public	class RoleRepository:IRepository<Role>
	{
		private DBEntityContext context;
		public RoleRepository(DBEntityContext context)
		{
			this.context = context;
		}
		public IEnumerable<Role> GetAll()
		{
			return context.Roles.ToList();
		}

		public IEnumerable<Role> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Insert(Role t)
		{
			var roles = context.Roles.ToList();

			if (roles.Any(x => x.RoleName.ToLower().Equals(t.RoleName.ToLower()))) return -2;

			context.Roles.Add(t);
			return context.SaveChanges();
		}

		public int Update(Role t)
		{
			var roles = context.Roles.ToList();
			roles.Remove(GetById(t.RoleId));

			if (roles.Any(x => x.RoleName.ToLower().Equals(t.RoleName.ToLower()))) return -2;

			var currentItem = GetById(t.RoleId);
			currentItem.Description = t.Description;
			currentItem.RoleName = t.RoleName;
			context.Entry(currentItem).State = EntityState.Modified;
			return context.SaveChanges();
		}

		public int Delete(int id)
		{
			var roleActionList = context.RoleActions.ToList();
			var usersList = context.Users.ToList();
			var currentItem = context.Roles.Find(id);

			if (usersList.Any(x => x.RoleId == id)) return -1;

			if (roleActionList.Any(x => x.RoleId == id)) return -1;

			if(currentItem!=null)context.Roles.Remove(currentItem);
			return context.SaveChanges();
		}

		public Role GetById(int id)
		{
			return context.Roles.Find(id);
		}

		public Role GetByUserName(string UserName)
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
