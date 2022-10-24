﻿using CoreDemo.Business.Abstract;
using CoreDemo.DataAccess.Abstract;
using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Business.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }
    }
}
