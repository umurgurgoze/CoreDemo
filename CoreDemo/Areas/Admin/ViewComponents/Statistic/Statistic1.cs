using CoreDemo.Business.Concrete;
using CoreDemo.DataAccess.Concrete;
using CoreDemo.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();


            //XML ÇEKME DURUMU
            //*Bağlantı
            //string key = "80739eeaf120c30c8e409efb2a34f792";
            //string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + key;
            //*Veri Alma
            //XDocument document = XDocument.Load(connection);
            //ViewBag.v4 = document.Descendants("temprature").ElementAt(0).Attribute("value").Value;
            //Document içinden xml olarak <temprature> al.ElementAt sıfırıncı index ve
            //Değer olarakta bunun içinden value değerini(<temprature value="5.74"> al.
            return View();
        }
    }
}
