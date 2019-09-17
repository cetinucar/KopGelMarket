using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KopGelMarket.ViewModels
{
    public class OdemeViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string MusteriAd { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string MusteriSoyad { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [EmailAddress(ErrorMessage ="Email adresiniz uygun biçimde girilmedi")]
        public string MusteriEmail { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string MusteriAdres { get; set; }

        [Display(Name = "Adres-2")]
        public string MusteriAdres2 { get; set; }

        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public int SehirId { get; set; }

        [Display(Name = "Posta Kodu")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string MusteriPostaKodu { get; set; }

        [Display(Name = "Kart Sahibi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string KartSahibi { get; set; }

        [Display(Name = "Kart No")]
        [Required(ErrorMessage ="{0} alanı zorunludur")]
        public string KartNo { get; set; }

        [Display(Name = "Son Kullanma Tarihi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string SonKullanmaTarihi { get; set; }

        [Display(Name ="CVV")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string Cvv { get; set; }

        [Required]
        public decimal OdemeTutari { get; set; }
    }
}