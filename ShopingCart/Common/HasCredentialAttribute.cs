using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace ShopingCart.Common
{
	public class HasCredentialAttribute: AuthorizeAttribute
	{
		public int ActionId { get; set; }
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			
			var session = (LoginModel)HttpContext.Current.Session[CommonConstants.USER_SESSION];
			if (session == null)
			{
				httpContext.Response.Redirect("Login");
				return false;
			}
			List<int> privilegeLevels = this.GetCredentialByLoggedInUser(); // Call another method to get rights of the user from DB

			if (privilegeLevels.Contains(this.ActionId))
			{
				return true;
			}

			return false;
		}
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new ViewResult
			{
				ViewName = "~/Areas/Admin/Views/Shared/Error401.cshtml"
			};
		}
		private List<int> GetCredentialByLoggedInUser( )
		{
			var credentials = (List<int>)HttpContext.Current.Session[CommonConstants.SESSION_CREDENTIALS];
			return credentials;
		}
	}
}