using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;

namespace Registration_Team_and_Teammate.Shared
{
    public class LoginModel
    {
        public LoginModel(string name, string surname, string email, string login)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Login = login;
        }
        [BsonIgnoreIfDefault]
        [BsonId]
        public ObjectId id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Surname { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public string Login { get; set; }
        public static void Add(LoginModel login)
        {
            MongoClient client = new MongoClient(); // чтобы подключится к серверу надо передать в качестве аргумента {uri}
            var db = client.GetDatabase("Users");
            var collection = db.GetCollection<LoginModel>("User");
            collection.InsertOne(login);
        }

        public static List<LoginModel> TakeList()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("Users");
            var collection = db.GetCollection<LoginModel>("User");
            List<LoginModel> lst = collection.AsQueryable().ToList();
            return lst;
        }
    }
}

