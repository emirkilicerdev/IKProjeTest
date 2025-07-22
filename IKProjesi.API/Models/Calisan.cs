namespace IKProjesi.API.Models
{
    public class Calisan
    {
        public int CalisanID { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefon { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public int? DepartmanID { get; set; }
        public int? PozisyonID { get; set; }
        public decimal Maas { get; set; }
        public bool Aktif { get; set; } = true;

        // Navigation Property
        public virtual CalisanSifre? Sifre { get; set; }
        public virtual Pozisyon? Pozisyon { get; set; }
    }
}
