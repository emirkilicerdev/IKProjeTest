using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IKProjesi.API.Data;
using IKProjesi.API.Models;

namespace IKProjesi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmanController : ControllerBase
    {
        private readonly IKDbContext _context;

        public DepartmanController(IKDbContext context)
        {
            _context = context;
        }

        // GET: api/Departman/Listele
        [HttpGet("Listele")]
        public async Task<ActionResult<IEnumerable<Departman>>> GetDepartmanlar()
        {
            return await _context.Departmanlar.ToListAsync();
        }

        // GET: api/Departman/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departman>> GetDepartman(int id)
        {
            var departman = await _context.Departmanlar.FindAsync(id);
            if (departman == null)
                return NotFound();

            return departman;
        }

        // POST: api/Departman/Ekle
        [HttpPost("Ekle")]
        public async Task<ActionResult<Departman>> PostDepartman(Departman departman)
        {
            _context.Departmanlar.Add(departman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartman), new { id = departman.DepartmanID }, departman);
        }

        // PUT: api/Departman/Duzenle/5
        [HttpPut("Duzenle/{id}")]
        public async Task<IActionResult> PutDepartman(int id, Departman departman)
        {
            if (id != departman.DepartmanID)
                return BadRequest();

            _context.Entry(departman).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Departman/sil/5
        [HttpDelete("sil/{id}")]
        public async Task<IActionResult> DeleteDepartman(int id)
        {
            var departman = await _context.Departmanlar.FindAsync(id);
            if (departman == null)
                return NotFound();

            _context.Departmanlar.Remove(departman);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
