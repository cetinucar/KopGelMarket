using KopGelMarket.Common;
using KopGelMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int? kategoriId, string ara,string sirala)
        {
           
            IQueryable<Urun> sorgu = db.Urunler;
            if (kategoriId != null)
            {
                sorgu = sorgu.Where(u => u.KategoriId == kategoriId);

            }
            if (!string.IsNullOrEmpty(ara))
            {
                sorgu = sorgu.Where(u => u.UrunAd.Contains(ara));
            }
            switch (sirala)
            {
                case "fiyatArtan":
                    sorgu = sorgu.OrderBy(x => x.BirimFiyat);
                        break;
                case "fiyatAzalan":
                    sorgu = sorgu.OrderByDescending(x => x.BirimFiyat);
                    break;
                case "isimArtan":
                    sorgu = sorgu.OrderBy(x => x.UrunAd);
                    break;
                case "isimAzalan":
                    sorgu = sorgu.OrderByDescending(x => x.UrunAd);
                    break;
                default:
                    break;
            }

            ViewBag.sirala = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Value="fiyatArtan", Text="Fiyata Göre Artan" },
                new SelectListItem{ Value="fiyatAzalan", Text="Fiyata Göre Azalan" },
                new SelectListItem{ Value="isimArtan", Text="İsme Göre (A-Z)" },
                new SelectListItem{ Value="isimAzalan", Text="İsme Göre (Z-A)" }
            },"Value","Text");



                  return View(sorgu.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult KategorilerPartial()
        {
            return PartialView("_Kategoriler", db.Kategoriler.OrderBy(x => x.KategoriAd).ToList());
        }
    }
}