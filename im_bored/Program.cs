using System;

namespace im_bored
{
    class Program
    {
        // huvud filen som frågar användaren vad den vill göra
        public static void Main()
        {
            Console.WriteLine("Hello World!");

            // kolla databasen genom att initisera den
            Database.InitDatabase();

            // fråga vad användaren vill göra.
            goToHome(true);
        }

        // funktion som frågar om användaren vill gå hem för att göra mer val
        public static void askToGoHome() {
            Console.WriteLine("Redo att gå hem?");
            Console.ReadLine();
            goToHome(true);
        }

        // Frågar vad användern gör. om true parsas ner i funktionen clearas consolen
        public static void goToHome(bool clear)
        {
            if(clear) {
                Console.Clear();
            }
            
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("     1. Lista");
            Console.WriteLine("     2. Söka");
            Console.WriteLine("     3. Ändra");
            Console.WriteLine("     4. Ta bort");
            Console.WriteLine("     5. Skapa");
            Console.WriteLine("     6. Manual");
            string type = Console.ReadLine();
            switch (type)
            {
                case "1":
                    List.main();
                    break;
                case "2":
                    Search.main();
                    break;
                case "3":
                    Change.main();
                    break;
                case "4":
                    Delete.main();
                    break;
                case "5":
                    Create.main();
                    break;
                default:
                    Console.WriteLine("Välj utav valen ovan");
                    goToHome(false);
                    break;
            }
        }
    }
}
