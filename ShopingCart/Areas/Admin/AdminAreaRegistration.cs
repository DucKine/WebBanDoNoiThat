using System.Web.Mvc;

namespace ShopingCart.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 

        {
            context.MapRoute(
                "Admin_Home",
                "Admin",
                new { controller ="HomeAdmin", action = "Index", id = UrlParameter.Optional },
                new [] { "ShopingCart.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new [] {"ShopingCart.Areas.Admin.Controllers"}
            );
        }
    }
}