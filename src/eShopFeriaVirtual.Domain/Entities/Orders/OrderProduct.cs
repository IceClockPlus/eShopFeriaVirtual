using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Domain.Entities.Orders
{
    public class OrderProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
