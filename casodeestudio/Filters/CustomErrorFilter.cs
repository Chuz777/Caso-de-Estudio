using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace casodeestudio.Filters
{
    public class CustomErrorFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                
                Log.Error(filterContext.Exception, $"[ERROR GLOBAL] Ocurrió una falla en: {filterContext.RouteData.Values["controller"]}/{filterContext.RouteData.Values["action"]}");

                
                filterContext.ExceptionHandled = true;

                
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }

    }
}