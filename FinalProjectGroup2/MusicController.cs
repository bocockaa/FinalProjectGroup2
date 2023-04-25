


using FinalProjectGroup2;
using FinalProjectGroup2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectGroup2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly  MusicContext _context;

        public MusicController(MusicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusicFavs(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.Musicc.Take(5).ToListAsync();
            }
            else
            {
                return await _context.Musicc.Where(tm => tm.Id == id).ToListAsync();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusicFav(int id)
        {
            var musicFav = await _context.Musicc.FindAsync(id);

            if (musicFav == null)
            {
                return NotFound();
            }

            return musicFav;
        }

        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music musicFav)
        {
            _context.Musicc.Add(musicFav);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusicFavs), new { id = musicFav.Id }, musicFav);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicFav(int id, Music musicFav)
        {
            if (id != musicFav.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicFav).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var musicFav = await _context.Musicc.FindAsync(id);

            if (musicFav == null)
            {
                return NotFound();
            }

            _context.Musicc.Remove(musicFav);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
