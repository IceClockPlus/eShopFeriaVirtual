using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationResult> Login(string email, string password)
        {
            return new AuthenticationResult(0, "dfoa", "fag", email, "token");
        }

        public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            return new AuthenticationResult(0, firstName, lastName, email, "token");
        }
    }
}
