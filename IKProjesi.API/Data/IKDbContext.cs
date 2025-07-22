using Microsoft.EntityFrameworkCore;
using IKProjesi.API.Models;

namespace IKProjesi.API.Data
{
    public class IKDbContext : DbContext
    {
        public IKDbContext(DbContextOptions<IKDbContext> options) : base(options) { }

        public DbSet<Calisan> Calisanlar => Set<Calisan>();
        public DbSet<Departman> Departmanlar => Set<Departman>();
        public DbSet<Pozisyon> Pozisyonlar => Set<Pozisyon>();
        public DbSet<CalisanSifre> CalisanSifreler => Set<CalisanSifre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Calisan>()
                .HasOne(c => c.Sifre)
                .WithOne(cs => cs.Calisan)
                .HasForeignKey<CalisanSifre>(cs => cs.CalisanID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
