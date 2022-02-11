using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.DTOs
{
    public class UserRegisterDTO
    {
        public UserRegisterDTO()
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
