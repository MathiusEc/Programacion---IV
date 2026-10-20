using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S1_SailorMoon.Models
{
    public class SailorSenshi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Planeta { get; set; }
        [Range (1,100, ErrorMessage = "El nivel de poder debe estar entre 1 y 100.")]
        public int NivelPoder { get; set; }
        public string HabilidadEspecial { get; set; }

    }
}