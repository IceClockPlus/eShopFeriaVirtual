using AutoMapper;
using eShopFeriaVirtual.Domain.DTO;
using eShopFeriaVirtual.Domain.Entities.Products;
using eShopFeriaVirtual.Infrastructure.Database;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequestHandler<GetProductByIdRequest, ProductDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetProductByIdQuery(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {

            Product product = await _context.ProductCollection.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
    }
}
