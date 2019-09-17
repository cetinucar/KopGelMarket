
using KopGelMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KopGelMarket.Helpers
{
    public static class HelperExtension
    {
        public static MvcHtmlString UrunImg(this HtmlHelper htmlHelper,string resimYolu,object htmlAttributes)
        {
            if (string.IsNullOrEmpty(resimYolu))
            {
                resimYolu = "/Images/noImage.png";
            }
            else
            {
                resimYolu = "/Upload/" + resimYolu;
            }

            resimYolu = VirtualPathUtility.ToAbsolute(resimYolu);

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            TagBuilder tag = new TagBuilder("img");
            tag.MergeAttributes(attributes);
            tag.MergeAttribute("src", resimYolu);


            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static decimal SepetTutar(this HtmlHelper htmlHelper)
        {
            var sepet = htmlHelper.ViewContext.HttpContext.Session["sepet"] as List<SepetOge>;
            return sepet == null ? 0 : sepet.Sum(x => x.Adet * x.BirimFiyat);
        }

        public static decimal SepetAdet(this HtmlHelper htmlHelper)
        {
            var sepet = htmlHelper.ViewContext.HttpContext.Session["sepet"] as List<SepetOge>;
            return sepet == null ? 0 : sepet.Count;
        }

        public static List<SepetOge> Sepet(this HtmlHelper htmlHelper)
        {
            var sepet = (htmlHelper.ViewContext.HttpContext.Session["sepet"]) as List<SepetOge>;
            return sepet;
        }


    }
}