using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BlitzPatch
{
    internal class Db
    {

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
                                    string unitData = dat.Substring(startIndex, endIndex - startIndex + 1);
                                    ArrayList list = getUnits(unitData);
                                    // Console.WriteLine(unitData);
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

        public ArrayList getUnits(string unitData)
        {
            ArrayList temp = new ArrayList();
            string[] lines = unitData.Split('\n');
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Console.ReadKey();
            }
            return temp;
        }

        public void addUnit()
        {
            Unit unit = new Unit
            {
                exp = 0.1,
                expLvl = 0,
                id = "test",
                idOnServer = 123,
                unitOnMaps = new UnitOnMaps
                {
                    Unknown = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    },
                    Early = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    },
                    Middle = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    },
                    Late = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    }
                }
            };

            string jsonString = JsonSerializer.Serialize(unit, new JsonSerializerOptions { WriteIndented = true });
            string filePath = "C:\\Users\\Zek\\source\\repos\\Blitzpatch\\BlitzPatch\\test.json";
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"JSON file created at: {filePath}");

        }

        class Unit
        {
            public double exp { get; set; }
            public int expLvl { get; set; }
            public string id { get; set; }
            public int idOnServer { get; set; }
            public UnitOnMaps unitOnMaps { get; set; }
        }

        class UnitOnMaps
        {
            public MapData Unknown { get; set; } = new MapData();
            public MapData Early { get; set; } = new MapData();
            public MapData Middle { get; set; } = new MapData();
            public MapData Late { get; set; } = new MapData();
        }

        class MapData
        {
            public int Parent { get; set; } = -1;
            public Position Pos { get; set; } = new Position();
            public double Angle { get; set; } = 0.0;
            public int Modes { get; set; } = 0;
        }

        class Position
        {
            public double X { get; set; } = 0.0;
            public double Y { get; set; } = 0.0;
            public double Z { get; set; } = 0.0;
        }
    }
}

