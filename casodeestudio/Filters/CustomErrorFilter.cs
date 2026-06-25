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
                // Registramos el error técnico exacto en Serilog
                Log.Error(filterContext.Exception, $"[ERROR GLOBAL] Ocurrió una falla en: {filterContext.RouteData.Values["controller"]}/{filterContext.RouteData.Values["action"]}");

                // Marcamos el error como manejado para que no se caiga de forma fea
                filterContext.ExceptionHandled = true;

                // Redirigimos a la vista amigable por defecto de ASP.NET "Error" ubicada en Views/Shared
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }

    }
}