using CasodeEstudio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CasodeEstudio.infrastructure.DbContexts
{// Heredamos de DbContext para activar Entity Framework 6
    public class TareaDbContext : DbContext
    {
        // "ConexionToDo" es el nombre exacto de la cadena de conexión que pondremos en el Web.config
        public TareaDbContext() : base("name=ConexionToDo")
        {
        }
        // Esta propiedad le dice al ORM que cree la tabla "Tareas" mapeando el modelo "Tarea"
        public DbSet<Tarea> Tareas { get; set; }
    }
}