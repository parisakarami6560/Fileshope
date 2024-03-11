
using filshopfilecor.Service.Interfase;
using filshopDatalayer.context;
using Filshopfil.DataLayer.entites.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filshopfil.Core.Service.Interface;

namespace Filshopfil.Core.Service
{
    public class UserService : IUserService
    {
        FileShopContext _context;

        public UserService(FileShopContext context)
        {
            _context = context;
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public void ChangeActiveCode(string phone)
        {
            Random rd = new Random();
            var user = GetUserByPhone(phone);
            user.ActiveCode = int.Parse(rd.Next(0, 100000).ToString("D5"));
            _context.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByPhone(string phone)
        {
            return _context.Users.SingleOrDefault(c => c.Phone == phone);
        }


    }
}
