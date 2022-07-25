using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
