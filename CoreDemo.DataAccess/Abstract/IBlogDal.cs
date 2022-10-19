using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.DataAccess.Abstract
{
    public interface IBlogDal
    {
        List<Blog> ListAllBlog();
        void AddCategory(Blog blog);
        void RemoveCategory(Blog blog);
        void UpdateCategory(Blog blog);
        Blog GetById(int id);
    }
}
