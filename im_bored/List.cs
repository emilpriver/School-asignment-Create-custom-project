using System;
using System.IO;

namespace im_bored
{
    public class List
    {
        public void LoadJson()
        {
            //Open the file              
            var content = Database.GetDatabasePath();
            Console.WriteLine(content);
        }

        public class Item
        {
            public int id;
            public string title;
            public string category;
            public string genre;
        }
    }
}
