using System;

namespace im_bored
{
    public class Delete
    {
        public static void main()
        {   
            listObjects();

            Console.WriteLine("Vilket objekt vill du ta bort? Skriv ID på objektet");
            string object_id = Console.ReadLine();

            Database.Delete(Convert.ToInt32(object_id));
        
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
