using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Model;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicContext _context;

        public MusicController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/Music
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> GetSong()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Music/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // PUT: api/Music/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            if (id != songs.id)
            {
                return BadRequest();
            }

            _context.Entry(songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(id))
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

        // POST: api/Music
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            _context.Songs.Add(songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSongs), new { id = songs.id }, songs);
        }

        // DELETE: api/Music/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Songs>> DeleteSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();

            return songs;
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.id == id);
        }
    }
}
