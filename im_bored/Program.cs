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
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            // foreach(Schema.DatabaseItem item in data)
            // {
            //     Console.WriteLine(item.used);
            // }

            // This loop is used for testing writing to database
            // for (int i = 0; i < 100; i++)
            // {
            //     Database.WriteToDatabase("Test", "Test", "Test", 120, true);
            // }

            // Update object in database
            // Database.ChangeObjectInDatabase(2, "title", "Rasmus e bäst");
        }
    }
}
