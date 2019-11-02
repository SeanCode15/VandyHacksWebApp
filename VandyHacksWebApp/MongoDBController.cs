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
        readonly MongoDatabase mongoDatabase;

        public MongoDBController()
        {
            mongoDatabase = RetreiveMongohqDb();
        }
        private MongoDatabase RetreiveMongohqDb()
        {
            MongoClient mongoClient = new MongoClient(
                new MongoUrl(ConfigurationManager.ConnectionStrings
                 ["MongoHQ"].ConnectionString));
            MongoServer server = mongoClient.GetServer();
            return mongoClient.GetServer().GetDatabase("MyFirstDb");
        }
        public Contact Save(Contact contact)
        {
            var contactsList = mongoDatabase.GetCollection("Contacts");
            WriteConcernResult result;
            bool hasError = false;
            if (string.IsNullOrEmpty(contact.Id))
            {
                contact.Id = ObjectId.GenerateNewId().ToString();
                result = contactsList.Insert<Contact>(contact);
                hasError = result.HasLastErrorMessage;
            }
            else
            {
                IMongoQuery query = Query.EQ("_id", contact.Id);
                IMongoUpdate update = Update
                 .Set("Size", contact.Size)
                 .Set("Circumference", contact.Circumference)
                 .Set("Width", contact.Width);
                result = contactsList.Update(query, update);
                hasError = result.HasLastErrorMessage;
            }
            if (!hasError)
            {
                return contact;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public IEnumerable<Contact> GetAll()
        {
            List<Contact> model = new List<Contact>();
            var contactsList = mongoDatabase.GetCollection("Contacts").FindAll().AsEnumerable();
            model = (from contact in contactsList
                     select new Contact
                     {
                         Id = contact["_id"].AsString,
                         Size = contact["Size"].AsString,
                         Circumference = contact["Circumference"].AsDouble,
                         Width = contact["Width"].AsDouble
                     }).ToList();
            return model;
        }
    }
    public class Contact
    {
        [BsonId]
        public string Id { get; set; }
        public string Size { get; set; }
        public double Circumference { get; set; }
        public double Width { get; set; }
    }
}