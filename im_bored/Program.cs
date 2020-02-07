using System;
using System.IO;

namespace im_bored
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");

            // init databas när vi laddar programmet
            Database.InitDatabase();
            Console.WriteLine(Database.ReadDatabase());
        }
    }
}
