using System;

namespace im_bored
{
    /**
    * Denna funktion ändrar ett objekt
    * Först listar den alla objekt.
    * Sen frågar den vilket id användaren vill ändra
    * Sen frågar användaren vad användaren vill ändra och till vad.
    * Objektet ändras sen i databasen
    */
    public class Change
    {
        public static void main()
        {   
            Database.listObjects();

            Console.WriteLine("Vilket objekt vill du ändra? Skriv ID på objektet");
            string object_id = Console.ReadLine();
            
            Console.WriteLine("Vilket fält vill du ändra på objektet? (Skriv en siffra)");
            Console.WriteLine("     1. Category");
            Console.WriteLine("     2. Genre");
            Console.WriteLine("     3. Title");
            string object_type = Console.ReadLine();

            Console.WriteLine("Vad vill du ändra objektet till?");
            string object_value = Console.ReadLine();

            Database.ChangeObjectInDatabase(Convert.ToInt32(object_id), object_type, object_value);
            
            Program.askToGoHome();
        }
    }
}
