using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{
    public class Product
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productBrand { get; set; }
        public string productCategory { get; set; }
        public double buyPrice { get; set; }
        public double sellPrice { get; set; }
        public Int16 inStockAmount { get; set; }
        public Int16 restockAmount { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
