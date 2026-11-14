using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiDigimon.Models
{
    public class Domador
    {
        [Key]
        public int DomadorId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
