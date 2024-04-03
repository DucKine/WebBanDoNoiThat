using System.Collections.Generic;
using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using Action = Model.Action;

namespace Service
{
	public class RoleActionService : IRoleActionService
	{
		private IRoleActionRepository repository;
		public RoleActionService()
		{
			repository = new RoleActionRepository(new DBEntityContext());
		}

		public IEnumerable<Action> ListActions(int id, string searchString, int Page, int Pagesize)
		{
			return repository.ListActions(id,searchString,Page,Pagesize);
		}

		public IEnumerable<Action> ListCurrentRole(int id, string searchString, int Page, int Pagesize)
		{
			return repository.ListCurrentRole(id, searchString, Page, Pagesize);
		}

		public int AddActions(List<RoleAction> items)
		{
			return repository.AddActions(items);
		}

		public int RemoveActions(List<RoleAction> items)
		{
			return repository.RemoveActions(items);
		}
	}
}
