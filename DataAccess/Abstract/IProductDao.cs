﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDao
   {
        List<Product> GetAll();

        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);

   }
}
