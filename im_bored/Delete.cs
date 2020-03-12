using System;

namespace im_bored
{
    public class Delete
    {
        // denna funktion visar alla objekt o låter användaren ta bort en rad i databasen
        public static void main()
        {   
            Database.listObjects();

            Console.WriteLine("Vilket objekt vill du ta bort? Skriv ID på objektet");
            string object_id = Console.ReadLine();

            Database.Delete(Convert.ToInt32(object_id));
        
            Program.askToGoHome();
        }
    }
}
