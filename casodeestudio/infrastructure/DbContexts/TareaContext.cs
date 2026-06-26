using CasodeEstudio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CasodeEstudio.infrastructure.DbContexts
{
    public class TareaDbContext : DbContext
    {
        
        public TareaDbContext() : base("name=ConexionToDo")
        {
        }
        
        public DbSet<Tarea> Tareas { get; set; }
    }
}