using filshopDatalayer.context;
using Filshopfil.DataLayer.entites.product;
using Filshopfil.DataLayer.entites.user;
using Filshopfil.DataLayer.order;
using filshopfilecor.DTO;
using filshopfilecor.Service.Interfase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace filshopfilecor.Service
{
    [TestFixture]
    public class Orderservic : IOrderservise
    {
        
        FileShopContext _context;
        public Orderservic(FileShopContext context)
        {
            _context =context;
        }

        public Order GetUserCart(int userid)
        {
          
            var order = _context.Orders.Include(c=>c.User).Include(c=>c.OrderDetails).ThenInclude(c=>c.Product).SingleOrDefault(c => c.UserId == userid && c.IsFainaly == false);
            return order;
        }


        [Test]
        public CartErrorViewModel UpdateCart(int userid)
        {
            var order = _context.Orders.Include(c=>c.OrderDetails).SingleOrDefault(c => c.UserId == userid && c.IsFainaly == false);
            if (order == null) {
                //create order
                _context.Orders.Add(new Order
                {
                    IsFainaly = false,  
                    CreateDate = DateTime.Now,  
                    OrderSum = 0,
                    UserId = userid,
                });
                _context.SaveChanges();
                return CartErrorViewModel.Empity;
            }
            else
            {
                if(order.OrderDetails==null)
                {
                    return CartErrorViewModel.Empity;
                }
                order.OrderSum = 0; 
                foreach(var item in order.OrderDetails)
                {
                     order.OrderSum+=item.Amount;  
                }

                _context.SaveChanges(); 
                return CartErrorViewModel.Success;
            }
        }

        public void AddCart(int userid, int productid)
        {
            UpdateCart(userid);
            var order = _context.Orders.SingleOrDefault(c => c.UserId == userid && c.IsFainaly == false);
            var product = _context.Products.Find(productid);
            _context.OrderDetails.Add(new OrderDetail
            {
                Amount = product.Price,
                ProductId = product.ProductId,
                OrderId = order.OrderId
            });
            _context.SaveChanges();
        }

        public Order GetOrderById(int orderid)
        {
            return _context.Orders.Find(orderid);
        }

        public bool FinalizeOrder(int orderid)
        {

            var order = _context.Orders.Include(c => c.OrderDetails).SingleOrDefault(c => c.OrderId == orderid);
            var user = _context.Users.SingleOrDefault(c => c.UserId == order.UserId);
            if (order.IsFainaly == false)
            {
                order.IsFainaly = true;
                foreach (var item in order.OrderDetails)
                {
                    _context.UserProducts.Add(new UserProduct
                    {
                        ProductId = item.ProductId,
                        UserId = user.UserId,
                    });
                }
                _context.SaveChanges();
            }
            return false;

        }

      

      

      

        public IEnumerable<UserProduct> GetUserProduct()
        {
            return _context.UserProducts.Include(c => c.Product);
        }

        public IEnumerable<UserProduct> GetUserProduct(int userid)
        {
            return _context.UserProducts.Include(c => c.Product).Where(c => c.UserId == userid);
        }

        public bool IsUserBuyProduct(int userid, int productid)
        {
            var product = _context.Products.Find(productid);
            if (product.Price == 0)
            {
                return true;
            }
            else
            {
                if (_context.UserProducts.Any(c => c.UserId == userid && c.ProductId == productid))
                {
                    return true;
                }
            }
            return false;
        }

        public Product GetProductById(int productid)
        {
            return _context.Products.Find(productid);
        }
    }
}
