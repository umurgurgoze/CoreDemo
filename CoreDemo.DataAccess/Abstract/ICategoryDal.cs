﻿using CoreDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.DataAccess.Abstract
{
    public interface ICategoryDal
    {
        List<Category> ListAllCategory();
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        Category GetById(int id);
    }
}
