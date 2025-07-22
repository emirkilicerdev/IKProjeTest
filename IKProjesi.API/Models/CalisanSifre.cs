using System.ComponentModel.DataAnnotations.Schema;

namespace IKProjesi.API.Models
{
    [Table("CalisanSifreler")]
    public class CalisanSifre
    {
        public int CalisanSifreID { get; set; }
        public int CalisanID { get; set; }
        public string SifreHash { get; set; } = null!;

        [ForeignKey("CalisanID")]
        public virtual Calisan Calisan { get; set; } = null!;
    }
}
