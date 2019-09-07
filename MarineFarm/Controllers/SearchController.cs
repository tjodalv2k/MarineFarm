using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarineFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly MarineContext _context;

        public SearchController(MarineContext context)
        {
            _context = context;
        }


        [HttpGet("{fishId}")]
        public async Task<ActionResult<IEnumerable<Tank>>> Get(int fishId)
        {
            var fishes = await _context.Fish.ToListAsync();

            var tanks = await _context.Tank.ToListAsync();

            
            var currentFish = fishes.FirstOrDefault(f => f.FishId == fishId);
            var otherTanks = tanks.Where(t => t.TankId != currentFish.TankId);

            try
            {
                return otherTanks.Where(t => fishes.Where(f => f.TankId == t.TankId).ToList().Count < t.Capacity).ToList();
            }
            catch (Exception e)
            {

                return null;
            }
            

        }
    }
}