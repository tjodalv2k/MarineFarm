using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarineFarm.Models;

namespace MarineFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankController : ControllerBase
    {
        private readonly MarineContext _context;

        public TankController(MarineContext context)
        {
            _context = context;
        }

        // GET: api/Tank
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tank>>> GetTank()
        {
            return await _context.Tank.ToListAsync();
        }

        // GET: api/Tank/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tank>> GetTank(int id)
        {
            var tank = await _context.Tank.FindAsync(id);

            if (tank == null)
            {
                return NotFound();
            }

            return tank;
        }

        // PUT: api/Tank/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTank(int id, Tank tank)
        {
            if (id != tank.TankId)
            {
                return BadRequest();
            }

            _context.Entry(tank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TankExists(id))
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

        // POST: api/Tank
        [HttpPost]
        public async Task<ActionResult<Tank>> PostTank(Tank tank)
        {
            _context.Tank.Add(tank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTank", new { id = tank.TankId }, tank);
        }

        // DELETE: api/Tank/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tank>> DeleteTank(int id)
        {
            var tank = await _context.Tank.FindAsync(id);
            if (tank == null)
            {
                return NotFound();
            }

            _context.Tank.Remove(tank);
            await _context.SaveChangesAsync();

            return tank;
        }

        private bool TankExists(int id)
        {
            return _context.Tank.Any(e => e.TankId == id);
        }
    }
}
