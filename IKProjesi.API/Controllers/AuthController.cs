using IKProjesi.API.Data;
using IKProjesi.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IKProjesi.API.Utils;
using Microsoft.AspNetCore.Authorization;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IKDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(IKDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        var calisan = await _context.Calisanlar
            .Include(c => c.Sifre)
            .Include(c => c.Pozisyon) // Rol bilgisi için pozisyon eklenmeli
            .FirstOrDefaultAsync(c => c.Email == model.Email);

        if (calisan == null)
            return NotFound("Kullanıcı bulunamadı.");

        var hashedPassword = PasswordHasher.HashPassword(model.Sifre);

        if (calisan.Sifre == null || calisan.Sifre.SifreHash != hashedPassword)
            return Unauthorized("Şifre yanlış.");

        // Örnek: PozisyonAdı rol olarak alınır
        string role = calisan.Pozisyon?.PozisyonAdi ?? "Calisan";

        var token = _jwtService.GenerateToken(calisan.CalisanID, calisan.Email, role);

        return Ok(new { Token = token, Role = role });
    }
}
