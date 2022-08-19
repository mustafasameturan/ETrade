using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product t)
        {
            t.CreatedDate = DateTime.Now;
            _productDal.Add(t);
        }

        public void Delete(Product t)
        {
            _productDal.Delete(t);
        }

        //Renge göre indirim yapma.
        public void DiscountByColor(int brandId, int categoryId, int colorId, int discountRate)
        {
            List<Product> product = _productDal.GetByFilter(b => b.BrandId == brandId &&
                                                  b.CategoryId == categoryId &&
                                                  b.ColorId == colorId);

            foreach(Product p in product)
            {
                p.UnitPrice = p.UnitPrice - ((p.UnitPrice * discountRate) / 100);
                _productDal.Update(p);
            }                                     
        }

        //Boyuta göre indirim yapma.
        public void DiscountBySize(int brandId, int categoryId, string size, int discountRate)
        {
            List<Product> product = _productDal.GetByFilter(b => b.BrandId == brandId &&
                                                  b.CategoryId == categoryId &&
                                                  b.ProductSize == size);

            foreach (Product p in product)
            {
                p.UnitPrice = p.UnitPrice - ((p.UnitPrice * discountRate) / 100);
                _productDal.Update(p);
            }
        }

        public List<ProductDto> GetAllDetails()
        {
            return _productDal.GetAllDetails();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetAll();
        }

        public void Update(Product t)
        {
            _productDal.Update(t);
        }
    }
}
