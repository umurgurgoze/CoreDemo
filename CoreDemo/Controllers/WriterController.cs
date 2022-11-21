using CoreDemo.Business.Concrete;
using CoreDemo.Business.ValidationRules;
using CoreDemo.DataAccess.Concrete;
using CoreDemo.DataAccess.EntityFramework;
using CoreDemo.Entity.Concrete;
using CoreDemo.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
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

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            //Context c = new Context();
            //var userName = User.Identity.Name;            
            //var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            //var writerValues = wm.TGetById(writerID);
            //return View(writerValues);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

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
