using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace im_bored
{
    /**
    * This is the database class.
    * This class handels everything with database file. 
    * Function is:
    * - Update row
    * - Delete row(in work)
    * - Read database and return the database in a format that is simple to work with.
    * - Write to databse.
    */
    class Database
    {
        // function that check database and create it if database dont exists
        public static void InitDatabase()
        {
            // get path to database
            string path = GetDatabasePath();
            // Check if file exists
            if (File.Exists(path))
            {
                Console.WriteLine("Database initialized");
            }
            else
            {
                Console.WriteLine("Database not found, creating..");
                // if file dont exists, create it.
                File.Create(path);
                Console.WriteLine("Created database");
            }
        }

        // Function that returns full path to database file
        public static string GetDatabasePath()
        {
            return Path.GetFullPath("database/main.txt");
        }
        
        public static Schema.DatabaseItem[] ReadDatabaseArray() 
        {
            // example of using this function inside progra:
            // Schema.DatabaseItem[] data = Database.ReadDatabaseArray();
            // foreach(Schema.DatabaseItem item in data) {
            //     Console.WriteLine(item.title);
            // }
            
            string[] lines = File.ReadAllLines(GetDatabasePath()).ToArray();
            Schema.DatabaseItem[] array;
            array = new Schema.DatabaseItem[lines.Count()];

            int index = 0;
            foreach (string item in lines)
            {
                // if line is not empty, run the code
                if (item.Trim() != "")
                {
                    // Create new Database Schema to append information on.
                    Schema.DatabaseItem subData = new Schema.DatabaseItem { };
                    string[] splitedData = item.Split(";");

                    // Build object
                    subData.id = Convert.ToInt32(splitedData[0]);
                    subData.title = splitedData[1].ToString();
                    subData.genre = splitedData[2].ToString();
                    subData.category = splitedData[3].ToString();
                    subData.used = splitedData[4].ToString();

                    // Append object to array
                    array[index] = subData;

                    // Higher the value of the index
                    ++index;
                }
            }

            return array;
        }

        // This function is made to eazy be able to write a new line to datbase file we use.
        public static void WriteToDatabase(string title, string genre, string category, bool used)
        {
            // Read database and return it to the data abariable.
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            int lastIndexInDatabse = 0;
            if(data.Length > 0) {
                lastIndexInDatabse = data[data.Count() - 1].id;
            }
            
            // open database file and write information to database by using File.AppendText()
            using (StreamWriter sw = File.AppendText(GetDatabasePath()))
            {
                // Write the new line
                sw.WriteLine(
                    String.Join(
                        Environment.NewLine,
                        $"{lastIndexInDatabse + 1};{title};{genre};{category};{used}"
                    )
                );
            }

        }

        public static void ChangeObjectInDatabase(int id, string type, string value)
        {
            // Read database and return it to the data abariable.
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();
            
            int index = 0;
            foreach(Schema.DatabaseItem item in data)
            {
                if(item.id == id) {
                    switch (type)
                    {
                        case "1":
                            data[index].category = value;
                            break;
                        case "2":
                            data[index].genre = value;
                            break;
                        case "3":
                            data[index].title = value;
                            break;
                        default:
                            Console.WriteLine("Please provide type argument. Choose one of: category,genre,title");
                            break;
                    }

                }
                ++index;
            }

            // Clear database file before write to it
            File.WriteAllText(GetDatabasePath(), String.Empty);

            foreach(Schema.DatabaseItem item in data)
            {
                WriteToDatabase(
                    item.title,
                    item.genre,
                    item.category,
                    Convert.ToBoolean(item.used)
                );
            }
        } 


        public static void Delete(int id)
        {
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            var newData = data.Where((val) => val.id != id).ToArray();

            // Clear database file before write to it
            File.WriteAllText(GetDatabasePath(), String.Empty);

            foreach (Schema.DatabaseItem item in newData)
            {
                WriteToDatabase(
                    item.title,
                    item.genre,
                    item.category,
                    Convert.ToBoolean(item.used)
                );
            }
        }
    }
}
