using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IKProjesi.API.Data;
using IKProjesi.API.Models;
using IKProjesi.API.Utils;

namespace IKProjesi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalisanController : ControllerBase
    {
        private readonly IKDbContext _context;

        public CalisanController(IKDbContext context)
        {
            _context = context;
        }

        // GET: api/Calisan/listele
        [HttpGet("Listele")]
        public async Task<ActionResult<IEnumerable<Calisan>>> GetCalisanlar()
        {
            return await _context.Calisanlar.ToListAsync();
        }

        // GET: api/Calisan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calisan>> GetCalisan(int id)
        {
            var calisan = await _context.Calisanlar.FindAsync(id);

            if (calisan == null)
                return NotFound();

            return calisan;
        }

        // POST: api/Calisan/ekle
        [HttpPost("Ekle")]
        public async Task<ActionResult<Calisan>> PostCalisan(Calisan calisan)
        {

            if (calisan.PozisyonID.HasValue)
            {
                calisan.Pozisyon = null;
            }


            if (calisan.Sifre != null && !string.IsNullOrEmpty(calisan.Sifre.SifreHash))
            {
                calisan.Sifre.SifreHash = PasswordHasher.HashPassword(calisan.Sifre.SifreHash);
            }

            _context.Calisanlar.Add(calisan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalisan), new { id = calisan.CalisanID }, calisan);
        }

        // PUT: api/Calisan/duzenler/5
        [HttpPut("Duzenle/{id}")]
        public async Task<IActionResult> PutCalisan(int id, Calisan calisan)
        {
            if (id != calisan.CalisanID)
                return BadRequest();

            _context.Entry(calisan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Calisan/sil/5
        [HttpDelete("sil/{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
                return NotFound();

            _context.Calisanlar.Remove(calisan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
