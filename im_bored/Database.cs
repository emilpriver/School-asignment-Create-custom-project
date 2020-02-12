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
            return Path.GetFullPath("database/main.txt");
        }

        public class Schema
        {
            public int id { get; set; }
            public string title { get; set; }
            public string genre { get; set; }
            public string category { get; set; }
            public int length { get; set; }
            public string used { get; set; }
        }

        public static Schema[] ReadDatabaseArray() 
        {
            string[] lines = File.ReadAllLines(GetDatabasePath()).ToArray();
            Schema[] array;
            array = new Schema[lines.Count()];

            int index = 0;
            foreach (string item in lines)
            {
                // If line is empty, skip the line
                if (item.Trim() == "")
                {
                    continue;
                }
                 
                // Create new Database Schema to append information on.
                Schema subData = new Schema { };
                string[] splitedData = item.Split(";");

                // Build object
                subData.id = Convert.ToInt32(splitedData[0]);
                subData.title = splitedData[1].ToString();
                subData.genre = splitedData[2].ToString();
                subData.category = splitedData[3].ToString();
                subData.length = Convert.ToInt32(splitedData[4]);
                subData.used = splitedData[5].ToString();

                // Append object to array
                array[index] = subData;

                // Higher the value of the index
                ++index;
            }

            return array;
        }

        public static void WriteToDatabase(string title, string genre, string category, int length, bool used)
        {
            int lastIndexInDatabse = 0;

            Schema[] data = Database.ReadDatabaseArray();
            foreach (Schema item in data)
            {
                lastIndexInDatabse = item.id;
            }

            using (StreamWriter sw = File.AppendText(GetDatabasePath()))
            {
                sw.WriteLine(
                    String.Join(
                        Environment.NewLine,
                        $"{lastIndexInDatabse + 1};{title};{genre};{category};{length};{used}"
                    )
                );
            }

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
