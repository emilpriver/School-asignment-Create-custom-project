using System;
using System.IO;

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
            Navigation.navigate(true);
        }
    }
}
