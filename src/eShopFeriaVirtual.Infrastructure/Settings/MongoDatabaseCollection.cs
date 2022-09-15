using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Infrastructure.Settings
{
    public class MongoDatabaseCollection
    {
        public string ProductCollectionName { get; set; }
        public string ClientCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
    }
}
