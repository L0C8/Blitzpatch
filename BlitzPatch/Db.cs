using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzPatch
{
    internal class Db
    {
        ArrayList usedID;
        public void test(String path)
        {
            usedID = getDBID(path);

            try
            {
                using (var db = new LiteDatabase(path))
                {
                    var collectionNames = db.GetCollectionNames();
                    foreach (var name in collectionNames)
                    {
                        var collection = db.GetCollection(name);
                        var documents = collection.FindAll();
                        foreach (var doc in documents)
                        {
                           PrintBsonDocument(doc);
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private ArrayList getDBID(String path)
        {
            return new ArrayList();
        }

        void PrintBsonDocument(BsonDocument doc)
        {
            Console.WriteLine("start");
            Console.ReadKey();
            foreach (var field in doc)
            {
                if (field.Value.IsDocument)
                {
                    if (field.Key == "_j")
                    {
                        Console.WriteLine("-----------");
                        Console.WriteLine($"{"\\"}{field.Key}:");
                        Console.WriteLine("-----------");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($"{","}{field.Key}: {field.Value}");
                }
                Console.WriteLine("end");
                Console.ReadKey();
            }
        }

    }
}
