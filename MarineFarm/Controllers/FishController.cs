using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarineFarm.Models;

namespace MarineFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly MarineContext _context;

        public FishController(MarineContext context)
        {
            _context = context;
        }

        // GET: api/Fish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fish>>> GetFish()
        {
            return await _context.Fish.ToListAsync();
        }

        // GET: api/Fish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fish>> GetFish(int id)
        {
            var fish = await _context.Fish.FindAsync(id);

            if (fish == null)
            {
                return NotFound();
            }

            return fish;
        }

        // GET: api/Fish/5/
        [HttpGet("{id}/movements")]
        public async Task<ActionResult<IEnumerable<Movement>>> GetMovement(int id)
        {
            var movements = await _context.Movement.Where(m => m.FishId == id).ToListAsync();

            if (movements == null)
            {
                return NotFound();
            }

            return movements;
        }

        [HttpPut("{fishId}/{tankId}")]
        public async Task<IActionResult> MoveFish(int fishId, int tankId)
        {
            var fish = await _context.Fish.FirstOrDefaultAsync(f => f.FishId == fishId);

            var currentTank = await _context.Tank.FirstAsync(t => t.TankId == fish.TankId);

            var destinationTank = await _context.Tank.FirstAsync(t => t.TankId == tankId);


            if (fish == null)
            {
                return NotFound();
            }

            var tankIsFull = destinationTank.NumberOfFish >= destinationTank.Capacity;

            if (tankIsFull)
            {
                return BadRequest("Tank full");
            }


            _context.Movement.Add(new Movement { FishId = fishId, TankIdTo = tankId, TankIdFrom = fish.TankId});

            currentTank.NumberOfFish--;
            destinationTank.NumberOfFish++;
            fish.TankId = tankId;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Fish/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFish(int id, Fish fish)
        {
            if (id != fish.FishId)
            {
                return BadRequest();
            }

            _context.Entry(fish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FishExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fish
        [HttpPost]
        public async Task<ActionResult<Fish>> PostFish(Fish fish)
        {
           var desiredTank = await _context.Tank.FirstAsync(t => t.TankId == fish.TankId);           

            if (desiredTank.NumberOfFish == desiredTank.Capacity)
                {
                    return BadRequest("Tank is full");
                }

            desiredTank.NumberOfFish++;
            
            _context.Fish.Add(fish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFish", new { id = fish.FishId }, fish);
        }

        // DELETE: api/Fish/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fish>> DeleteFish(int id)
        {       
            var fish = await _context.Fish.FindAsync(id);
            var tank = await _context.Tank.FirstAsync(t => t.TankId == fish.TankId);

            if (fish == null)
            {
                return NotFound();
            }

            tank.NumberOfFish--;
            _context.Fish.Remove(fish);

            await _context.SaveChangesAsync();

            return fish;
        }

        private bool FishExists(int id)
        {
            return _context.Fish.Any(e => e.FishId == id);
        }


    }
}
