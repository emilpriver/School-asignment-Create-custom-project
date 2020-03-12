using System;
using System.IO;
using System.Linq;

namespace im_bored
{
    /**
    *  Denna funktionen används för att visa en tabell fint för användaren när dem begär  o vill se data
    */
    class Utils
    {
        static int tableWidth = 73;

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        // denna funktion skriver ut en rad av data där vad kolumn skjiljer sig med en |
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
        // Denna funktion sätter ett objekt i mitten genom att räkna ut hur brett objektet är
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