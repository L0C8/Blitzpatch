using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzPatch
{
    internal class Db
    {
        public void test(String path)
        {
            string filePath = path;

            try
            {
                using (var db = new LiteDatabase(filePath))
                {
                    var collectionNames = db.GetCollectionNames();

                    Console.WriteLine("Collections in the database:");
                    foreach (var name in collectionNames)
                    {
                        Console.WriteLine($"- {name}");
                        var collection = db.GetCollection(name);
                        var documents = collection.FindAll();
                        Console.WriteLine($"Contents of collection '{name}':");
                        foreach (var doc in documents)
                        {
                            Console.WriteLine(doc.ToString());
                            Console.ReadKey();
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
    }
}
