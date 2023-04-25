using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectGroup2.Models;
using FinalProjectGroup2.Context;

namespace FinalProjectGroup2.Controllers
{
    //add hobby controller
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly HobbyContext _context;

        public HobbyController(HobbyContext context)
        {
            _context = context;
        }

        // GET: api/Hobby
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobby>>> GetHobbies()
        {
          if (_context.Hobbies == null)
          {
              return NotFound();
          }
            return await _context.Hobbies.ToListAsync();
        }

        // GET: api/GetHobby/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Hobby>>> GetHobby(int? id)
        {
          if (_context.Hobbies == null)
          {
              return NotFound();
          }
            List<Hobby> hobby = new List<Hobby>();
            if (id==0 || id==null)
            {
                hobby = await _context.Hobbies.Take(5).ToListAsync();

            }
            else
            {
                hobby = await _context.Hobbies.Where(h => h.HobbyID==id).ToListAsync();

            }

            if (hobby == null)
            {
                return NotFound();
            }

            return hobby;
        }

        // PUT: api/PutHobby/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHobby(int id, Hobby hobby)
        {
            if (id != hobby.HobbyID)
            {
                return BadRequest();
            }

            _context.Entry(hobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HobbyExists(id))
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

        // POST: api/PostHobby
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hobby>> PostHobby(Hobby hobby)
        {
          if (_context.Hobbies == null)
          {
              return Problem("Entity set 'DatabaseContext.Hobbies'  is null.");
          }
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHobby", new { id = hobby.HobbyID }, hobby);
        }

        // DELETE: api/Hobby/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHobby(int id)
        {
            if (_context.Hobbies == null)
            {
                return NotFound();
            }
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HobbyExists(int id)
        {
            return (_context.Hobbies?.Any(e => e.HobbyID == id)).GetValueOrDefault();
        }
    }
}
