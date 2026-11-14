using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiDigimon.Models
{
    public class DigimonContext : DbContext
    {
        public DigimonContext() : base("name=DigimonConnection") { }

        public DbSet<Domador> Domadores { get; set; }
        public DbSet<Digimon> Digimones { get; set; }
    }
}
