using System;
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
    public class MovementController : ControllerBase
    {
        private readonly MarineContext _context;

        public MovementController(MarineContext context)
        {
            _context = context;
        }

        // GET: api/Movement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movement>>> GetMovement()
        {
            return await _context.Movement.ToListAsync();
        }

        // GET: api/Movement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movement>> GetMovement(int id)
        {
            var movement = await _context.Movement.FindAsync(id);

            if (movement == null)
            {
                return NotFound();
            }

            return movement;
        }

        // PUT: api/Movement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovement(int id, Movement movement)
        {
            if (id != movement.MovementId)
            {
                return BadRequest();
            }

            _context.Entry(movement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementExists(id))
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

        // POST: api/Movement
        [HttpPost]
        public async Task<ActionResult<Movement>> PostMovement(Movement movement)
        {
            _context.Movement.Add(movement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovement", new { id = movement.MovementId }, movement);
        }

        // DELETE: api/Movement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movement>> DeleteMovement(int id)
        {
            var movement = await _context.Movement.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }

            _context.Movement.Remove(movement);
            await _context.SaveChangesAsync();

            return movement;
        }

        private bool MovementExists(int id)
        {
            return _context.Movement.Any(e => e.MovementId == id);
        }
    }
}
