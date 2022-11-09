﻿using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.DataAccess.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetListWithMessageByWriter(int id);
    }
}
