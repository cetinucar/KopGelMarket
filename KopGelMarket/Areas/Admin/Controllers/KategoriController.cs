using KopGelMarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Areas.Admin.Controllers
{
    public class KategoriController :AdminBaseController
    {
        // GET: Admin/Kategori
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }
        // GET: Admin/Kategori/Yeni
        public ActionResult Yeni()
        {
            return View();
        }
        // Post: Admin/Kategori/Yeni
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Yeni(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    islem = "eklendi",
                    mesaj = kategori.KategoriAd + " kategorisi eklendi"
                });
            }
            
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Sil(int id)
        {
            Kategori silinecek= db.Kategoriler.Find(id);
            db.Kategoriler.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index", new
            {
                islem = "silindi",
                mesaj = silinecek.KategoriAd + " kategorisi silindi"
            });
        }
        public ActionResult Duzenle(int id)
        {
            ViewBag.Action = "Duzenle";
            Kategori duzenlenecek = db.Kategoriler.Find(id);
            return View("Yeni",duzenlenecek);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Duzenle(Kategori kategori)
        {
            ViewBag.Action = "Duzenle";
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new {
                    islem="guncellendi",
                    mesaj=kategori.KategoriAd+" kategorisi güncellendi"
                });
            }
            return View("Yeni");
        }
    }
}