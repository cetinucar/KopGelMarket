using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KopGelMarket.Models
{
    [Table("Siparisler")]
    public class Siparis
    {
        public int Id { get; set; }

        [ForeignKey("Musteri")]
        public string MusteriId { get; set; }

        [Required]
        public int SehirId { get; set; }

        [Required]
        public string MusteriAd { get; set; }

        [Required]
        public string MusteriSoyad { get; set; }

        [Required]
        public string MusteriEmail { get; set; }

        [Required]
        public string MusteriAdres { get; set; }

        public string MusteriAdres2 { get; set; }

        [Required]
        public string MusteriPostaKodu { get; set; }

        public decimal OdemeTutari { get; set; }

        [Required]
        public DateTime? SiparisZamani { get; set; }

        public virtual ApplicationUser Musteri { get; set; }

        public virtual Sehir Sehir { get; set; }

        public virtual ICollection<SiparisDetay> SiparisDetaylar { get; set; }
    }
}