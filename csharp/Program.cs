using System;
using MongoDB.Bson;
using MongoDB.Driver;

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
    }
}
