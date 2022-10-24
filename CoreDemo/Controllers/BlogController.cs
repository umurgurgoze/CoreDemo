using CoreDemo.Business.Concrete;
using CoreDemo.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory(); // Eager Loading
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            var values = bm.GetBlogByID(id);
            return View(values);
        }
    }
}
