using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDto
    {
        //Bütün ürün detaylarını getirmek için oluşturulan sınıf.
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string Size { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
    }
}
