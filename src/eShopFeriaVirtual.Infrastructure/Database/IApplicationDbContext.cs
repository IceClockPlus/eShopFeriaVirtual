using eShopFeriaVirtual.Domain.Entities.Products;
using eShopFeriaVirtual.Domain.Entities.Users;
using MongoDB.Driver;

namespace eShopFeriaVirtual.Infrastructure.Database
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Product> ProductCollection { get; set; }
        IMongoCollection<User> UserCollection { get; set; }
    }
}
