using System;
using System.IO;
using System.Linq;

namespace im_bored
{
    /**
    * This is the database class.
    * This class handels everything with database file. 
    * Function is:
    * - Update row
    * - Delete row(in work)
    * - Read database and return the database in a format that is simple to work with.
    * - Write to databse.
    */
    class Utils
    {
        static int tableWidth = 73;

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}