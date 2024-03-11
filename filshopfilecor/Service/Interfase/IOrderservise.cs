
using Filshopfil.DataLayer.entites.product;
using Filshopfil.DataLayer.entites.user;
using Filshopfil.DataLayer.order;
using filshopfilecor.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filshopfilecor.Service.Interfase
{
   public interface IOrderservise
    {
        CartErrorViewModel UpdateCart(int userid);
        void AddCart(int userid, int productid);
        Order GetUserCart(int userid);
        Order GetOrderById(int orderid);
        bool FinalizeOrder(int orderid);
        IEnumerable<UserProduct> GetUserProduct(int userid);
        bool IsUserBuyProduct(int userid, int productid);
        Product GetProductById(int productid);
    }
}
