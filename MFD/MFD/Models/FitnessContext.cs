using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MFD.Models
{
    public class FitnessContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}