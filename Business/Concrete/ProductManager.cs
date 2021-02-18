﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDao _productDao;

        public ProductManager(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("ürün ismi en az 2 karakter olmalıdır");
            }


           _productDao.Add(product );
           return new SuccessResult("ürün eklendi");
        }

        public List<Product> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return _productDao.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDao.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDao.Get(p => p.ProductId == productId);

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDao.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDao.GetProductDetails();
        }

        public void Update(Product entity)
        { 
            _productDao.Update(entity);
        }
    }
}