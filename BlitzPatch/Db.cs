﻿using LiteDB;
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
                    foreach (var name in collectionNames)
                    {
                        var collection = db.GetCollection(name);
                        var documents = collection.FindAll();
                        foreach (var doc in documents)
                        {
                            
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