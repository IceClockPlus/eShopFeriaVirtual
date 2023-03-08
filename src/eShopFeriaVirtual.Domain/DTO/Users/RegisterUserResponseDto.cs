using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Domain.DTO.Users
{
    public class RegisterUserResponseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
