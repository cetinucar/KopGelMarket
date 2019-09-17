using KopGelMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KopGelMarket.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public Kategori()
        {
            Urunler = new HashSet<Urun>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Kategori Ad alanı zorunludur")]
        [Display(Name ="Kategori Adı")]
        [StringLength(200,ErrorMessage ="Kategori adı 200 karakteri geçemez")]
        public string KategoriAd { get; set; }

        public virtual ICollection<Urun> Urunler { get; set; }
    }
}