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
    }
}
