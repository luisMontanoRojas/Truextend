using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truextend.Models;

namespace Truextend.Service
{
    public interface IUserService
    {
        List<User> getUsers();
        User getUser(int id);
        User creatUser(User newUser);
        User editUser(User editUser);
        bool deleteUser(int id);
    }
}
