using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KopGelMarket.Models
{
    [Table("Urunler")]
    public class Urun
    {
        public int Id { get; set; }

        [Display(Name ="Kategori")]
        public int KategoriId { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Urun Ad Alanı zorunludur")]
        [StringLength(200,ErrorMessage ="Ürün adı 200 karakteri geçemez")]
        public string UrunAd { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Birim Fiyatı")]
        [Required(ErrorMessage = "Birim Fiyat Alanı zorunludur")]
        public decimal BirimFiyat { get; set; }

        [Display(Name = "Resim Yolu")]
        [StringLength(200,ErrorMessage ="Resim Yolu 200 karakteri geçemez")]
        public string ResimYolu { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}