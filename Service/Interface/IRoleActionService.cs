using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Action = Model.Action;

namespace Service.Interface
{
	public interface IRoleActionService
	{
		IEnumerable<Action> ListActions(int id, string searchString, int Page, int Pagesize);
		IEnumerable<Action> ListCurrentRole(int id, string searchString, int Page, int Pagesize);
		int AddActions(List<RoleAction> items);
		int RemoveActions(List<RoleAction> items);
	}
}
