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
                            Console.WriteLine("Document Keys:");
                            foreach (var key in doc.Keys)
                            {
                                Console.WriteLine($"- {key}");
                            }
                            Console.WriteLine();
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
