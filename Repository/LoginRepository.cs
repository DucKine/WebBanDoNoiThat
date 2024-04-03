using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Repository.Interface;

namespace Repository
{
	public class LoginRepository : ILoginRepository
	{
		private DBEntityContext context;
		public LoginRepository(DBEntityContext context)
		{
			this.context = context;
		}
		public List<int> GetListAction(string userName)
		{
			var user = context.Users.Single(x => x.UserName == userName);
			var data = (from a in context.RoleActions
						join b in context.Roles on a.RoleId equals b.RoleId
						join c in context.Actions on a.ActionId equals c.ActionId
						where b.RoleId == user.RoleId
						select new
						{
							a.RoleId, a.ActionId
						}).AsEnumerable().Select(x => new Model.RoleAction()
						{
							RoleId = x.RoleId,
							ActionId = x.ActionId
						});
			return data.Select(x => x.ActionId).ToList();
		}

		public int AddUser(User user)
		{
			var userList = context.Users.ToList();
			if (userList.Any(x => x.UserName.ToLower().Equals(user.UserName.ToLower()))) return -1;

			if (userList.Any(x => x.Email.ToLower().Equals(user.Email.ToLower()))) return -2;

			if (userList.Any(x => x.Phone.Equals(user.Phone))) return -3;

			
				var currentUser = new User
				{
					RoleId = user.RoleId,
					Password = user.Password,
					UserName = user.UserName,
					Address = user.Address,
					CreatedDate = DateTime.Now,
					Email = user.Email,
					FullName = user.FullName,
					Phone = user.Phone,
					Status = true,
					ConfirmPassword = user.Password,
				};
				context.Users.Add(currentUser);
			

			//try
			//{
				return context.SaveChanges();
			//}
			//catch (Exception e)
			//{
			//	return 0;
			//}
		}
	}
}
