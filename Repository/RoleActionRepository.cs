using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;
using PagedList;
using Repository.Interface;
using Action = Model.Action;

namespace Repository
{
	public class RoleActionRepository : IRoleActionRepository
	{
		private DBEntityContext context;
		public RoleActionRepository(DBEntityContext context)
		{
			this.context = context;
		}

		public IEnumerable<Action> ListActions(int id, string searchString, int Page, int Pagesize)
		{
			var currentActions = context.RoleActions.Where(x => x.RoleId.Equals(id)).ToList();
			var listActions = context.Actions.ToList();
			foreach (var item in currentActions)
			{
				listActions.Remove(context.Actions.SingleOrDefault(x=>x.ActionId.Equals(item.ActionId)));
			}
			if (!string.IsNullOrEmpty(searchString))
			{
				listActions = listActions.Where(x => x.ActionName.ToLower().Contains(searchString.ToLower())).ToList();
			}
		
			return listActions.OrderByDescending(x => x.ActionId).ToPagedList(Page, Pagesize);
		}

		public IEnumerable<Action> ListCurrentRole(int id, string searchString, int Page, int Pagesize)
		{
			var currentActions = context.RoleActions.Where(x => x.RoleId.Equals(id)).ToList();
			var listActions = new List<Action>();
			if (currentActions.Count==0) return listActions.OrderByDescending(x => x.ActionId).ToPagedList(Page, Pagesize);
			foreach (var item in currentActions)
			{
				var current = context.Actions.SingleOrDefault(s => s.ActionId.Equals(item.ActionId));
				listActions.Add(current);
			}
			if (!string.IsNullOrEmpty(searchString))
			{
				listActions = listActions.Where(x => x.ActionName.ToLower().Contains(searchString.ToLower())).ToList();
			}
			var list = context.Actions.ToList();
			return listActions.OrderByDescending(x => x.ActionId).ToPagedList(Page, Pagesize);
		}

		public int AddActions(List<RoleAction> items)
		{
			context.RoleActions.AddRange(items);
			return context.SaveChanges();
		}

		public int RemoveActions(List<RoleAction> items)
		{
			var listRoleAction = new List<RoleAction>();
			foreach (var item in items)
			{
				listRoleAction.Add(context.RoleActions.FirstOrDefault(s=>s.ActionId.Equals(item.ActionId)&&s.RoleId.Equals(item.RoleId)));
			}
			context.RoleActions.RemoveRange(listRoleAction);
			return context.SaveChanges();
		}
	}
}
