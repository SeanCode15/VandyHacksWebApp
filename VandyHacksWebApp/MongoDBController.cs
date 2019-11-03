using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace VandyHacksWebApp
{
    public class MongoDBController
    {
        private const string userName = "";
        private const string passWord = "";
        private static readonly string connectionString1;
        private static readonly string connectionString;

        readonly MongoDatabase mongoDatabase;

        public MongoDBController()
        {
            mongoDatabase = RetreiveMongohqDb();
            //mongoDatabase.CreateCollection("Data");
        }
        private MongoDatabase RetreiveMongohqDb()
        {
            MongoClient mongoClient = new MongoClient(
                new MongoUrl(connectionString));
            MongoServer server = mongoClient.GetServer();
            return mongoClient.GetServer().GetDatabase("nic0");
        }
        public DbDataset Save(DbDataset data)
        {
            var contactsList = mongoDatabase.GetCollection("Data");
            WriteConcernResult result;
            bool hasError = false;
            if (string.IsNullOrEmpty(data.Id))
            {
                data.Id = ObjectId.GenerateNewId().ToString();
                result = contactsList.Insert<DbDataset>(data);
                hasError = result.HasLastErrorMessage;
            }
            else
            {
                IMongoQuery query = Query.EQ("_id", data.Id);
                IMongoUpdate update = Update
                 .Set("Size", data.Size)
                 .Set("Circumference", data.Circumference)
                 .Set("Width", data.Width);
                result = contactsList.Update(query, update);
                hasError = result.HasLastErrorMessage;
            }
            if (!hasError)
            {
                return data;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public IEnumerable<DbDataset> GetAll()
        {
            List<DbDataset> model = new List<DbDataset>();
            var contactsList = mongoDatabase.GetCollection("Data").FindAll().AsEnumerable();
            model = (from contact in contactsList
                     select new DbDataset
                     {
                         Id = contact["_id"].AsString,
                         Size = contact["Size"].AsString,
                         Circumference = contact["Circumference"].AsDouble,
                         Width = contact["Width"].AsDouble
                     }).ToList();
            return model;
        }
    }
    public class DbDataset
    {
        [BsonId]
        public string Id { get; set; }
        public string Size { get; set; }
        public double Circumference { get; set; }
        public double Width { get; set; }
    }
}