using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MFD.Models
{
    public class Receta
    {
        [Key]
        public int idReceta { get; set; }
        public int idUsuario { get; set; } //Foreign key
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public float calorias { get; set; }
        public float proteinas { get; set; }
        public float grasas { get; set; }
        public float carboidratos { get; set; }
        public int calificacion { get; set; }
        public virtual Usuario Usuario { get; set; } //Navigation property
    }
}