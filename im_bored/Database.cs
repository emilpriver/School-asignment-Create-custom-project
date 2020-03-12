using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace im_bored
{
    /**
    * I denna class finns information som används för att arbeta med en dastabas.
    */
    class Database
    {
        // initierar dastabasen och skapar den om den inte finns.
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

        // retunerar full databas fil väg
        public static string GetDatabasePath()
        {
            return Path.GetFullPath("database/main.txt");
        }
        
        /**
        * Denna funktionen retunerar alla objekt i database som en array som sedan går att använda.
        */
        public static Schema.DatabaseItem[] ReadDatabaseArray() 
        {
            // Exempel på hur denna funktion kan användas
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
                // Kollar ifall raden inte är tom
                if (item.Trim() != "")
                {
                    Schema.DatabaseItem subData = new Schema.DatabaseItem { };
                    string[] splitedData = item.Split(";");

                    subData.id = Convert.ToInt32(splitedData[0]);
                    subData.title = splitedData[1].ToString();
                    subData.genre = splitedData[2].ToString();
                    subData.category = splitedData[3].ToString();

                    array[index] = subData;

                    ++index;
                }
            }

            return array;
        }

        // Denna funktionen skriver till databasen filen med information
        public static int WriteToDatabase(string title, string genre, string category)
        {
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            int lastIndexInDatabse = 0;
            if(data.Length > 0) {
                lastIndexInDatabse = data[data.Count() - 1].id;
            }
            
            using (StreamWriter sw = File.AppendText(GetDatabasePath()))
            {
                sw.WriteLine(
                    String.Join(
                        Environment.NewLine, // symboliserar ett retur hopp
                        $"{lastIndexInDatabse + 1};{title};{genre};{category}"
                    )
                );
            }

            return lastIndexInDatabse;
        }

        // denna funktion ändrar ett objekt genom id, type o vad man vill ändra.
        public static void ChangeObjectInDatabase(int id, string type, string value)
        {
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

            File.WriteAllText(GetDatabasePath(), String.Empty);

            foreach(Schema.DatabaseItem item in data)
            {
                WriteToDatabase(
                    item.title,
                    item.genre,
                    item.category
                );
            }
        } 

        // Denna funktion tar bort ett objekt i databasen med hjälp av ID
        public static void Delete(int id)
        {
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            var newData = data.Where((val) => val.id != id).ToArray();

            File.WriteAllText(GetDatabasePath(), String.Empty);

            foreach (Schema.DatabaseItem item in newData)
            {
                WriteToDatabase(
                    item.title,
                    item.genre,
                    item.category
                );
            }
        }

        // Denna funktion skapar upp en tabell av alla objekt som är enkelt för användaren att läsa
        public static void listObjects() {
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            Utils.PrintLine();
            Utils.PrintRow("ID", "Title", "Kategori", "Genre");
            Utils.PrintLine();

            foreach(Schema.DatabaseItem item in data)
            {
                Utils.PrintRow(item.id.ToString(), item.title, item.category, item.genre);
            }
            Utils.PrintLine();
        }
    }
}
