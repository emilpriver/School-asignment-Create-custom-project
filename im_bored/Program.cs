using System;
using System.IO;

namespace im_bored
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");

            // Check if needed database filed exists, else create it
            Database();

            // Continue with the rest of the code
        }

        private static void Database() {
            string path = Path.GetFullPath("database/main.json");
            if(File.Exists(path)){
                Console.WriteLine("Database initialized");
            } else {
                Console.WriteLine("Database not found, creating..");
                File.Create(path);
                Console.WriteLine("Created database");
            }
        }
    }
}
