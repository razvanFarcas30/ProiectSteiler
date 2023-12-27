using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectSteiler.Models;

namespace ProiectSteiler.Data
{
    public class ProiectSteilerContext : DbContext
    {
        public ProiectSteilerContext (DbContextOptions<ProiectSteilerContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectSteiler.Models.Salon> Salon { get; set; } = default!;

        public DbSet<ProiectSteiler.Models.Stilist>? Stilist { get; set; }
    }
}
