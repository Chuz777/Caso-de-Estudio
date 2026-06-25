using System;
using System.Web.Mvc;
using Serilog;

namespace casodeestudio.Filters
{
    public class AuditoriaFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Captura los datos de navegación solicitados por la rúbrica
            string controlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string accion = filterContext.ActionDescriptor.ActionName;
            string fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Escribe en el archivo físico .txt de la carpeta Logs
            Log.Information($"[AUDITORIA] Fecha/Hora: {fechaHora} | Controlador: {controlador} | Acción: {accion}");

            base.OnActionExecuting(filterContext);



            //public override void OnActionExecuting(ActionExecutingContext filterContext)
            // {
            // Capturamos los datos de la ruta dinámica
            //     string controlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //     string accion = filterContext.ActionDescriptor.ActionName;
            //     string fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Escribimos el log estructurado de auditoría en el archivo de texto

            //     Log.Information($"[AUDITORIA] Fecha/Hora: {fechaHora} | Controlador: {controlador} | Acción: {accion}");

            //    base.OnActionExecuting(filterContext);
            //  }

        }
    }
}