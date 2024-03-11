
using Filshopfil.DataLayer.entites.product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filshopfil.DataLayer.order
{
    public class OrderDetail
    {
        [Key]
        public int OrdderDetailId { get; set; }
        public int OrderId { get; set; }    
        public int ProductId { get; set; }
        public int Amount { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
