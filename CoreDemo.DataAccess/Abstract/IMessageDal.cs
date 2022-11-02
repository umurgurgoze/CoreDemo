using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.DataAccess.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
    }
}
