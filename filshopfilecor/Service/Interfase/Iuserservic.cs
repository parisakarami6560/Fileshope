
using Filshopfil.DataLayer.entites.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filshopfil.Core.Service.Interface
{
    public interface IUserService
    {
        User GetUserByPhone(string phone);

        int AddUser(User user);

        void ChangeActiveCode(string phone);

    }
}