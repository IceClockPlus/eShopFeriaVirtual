using eShopFeriaVirtual.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdRequest : IRequest<ProductDTO>
    {
        public string Id { get; set; }
    }
}
