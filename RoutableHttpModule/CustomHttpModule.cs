using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RoutableHttpModule
{
    public class CustomHttpModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {

            application.BeginRequest +=  (new EventHandler(this.Application_BeginRequest));
          
          
        }

        private void Application_BeginRequest(Object source,EventArgs e)
        {

            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            var contextBase = context.Request.RequestContext.HttpContext;
            if (IsRequestInRoutes(contextBase))
            {
                Console.WriteLine("Request Matches:"+context.Request.Url);
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private bool IsRequestInRoutes(HttpContextBase context)
        {
            var data = RouteTable.Routes.GetRouteData(context);
            return data != null;
        }
    }
}