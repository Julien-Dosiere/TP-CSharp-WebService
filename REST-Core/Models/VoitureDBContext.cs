using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Core.Models
{
    public class VoitureDBContext: DbContext
    {
        public DbSet<Voiture> Voitures { get; set; }
        public VoitureDBContext(DbContextOptions<VoitureDBContext> options) : base(options) { }
    }
}
