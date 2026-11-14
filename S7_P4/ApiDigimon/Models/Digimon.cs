using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiDigimon.Models
{
    public class Digimon
    {
        [Key]
        public int DigimonId { get; set; }
        public string Nombre { get; set; }
        public string Etapa { get; set; }
    }
}
