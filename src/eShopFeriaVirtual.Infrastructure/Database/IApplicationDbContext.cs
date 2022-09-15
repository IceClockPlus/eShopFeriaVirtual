using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

using eShopFeriaVirtual.Domain.Entities.Products;

namespace eShopFeriaVirtual.Infrastructure.Database
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Product> ProductCollection { get; set; }
    }
}
