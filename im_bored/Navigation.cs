using System;
namespace im_bored
{
    public class Navigation
    {
        public static void navigate(bool clear)
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
                    Console.WriteLine("Lista");
                    break;
                case "2":
                    Console.WriteLine("Söka");
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

            Navigation.navigate(false);
        }
    }
}
