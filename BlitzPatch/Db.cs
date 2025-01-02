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
                            if (doc.ToString().Contains("Units"))
                            {
                                string dat = doc.ToString();
                                int startIndex = dat.IndexOf('[');
                                int endIndex = dat.IndexOf(']');

                                if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
                                {
                                    string result = dat.Substring(startIndex, endIndex - startIndex + 1);
                                    Console.WriteLine($"Extracted Substring: {result}");
                                }
                                else
                                {
                                    Console.WriteLine("No valid substring found.");
                                }

                            }
                        }
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

