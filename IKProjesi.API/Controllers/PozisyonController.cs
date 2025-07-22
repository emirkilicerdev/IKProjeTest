using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IKProjesi.API.Data;
using IKProjesi.API.Models;

namespace IKProjesi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PozisyonController : ControllerBase
    {
        private readonly IKDbContext _context;

        public PozisyonController(IKDbContext context)
        {
            _context = context;
        }

        // GET: api/Pozisyon/Listele
        [HttpGet("Listele")]
        public async Task<ActionResult<IEnumerable<Pozisyon>>> GetPozisyonlar()
        {
            return await _context.Pozisyonlar.ToListAsync();
        }

        // GET: api/Pozisyon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozisyon>> GetPozisyon(int id)
        {
            var pozisyon = await _context.Pozisyonlar.FindAsync(id);
            if (pozisyon == null)
                return NotFound();

            return pozisyon;
        }

        // POST: api/Pozisyon/Ekle
        [HttpPost("Ekle")]
        public async Task<ActionResult<Pozisyon>> PostPozisyon(Pozisyon pozisyon)
        {
            _context.Pozisyonlar.Add(pozisyon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPozisyon), new { id = pozisyon.PozisyonID }, pozisyon);
        }

        // PUT: api/Pozisyon/Duzenle/5
        [HttpPut("Duzenle/{id}")]
        public async Task<IActionResult> PutPozisyon(int id, Pozisyon pozisyon)
        {
            if (id != pozisyon.PozisyonID)
                return BadRequest();

            _context.Entry(pozisyon).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Pozisyon/sil/5
        [HttpDelete("sil/{id}")]
        public async Task<IActionResult> DeletePozisyon(int id)
        {
            var pozisyon = await _context.Pozisyonlar.FindAsync(id);
            if (pozisyon == null)
                return NotFound();

            _context.Pozisyonlar.Remove(pozisyon);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
