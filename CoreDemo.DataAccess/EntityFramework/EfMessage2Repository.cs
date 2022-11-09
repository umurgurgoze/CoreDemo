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
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.RecieverID == id).ToList();
            }
        }
    }
}
