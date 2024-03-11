
using Filshopfil.DataLayer.entites.user;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filshopfil.DataLayer.order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OrderSum { get; set; }
        public bool IsFainaly { get; set; } = false;
        public DateTime CreateDate { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
