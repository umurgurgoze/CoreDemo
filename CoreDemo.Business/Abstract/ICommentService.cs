using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Business.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
        //void CommentDelete(Comment comment);
        //void CommentUpdate(Comment comment);
        List<Comment> GetList(int id);
        List<Comment> GetCommentWithBlog();
        //Comment GetById(int id);
    }
}
