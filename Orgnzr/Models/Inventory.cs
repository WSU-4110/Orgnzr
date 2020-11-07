using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orgnzr.Models
{
    public class Inventory
    {
        [Key]
        public int inventoryID { get; set; }
        public Int16 inStockAmount { get; set; }
        public Int16 restockAmount { get; set; }

        [ForeignKey("productID")]
        public virtual Product Product { get; set; }
        [Display(Name = "Product ID")]
        public virtual int productID { get; set; }

        [Display(Name = "Product Name")]
        public virtual string productName { get; set; }

    }
}
