using System;
using System.Linq;

namespace im_bored
{
    public class Create
    {
        public static void main()
        {   
            string category = askCategory();

            Console.WriteLine("Vilken genre skall nya objektet få?");
            string genre = Console.ReadLine();

            Console.WriteLine("Vad för titel har objektet?");
            string title = Console.ReadLine();

            Console.Clear();

            int createdObjectId = Database.WriteToDatabase(title, category, genre, false);
            
            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            var item = data.Where((val) => val.id == createdObjectId).ToArray();
            
            if(item.Count() > 0) {
                Console.WriteLine("Objekt skapat!");
            } 
            else
            {
                Console.WriteLine("Objekt skapades inte. Var god försök igen");
            }
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");

            Program.askToGoHome();
        }

        public static string askCategory() {
            /**
            * Fråga användaren efter vad dem vill söka efter
            */
            Console.WriteLine("Vilken kategori vill du söka i?");
            Console.WriteLine("     1. Spel");
            Console.WriteLine("     2. Film");
            Console.WriteLine("     3. Bok");
            Console.WriteLine("     4. Serie");
            Console.WriteLine("     5. Allt");
            Console.WriteLine("     6. Gå till hem skärmen");
            string type = Console.ReadLine();

            switch (type)
            {
                case "1":
                    return "Game";
                case "2":
                    return "Movie";
                case "3":
                    return "Book";
                case "4":
                    return "Serie";
                case "5":
                    return "all";
                default:
                    Console.WriteLine("Please provide type argument. Choose one of: lista,söka");
                    askCategory();
                    break;
            }

            return "home";
        }
    }
}
