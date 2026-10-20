using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S1_SailorMoon.Models
{
    public class Aliado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreAliado { get; set; }
        public string Tipo { get; set; }
        [Range (1,10000, ErrorMessage ="La edad debe estar en ese rango")]
        public int Edad { get; set; }
        public int SailorSenshiId { get; set; }
    }
}