using KopGelMarket.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Areas.Admin.Controllers
{
    public class UrunController : AdminBaseController
    {
        // GET: Admin/Urun
        public ActionResult Index()
        {
            return View(db.Urunler.ToList()); ;
        }

        // GET: Admin/Urun/Yeni
        public ActionResult Yeni()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            return View();
        }

        // Post: Admin/Urun/Yeni
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Yeni(Urun urun, HttpPostedFileBase foto)
        {
            if (foto != null)
            {
                if (!foto.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("hataAnahtarı", "Lütfen bir resim dosyası seçiniz");
                }
            }
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    string uzanti = Path.GetExtension(foto.FileName);
                    string dosyaAd = Guid.NewGuid() + uzanti;
                    string dosyaYolu = Path.Combine(Server.MapPath("~/Upload/"), dosyaAd);
                    foto.SaveAs(dosyaYolu);
                    urun.ResimYolu = dosyaAd;
                }
                db.Urunler.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    islem = "eklendi",
                    mesaj = urun.UrunAd + " adlı ürün eklendi"

                });
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            return View();
        }

        // Post: Admin/Urun/Sil
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Sil(int id)
        {
            Urun silinecek = db.Urunler.Find(id);
            string resimTamYol = Server.MapPath("~/Upload/" + silinecek.ResimYolu);
            if (silinecek.ResimYolu != null)
            {
                if (System.IO.File.Exists(resimTamYol))
                {
                    System.IO.File.Delete(resimTamYol);
                }
            }

            db.Urunler.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index", new
            {
                islem = "silindi",
                mesaj = silinecek.UrunAd + " adlı ürün silindi"

            });
        }

        // GET: Admin/Urun/Duzenle
        public ActionResult Duzenle(int id)
        {
            ViewBag.Action = "Duzenle";
            Urun duzenlenecek = db.Urunler.Find(id);
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");

            return View("Yeni", duzenlenecek);
        }


        // POST: Admin/Urun/Duzenle
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Duzenle(Urun urun, HttpPostedFileBase foto)
        {
            ViewBag.Action = "Duzenle";
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            if (foto != null)
            {
                if (!foto.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("hataAnahtarı", "Lütfen bir resim dosyası seçiniz");
                }
            }
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    if (urun.ResimYolu != null)
                    {
                        string resimTamYolu = Server.MapPath("~/Upload/" + urun.ResimYolu);
                        if (System.IO.File.Exists(resimTamYolu))
                        {
                            System.IO.File.Delete(resimTamYolu);
                        }
                    }
                    string uzanti = Path.GetExtension(foto.FileName);
                    string dosyaAd = Guid.NewGuid() + uzanti;
                    string dosyaYolu = Path.Combine(Server.MapPath("~/Upload/"), dosyaAd);
                    foto.SaveAs(dosyaYolu);
                    urun.ResimYolu = dosyaAd;

                }
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    islem = "guncellendi",
                    mesaj = urun.UrunAd + " adlı ürün güncellendi"

                });
            }
            return View("Yeni", urun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListeSil(IEnumerable<int> idler)
        {
            //resimlerini sil

            List<Urun> urunler = db.Urunler.Where(u => idler.Contains(u.Id)).ToList();

            foreach (var item in urunler)
            {
                if (item.ResimYolu != null)
                {
                    string resimTamYol = Server.MapPath("~/Upload/" + item.ResimYolu);
                    if (System.IO.File.Exists(resimTamYol))
                    {
                        System.IO.File.Delete(resimTamYol);
                    }
                }
            }

            if (idler != null)
            {
                db.Urunler.Where(u => idler.Contains(u.Id)).ToList().ForEach(x => db.Urunler.Remove(x));
                db.SaveChanges();
            }
            int uzunluk = idler.Count();
            return RedirectToAction("Index", new
            {
                islem = "ListeSilindi",
                mesaj = uzunluk + " ürün başarıyla silindi"


            });
        }

    }
}
