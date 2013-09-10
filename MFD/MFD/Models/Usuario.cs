using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MFD.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nick { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public int edad { get; set; }
        public float peso { get; set; }
        public float altura { get; set; }
        public DateTime fechaRegistro { get; set; }
        public virtual ICollection<Receta> Recetas { get; set; }
    }
}