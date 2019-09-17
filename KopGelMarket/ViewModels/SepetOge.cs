using KopGelMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KopGelMarket.ViewModels
{
    public class SepetOge
    {
        public int UrunId { get; set; }

        public string UrunAd { get; set; }

        public string KategoriAd { get; set; }

        public int Adet { get; set; }

        public decimal BirimFiyat { get; set; }

        public string ResimYolu { get; set; }

       public decimal Tutar()
        {
            return Adet * BirimFiyat;
        }
    }
}