using CoreDemo.Business.Concrete;
using CoreDemo.DataAccess.EntityFramework;
using CoreDemo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            nm.AddNewsLetter(newsLetter);
            return PartialView(); 
            //Böyle yaptığımızda yeni bir sayfada partial açıp dönüyor.
            //Bunun yerine IActionResult türünden RedirectToAction("Index","Blog") da dönülebilir.AJAX'ta kullanılabilir.
        }
    }
}
