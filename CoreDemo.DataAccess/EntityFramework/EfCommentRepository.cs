using CoreDemo.DataAccess.Abstract;
using CoreDemo.DataAccess.Concrete;
using CoreDemo.DataAccess.Repositories;
using CoreDemo.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.DataAccess.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentListWithBlog()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
