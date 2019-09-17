using KopGelMarket.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var sonuc = db.Siparisler.GroupBy(s => DbFunctions.TruncateTime(s.SiparisZamani)).Select(g => new GunlukCiro {
                  Gun=g.Key,
                   Ciro=g.Sum(gi=>gi.OdemeTutari),
                    SiparisAdedi=g.Count()
            }).ToList();

            return View(sonuc);
        }
    }
}