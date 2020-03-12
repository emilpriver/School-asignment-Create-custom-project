using System;
using System.Linq;

namespace im_bored
{
    public class Search
    {
        // denna funktion låter användaren söka efter objekt
        public static void main()
        {   

            Schema.DatabaseItem[] data = Database.ReadDatabaseArray();

            Console.WriteLine("Vad vill du söka efter?");
            string query = Console.ReadLine();

            data = data.Where(
                (val) =>
                    (val.title.ToLower().Contains(query.ToLower())) ||
                    (val.category.ToLower().Contains(query.ToLower())) ||
                    (val.genre.ToLower().Contains(query.ToLower()))
            ).ToArray();

            Console.Clear();

            Utils.PrintLine();
            Utils.PrintRow("ID", "Title", "Kategori", "Genre");
            Utils.PrintLine();

            foreach(Schema.DatabaseItem item in data)
            {
                Utils.PrintRow(item.id.ToString(), item.title, item.category, item.genre);
            }
            Utils.PrintLine();

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
                case "6":
                    return "home";
                default:
                    Console.WriteLine("Please provide type argument. Choose one of: lista,söka");
                    askCategory();
                    break;
            }

            return "home";
        }

        public static string askGenre() {
            /**
            * Fråga användaren efter vad dem vill söka efter
            */
            Console.WriteLine("Vill du söka efter en specefik genre? Y/N");
            string searchAllGenre = Console.ReadLine();
            if (searchAllGenre == "N") {
                return "";
            }

            Console.WriteLine("Vilken genre vill du söka efter?");
            return Console.ReadLine();
        }
    }
}
