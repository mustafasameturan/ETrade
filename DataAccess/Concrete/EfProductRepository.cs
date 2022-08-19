using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductRepository : EfEntityRepositoryBase<Product, ETradeDbContext>, IProductDal
    {
        //Bütün ürünlerin bilgilerini getirmek için diğer tablolarla birleştirme işlemi.
        //SQL Commands
        public List<ProductDto> GetAllDetails()
        {
            using (ETradeDbContext db = new ETradeDbContext())
            {
                var result = from p in db.Products
                             join b in db.Brands
                             on p.BrandId equals b.Id
                             join c in db.Categories
                             on p.CategoryId equals c.Id
                             join co in db.Colors
                             on p.ColorId equals co.Id
                             select new ProductDto
                             {
                                 Id = p.Id,
                                 ProductName = p.ProductName,
                                 BrandName = b.BrandName,
                                 CategoryName = c.CategoryName,
                                 ColorName = co.ColorName,
                                 Size = p.ProductSize,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice = p.UnitsInStock
                             };

                return result.ToList();
            };
        }
    }
}
