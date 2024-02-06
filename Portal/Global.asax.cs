using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Portal
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {



        

                RegisterRoutes(RouteTable.Routes);

                RegisterRoutes1(RouteTable.Routes);

        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("EditBlog", "Blogs/{BlogId}.aspx", "~/EditBlog.aspx");
            
            
        }

        static void RegisterRoutes1(RouteCollection routes)
        {
            
            routes.MapPageRoute("DisplayBlog", "Blogs/{BlogId}/{Slug}.aspx", "~/DisplayBlog.aspx");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}