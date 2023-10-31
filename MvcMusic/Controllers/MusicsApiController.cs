using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMusic.Data;
using MvcMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsApiController : Controller
    {
        private readonly MvcMusicContext _context;

        public MusicsApiController(MvcMusicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Music> Index()
        {
            return _context.Music;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Index(int id)
        {
            var music = await _context.Music.FindAsync(id);
            var music01 = (from m in _context.Music
                           where m.Id == id
                           select m).ToList();
            if (music == null)
                return NotFound();
            return Ok(music);
        }


        [HttpPut("{id}")]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMusic(int id, [Bind("Title,ReleaseDate,Genre,Rating")] [FromBody]Music music)
        {
            if (music is null)
            {
                throw new ArgumentNullException(nameof(music));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _context.Music.FindAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            result.Title = music.Title;
            result.ReleaseDate = music.ReleaseDate;
            result.Genre = music.Genre;
            result.Rating = music.Rating;

            try
            {
                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.Music.Add(music);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMusic", new { id = music.Id }, music);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var result = await _context.Music.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Music.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MusicExist(int id)
        {
            return _context.Music.Any(x => x.Id == id);
        }
    }
}
