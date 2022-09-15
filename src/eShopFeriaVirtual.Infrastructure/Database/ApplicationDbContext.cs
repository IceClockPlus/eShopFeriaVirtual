using eShopFeriaVirtual.Domain.Entities.Products;
using eShopFeriaVirtual.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Infrastructure.Database
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<Product> ProductCollection { get; set; }

        public ApplicationDbContext(IOptions<MongoDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.Connection);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            ProductCollection = mongoDatabase.GetCollection<Product>(options.Value.MongoCollections.ProductCollectionName);
        }

    }
}
