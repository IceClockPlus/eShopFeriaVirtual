using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Users.Authentication
{
    public class AuthenticateUserQuery 
    {
        public string Email { get; set; };
        public string Password { get; set; }
    }
}
