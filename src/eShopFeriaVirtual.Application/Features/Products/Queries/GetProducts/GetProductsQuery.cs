using eShopFeriaVirtual.Application.Wrapper;
using eShopFeriaVirtual.Domain.DTO.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<PagedResponse<List<ProductDTO>>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
