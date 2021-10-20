using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

// https://www.mongodb.com/developer/quickstart/csharp-crud-tutorial/

namespace csharp
{
    class Program
    {
        static MongoClient dbClient;
        static void Main(string[] args)
        {
            dbClient = new MongoClient("mongodb://localhost");
            var x = args[0];
            //x = "listdb";
            switch (x)
            {
                case "listdb":
                    ListDatabases();
                    break;
                case "listnw":
                    ListNorthwind();
                    break;
                case "listregions":
                    ListRegions();
                    break;
                case "filter1":
                    Filter1();
                    break;
                // case "linq":
                //     Linq1();
                //     break;
                
            }
        }

        static void ListDatabases()
        {
            var dbList = dbClient.ListDatabases().ToList();
            foreach (var db in dbList)
                Console.WriteLine(db);

        }

        static void ListNorthwind()
        {
            var nw = dbClient.GetDatabase("Northwind");
            var collections = nw.ListCollectionNames().ToList();
            foreach (var c in collections)
                Console.WriteLine(c);
        }

        static void ListRegions()
        {
            var nw = dbClient.GetDatabase("Northwind");
            var regions = nw.GetCollection<BsonDocument>("regions");
            var regions2 = regions.Find(new BsonDocument()).ToList();
            foreach (var r in regions2)
                Console.WriteLine(r); 

        }
        static void Filter1()
        {
            var nw = dbClient.GetDatabase("Northwind");
            var territories = nw.GetCollection<BsonDocument>("territories");
            var filter = Builders<BsonDocument>.Filter.Eq("RegionID",1);
            var territories2 = territories.Find(filter).ToList();
            foreach (var t in territories2)
                Console.WriteLine(t); 

        }

        // static void Linq1()
        // {
        //     var nw = dbClient.GetDatabase("Northwind");
        //     var territories = nw.GetCollection<Territory>("territories");

            

        //     var query = from t in territories.AsQueryable()
        //     where t.RegionID == 1
        //     select t;
        //     // var filter = Builders<BsonDocument>.Filter.Eq("RegionID",1);
        //     // var territories2 = territories.Find(filter).ToList();
        //     foreach (var t in territories.AsList<Territory>())
        //         Console.WriteLine(t); 

        // }
    }

    public class Territory
    {
        public int TerritoryID {get; set;}
        public string TerritoryDescription {get;set;}
        public int RegionID {get; set;}
    }
}
