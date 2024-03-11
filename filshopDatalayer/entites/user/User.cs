using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filshopfil.DataLayer.entites.user
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string Phone { get; set; }
        public int Money { get; set; }
        public int ActiveCode { get; set; }
        public Userrol Rol { get; set; } = Userrol.Normal;
      

    }
    public enum Userrol
    {
        Admin,
        Normal

    }
}
