using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarineFarm.Models
{
    public class MarineContext:DbContext
    {
        public MarineContext(DbContextOptions<MarineContext> options): base(options)
        {

        }
        public DbSet<Tank> Tank { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Movement> Movement { get; set; }
    }
}
