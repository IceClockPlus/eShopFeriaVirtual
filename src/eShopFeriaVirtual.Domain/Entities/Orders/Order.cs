using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopFeriaVirtual.Domain.Entities.Orders
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Creation date of order
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Data with the information of the client
        /// </summary>
        public OrderClient Client { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderProduct> Products { get; set; }



    }
}