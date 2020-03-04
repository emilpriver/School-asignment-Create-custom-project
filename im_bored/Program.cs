using System;

namespace im_bored
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");

            // init databas when we load the program
            Database.InitDatabase();

            // create init naviagtion to ask user what the they want to do
            goToHome(true);
        }

        public static void askToGoHome() {
            Console.WriteLine("Redo att gå hem?");
            Console.ReadLine();
            goToHome(true);
        }
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
                    Console.WriteLine("Ändra");
                    break;
                case "4":
                    Console.WriteLine("Ta bort");
                    break;
                default:
                    Console.WriteLine("Please provide type argument. Choose one of: lista,söka");
                    break;
            }
        }
    }
}
