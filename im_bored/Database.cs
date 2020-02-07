using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace im_bored
{
    class Database
    {
        public static void InitDatabase()
        {
            GetDatabase();
        }

        public static string GetDatabasePath()
        {
            return Path.GetFullPath("database/main.json");
        }

        public class SchemaInfo
        {
            public string title { get; set; }
            public string genre { get; set; }
            public string category { get; set; }
        }

        public static string[] ReadDatabase() {
            string[] lines = File.ReadLines(GetDatabasePath()).ToArray();
            return lines;
        }

        private static void GetDatabase()
        {
            string path = GetDatabasePath();
            if (File.Exists(path))
            {
                Console.WriteLine("Database initialized");
            }
            else
            {
                Console.WriteLine("Database not found, creating..");
                File.Create(path);
                Console.WriteLine("Created database");
            }
        }
    }
}
