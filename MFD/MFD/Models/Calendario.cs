using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MFD.Models
{
    public class Calendario
    {
        [Key]
        public int idcalendario { get; set; }
        public int idUsuario { get; set; }
    }
}