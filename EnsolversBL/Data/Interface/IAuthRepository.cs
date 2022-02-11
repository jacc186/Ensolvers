using EnsolversBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.Data.Interface
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string correo, string password);
        Task<bool> UserExist(string correo);
    }
}
