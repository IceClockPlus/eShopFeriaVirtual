using eShopFeriaVirtual.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eShopFeriaVirtual.Domain.Entities.Products;

namespace eShopFeriaVirtual.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequestHandler<CreateProductRequest, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCommand(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product newProduct = _mapper.Map<Product>(request);
            await _context.ProductCollection.InsertOneAsync(newProduct);
            return newProduct.Id;
        }
    }
}
