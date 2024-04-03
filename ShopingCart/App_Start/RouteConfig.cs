using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopingCart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
      new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
              name: "Add Cart",
              url: "them-vao-gio-hang",
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
              namespaces: new[] { "ShopingCart.Controllers" }
          );
            routes.MapRoute(
             name: "Product Detail",
             url: "chi-tiet-san-pham/{Slug}-{Id}",
             defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
             namespaces: new[] { "ShopingCart.Controllers" }
          );
            routes.MapRoute(
            name: "Projected",
            url: "thi-cong/{Slug}-{Id}",
            defaults: new { controller = "Projected", action = "Detail", id = UrlParameter.Optional },
            namespaces: new[] { "ShopingCart.Controllers" }
           );
            routes.MapRoute(
            name: "News Detail",
            url: "chi-tiet-tin-tuc/{Slug}-{ID}",
            defaults: new { controller = "News", action = "GetById", id = UrlParameter.Optional },
            namespaces: new[] { "ShopingCart.Controllers" }
            );
            routes.MapRoute(
              name: "du-an",
              url: "du-an",
              defaults: new { controller = "Projected", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ShopingCart.Controllers" }
          );
            routes.MapRoute(
              name: "gioi-thieu",
              url: "gioi-thieu",
              defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ShopingCart.Controllers" }
          );

            routes.MapRoute(
              name: "Lien He",
              url: "lien-he",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ShopingCart.Controllers" }
          );
            routes.MapRoute(
            name: "San Pham",
            url: "san-pham",
            defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "ShopingCart.Controllers" }
          );
          //  routes.MapRoute(
          //  name: "Bao Gia",
          //  url: "bao-gia",
          //  defaults: new { controller = "Baogia", action = "Index", id = UrlParameter.Optional },
          //  namespaces: new[] { "ShopingCart.Areas.Admin.Controllers" }
          //);
            //            routes.MapRoute(
            //   name: "Don Hang",
            //   url: "admin/don-hang",
            //   defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional },
            //   namespaces: new[] { "ShopingCart.Areas.Admin.Controllers" }
            //);
            routes.MapRoute(
             name: "Danh Muc San Pham",
             url: "danh-muc-san-pham/{Slug}-{Id}",
             defaults: new { controller = "Product", action = "CategoryViewDetail", id = UrlParameter.Optional },
             namespaces: new[] { "ShopingCart.Controllers" }
);

                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"ShopingCart.Controllers"}
            );   
        }
    }
}
