using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MFD.Models
{
    public class Articulo
    {
        [Key]
        public int idArticulo { get; set; }
        public string tipo { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
    }
}