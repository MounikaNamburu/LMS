using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Login", action = "Index", EmailID = UrlParameter.Optional, Password = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "Admin",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
           );


            routes.MapRoute(
                name: "Forgot",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FacultyReg", action = "Index", EmailID = UrlParameter.Optional, Password = UrlParameter.Optional }
                );


            routes.MapRoute(
                name: "ForgotP",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ForgotPass", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Reset",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ResetPassword", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ResetP",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ResetPassword", action = "Index", Password = UrlParameter.Optional, newPassword = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddFaculty",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FacultyRegistration", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                   name: "AddFaculty1",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "FacultyRegistration", action = "Create", Faculty_Registration = UrlParameter.Optional }
              );
        }
    
    }
}
