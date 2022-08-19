using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<ProductDto> GetAllDetails();
        void DiscountByColor(int brandId, int categoryId, int colorId, int discountRate);
        void DiscountBySize(int brandId, int categoryId, string size, int discountRate);
    }
}
