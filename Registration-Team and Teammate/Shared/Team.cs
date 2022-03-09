using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Registration_Team_and_Teammate.Shared
{
    public class Team
    {
        public Team(string name, List<LoginModel> users123)
        {
            Name = name;
            Users123 = users123;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public List<LoginModel> Users123 { get; set; }

        public void Addteam(Team team)
        {
            MongoClient client = new MongoClient(); // чтобы подключится к серверу надо передать в качестве аргумента {uri}
            var db = client.GetDatabase("User");
            var collection = db.GetCollection<Team>("Team");
            collection.InsertOne(team);
        }

        public static List<Team> TakeTeamsList()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("User");
            var collection = db.GetCollection<Team>("Team");
            List<Team> lst = collection.AsQueryable().ToList();
            return lst;
        }


    }
}
