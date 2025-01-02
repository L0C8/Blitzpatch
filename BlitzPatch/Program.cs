using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzPatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Db db = new Db();
            db.test("D:\\SteamLibrary\\steamapps\\common\\Blitzkrieg3\\Data\\User_\\a_");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
