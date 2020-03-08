using System;

namespace im_bored
{
    public class Change
    {
        public static void main()
        {   
            listObjects();

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
