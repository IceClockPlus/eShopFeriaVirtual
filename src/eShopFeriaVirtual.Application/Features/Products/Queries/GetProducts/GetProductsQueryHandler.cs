using AutoMapper;
using eShopFeriaVirtual.Application.Wrapper;
using eShopFeriaVirtual.Domain.DTO.Products;
using eShopFeriaVirtual.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using eShopFeriaVirtual.Domain.Entities.Products;

namespace eShopFeriaVirtual.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResponse<List<ProductDTO>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ProductDTO>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var countFacet = AggregateFacet.Create("count",
                PipelineDefinition<Product, AggregateCountResult>.Create(new[]
                {
                    PipelineStageDefinitionBuilder.Count<Product>()
                }));

            var dataFacet = AggregateFacet.Create("data",
                PipelineDefinition<Product, Product>.Create(new[]
                {
                    PipelineStageDefinitionBuilder.Skip<Product>((request.Page - 1) * request.PageSize),
                    PipelineStageDefinitionBuilder.Limit<Product>(request.PageSize)
                }));

            var filter = Builders<Product>.Filter.Empty;

            var aggregation = await _context.ProductCollection.Aggregate()
                .Match(filter)
                .Facet(countFacet, dataFacet)
                .ToListAsync();

            var count = aggregation.First()
                .Facets.First(x => x.Name.Equals("count"))
                .Output<AggregateCountResult>()
                ?.FirstOrDefault()
                ?.Count ?? 0;
            var totalPages = (int)count / request.PageSize;

            var data = aggregation.First()
                .Facets.First(x => x.Name.Equals("data"))
                .Output<Product>();

            var result = _mapper.Map<List<ProductDTO>>(data);
            return new PagedResponse<List<ProductDTO>>(result, request.Page, request.PageSize);
        }
    }
}
