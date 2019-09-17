using KopGelMarket.Models;
using KopGelMarket.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Controllers
{
    public class SepetController : BaseController
    {
        // GET: Sepet
        public ActionResult Index()
        {
            return View(Sepet);
        }

        public ActionResult SepeteEkle(int id)
        {
            SepetOge sepetOge = Sepet.FirstOrDefault(x => x.UrunId == id);
            if (sepetOge == null)
            {
                Urun urun = db.Urunler.Find(id);
                sepetOge = new SepetOge
                {
                    UrunId = id,
                    UrunAd = urun.UrunAd,
                    KategoriAd =db.Kategoriler.Find(urun.KategoriId).KategoriAd,
                    BirimFiyat = urun.BirimFiyat,
                    ResimYolu = urun.ResimYolu,
                    Adet = 1
                };
                Sepet.Add(sepetOge);

            }
            else
            {
                sepetOge.Adet++;
            }

            return Json(new {ToplamUrunAdet=Sepet.Count});
        }

        [HttpPost]
        public ActionResult SepetUrunSil(int id)
        {
            Sepet.RemoveAll(x => x.UrunId == id);

            return Json(new { ToplamTutar=Sepet.Sum(x=>x.BirimFiyat*x.Adet).ToString("0.00"),UrunAdet=Sepet.Count});
        }

        [Authorize]
        public ActionResult Odeme()
        {
            ViewBag.SehirId = new SelectList(db.Sehirler.ToList(), "Id", "SehirAd");
            ViewBag.MusteriAd = db.Users.Find((User.Identity.GetUserId())).Ad;
            ViewBag.MusteriSoyad = db.Users.Find((User.Identity.GetUserId())).Soyad;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Odeme(OdemeViewModel odemeVm)
        {
 
            if (odemeVm.OdemeTutari!=Sepet.Sum(x=>x.Adet*x.BirimFiyat))
            {
                ModelState.AddModelError("OdemeTutari", "Sepetinizde değişiklik yaptığınız için ödeme tutar değişmiş");
                
            }
            if (ModelState.IsValid)
            {
                bool odemeSonuc = OdemeyiAl(odemeVm.OdemeTutari,odemeVm.KartNo,odemeVm.SonKullanmaTarihi,odemeVm.Cvv);
                if (!odemeSonuc)
                {
                    ModelState.AddModelError("OdemeTutari", "Kredi kartınızdan ödeme  yapılamadı.Lütfen bilgilerinizi kontrol ediniz");
                }
                if (odemeSonuc)
                {
                    Siparis siparis= new Siparis
                    {
                        MusteriId = User.Identity.GetUserId(),
                        MusteriAd = odemeVm.MusteriAd,
                        MusteriSoyad = odemeVm.MusteriSoyad,
                        MusteriEmail = odemeVm.MusteriEmail,
                        SehirId = odemeVm.SehirId,
                        MusteriAdres = odemeVm.MusteriAdres,
                        MusteriAdres2 = odemeVm.MusteriAdres2,
                        MusteriPostaKodu = odemeVm.MusteriPostaKodu,
                        OdemeTutari = odemeVm.OdemeTutari,
                        SiparisZamani = DateTime.Now,
                        SiparisDetaylar = new List<SiparisDetay>()
                    };
                    foreach (var item in Sepet)
                    {
                        siparis.SiparisDetaylar.Add(new SiparisDetay
                        {
                             UrunId=item.UrunId,
                            UrunAd =item.UrunAd,
                              BirimFiyat=item.BirimFiyat,
                               Adet=item.Adet,
                        });
                    }
                    db.Siparisler.Add(siparis);
                    db.SaveChanges();
                    Sepet.Clear();
                    TempData["SiparisId"] = siparis.Id;
                    return RedirectToAction("OdemeAlindi", "Sepet");
                }
            }
            ViewBag.SehirId = new SelectList(db.Sehirler.ToList(), "Id", "SehirAd");
            return View();
        }

        public ActionResult OdemeAlindi()
        {
            return View();

        }

        private bool OdemeyiAl(decimal odemeTutari, string kartNo, string sonKullanmaTarihi, string cvv)
        {

            //Ödeme sistemi apisi kullanılacak
            return true;
        }
    }
}