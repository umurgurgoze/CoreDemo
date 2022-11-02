using CoreDemo.Business.Concrete;
using CoreDemo.Business.ValidationRules;
using CoreDemo.DataAccess.EntityFramework;
using CoreDemo.Entity.Concrete;
using CoreDemo.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace CoreDemo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writerValues = wm.TGetById(1);
            return View(writerValues);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(writer);
            if (results.IsValid)
            {
                wm.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage profile)
        {
            Writer w = new Writer();
            if (profile.WriterImage != null) //Dto üzerinden verileri alıyoruz.Resmi klasöre kaydedip mapliyoruz.Databasede resim ismi kalıyor.
            {
                var extention = Path.GetExtension(profile.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extention;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                profile.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = profile.WriterMail;
            w.WriterName = profile.WriterName;
            w.WriterPassword = profile.WriterPassword;
            w.WriterAbout = profile.WriterAbout;
            w.WriterStatus = true;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
