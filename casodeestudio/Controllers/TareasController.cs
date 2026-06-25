using CasodeEstudio.infrastructure.DbContexts;
using CasodeEstudio.Models;
using Serilog;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web.Mvc;

namespace CasodeEstudio.Controllers
{
    public class TareasController : Controller
    {
        // Lista temporal en memoria (luego la reemplazamos con la BD)
        //private static List<Tarea> _tareas = new List<Tarea>();
        //private static int _nextId = 1;
        private readonly TareaDbContext _context = new TareaDbContext();


        public ActionResult Index()
        {
            //return View(_tareas);
            var listaTareas = _context.Tareas.ToList();
            return View(listaTareas);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                Log.Information($"[NEGOCIO] Tarea creada exitosamente con ID: {tarea.Id} - Título: {tarea.Titulo}");

                TempData["Exito"] = "Tarea creada correctamente."; // Alerta Bootstrap
                return RedirectToAction("Index");

                //tarea.Id = _nextId++;
               // _tareas.Add(tarea);
               // TempData["Exito"] = "Tarea creada correctamente.";
               // return RedirectToAction("Index");
            }
            return View(tarea);
        }

        public ActionResult Detalle(int id)
        {
            //var tarea = _tareas.Find(t => t.Id == id);
            var tarea = _context.Tareas.Find(id);
            if (tarea == null) return HttpNotFound();
            return View(tarea);
        }

        public ActionResult Editar(int id)
        {
            //var tarea = _tareas.Find(t => t.Id == id);
            var tarea = _context.Tareas.Find(id);
            if (tarea == null) return HttpNotFound();
            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(tarea).State = EntityState.Modified;
                _context.SaveChanges();

                Log.Information($"[NEGOCIO] Tarea modificada con éxito. ID: {tarea.Id} - Nuevo Estado: {tarea.Estado}");

                TempData["Exito"] = "Tarea actualizada correctamente.";
                return RedirectToAction("Index");

                //var existente = _tareas.Find(t => t.Id == tarea.Id);
                //if (existente != null)
                //{
                //   existente.Titulo = tarea.Titulo;
                //   existente.Detalle = tarea.Detalle;
                //   existente.FechaHora = tarea.FechaHora;
                //   existente.Estado = tarea.Estado;
                // }
                //TempData["Exito"] = "Tarea actualizada correctamente.";
                // return RedirectToAction("Index");
            }
            return View(tarea);
        }

        public ActionResult Eliminar(int id)
        {
            //var tarea = _tareas.Find(t => t.Id == id);
            var tarea = _context.Tareas.Find(id);
            if (tarea == null) return HttpNotFound();
            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, FormCollection form)
        {
            var tarea = _context.Tareas.Find(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();

                Log.Information($"[NEGOCIO] Tarea eliminada permanentemente. ID: {id} - Título era: {tarea.Titulo}");
            }

            TempData["Exito"] = "Tarea eliminada correctamente.";
            return RedirectToAction("Index");

            //var tarea = _tareas.Find(t => t.Id == id);
            //if (tarea != null) _tareas.Remove(tarea);
            //TempData["Exito"] = "Tarea eliminada correctamente.";
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}