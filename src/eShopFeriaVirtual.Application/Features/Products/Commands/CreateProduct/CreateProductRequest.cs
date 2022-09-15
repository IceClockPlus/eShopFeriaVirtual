using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductRequest : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
