using KopGelMarket.Models;
using KopGelMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<SepetOge> Sepet
        {

            get
            {
                if (Session["sepet"] == null)
                {
                    Session["sepet"] = new List<SepetOge>();
                }
                return (List<SepetOge>)Session["sepet"];

            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["sepet"]==null)
            {
                Session["sepet"] = new List<SepetOge>();
            }
            base.OnActionExecuting(filterContext);
        }

    }
}