﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessDaw
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FitnessDbEntities1 : DbContext
    {
        public FitnessDbEntities1()
            : base("name=FitnessDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<articulo> articuloes { get; set; }
        public DbSet<calendario> calendarios { get; set; }
        public DbSet<receta> recetas { get; set; }
        public DbSet<usuario> usuarios { get; set; }
    }
}
