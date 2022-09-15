using eShopFeriaVirtual.Domain.Entities.Products;
using MongoDB.Driver;

namespace eShopFeriaVirtual.Infrastructure.Database
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Product> ProductCollection { get; set; }
    }
}
