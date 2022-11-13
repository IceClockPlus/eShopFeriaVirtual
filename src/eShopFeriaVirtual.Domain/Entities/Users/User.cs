using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace eShopFeriaVirtual.Domain.Entities.Users
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsEnabled { get; set; }
        public int Retry { get;set; }
        public List<UserRole> Roles { get; set; }

        public User()
        {
            IsEmailConfirmed = false;
            IsEnabled = false;
            Retry = 0;
            Roles = new List<UserRole>();
        }
    }
}
