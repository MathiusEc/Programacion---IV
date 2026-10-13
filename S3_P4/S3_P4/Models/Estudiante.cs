using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3_P4.Models
{
    public class Estudiante
    {
        [Key]
        public int estudianteId { get; set; }
        [Required]
        public string nombre { get; set; }
        [Range(17,99)]
        public int edad { get; set; }
        public string carrera { get; set; }
    }
}