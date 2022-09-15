using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Infrastructure.Settings
{
    public class MongoDatabaseSetting
    {
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
        public MongoDatabaseCollection MongoCollections { get; set; }
    }
}
