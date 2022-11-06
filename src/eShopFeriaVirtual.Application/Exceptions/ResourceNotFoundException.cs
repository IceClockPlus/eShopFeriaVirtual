using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base()
        {                
        }

        public ResourceNotFoundException(string message) : base(message)
        {
        }
    }
}
