using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Business.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        List<Writer> GetWriterById(int id);
    }
}
