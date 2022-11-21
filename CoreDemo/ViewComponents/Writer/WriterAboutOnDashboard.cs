using CoreDemo.Business.Concrete;
using CoreDemo.DataAccess.Concrete;
using CoreDemo.DataAccess.EntityFramework;
using CoreDemo.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //Aktif Kullanıcının adı alma
            var username = User.Identity.Name; 
            ViewBag.veri = username;
            //Mail almak (Kullanıcı adı identitydeki kullanıcı adı ile eşit olanın mailini getir.)
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //Writer tablosundaki Writer mail ile identityden gelen maili eşledik.Id'sini aldık.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();    
            //Id'ye ait bilgileri aldık.
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
