using ShopingCart.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session[CommonConstants.SESSION_CREDENTIALS];

            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admin" }));
            }

            base.OnActionExecuting(filterContext);
        }
        

	}
}