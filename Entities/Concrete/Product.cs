using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public string ProductSize { get; set; }
        public int UnitsInStock { get; set; }
        public double UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
