using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAz_Final_Project.Infrastructure;

namespace TurboAz_Final_Project.Managers
{
    public class MainManager
    {

        public static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                PrintError("The information you entered is incorrect, please re-enter it.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                PrintError("The information you entered is incorrect, please re-enter it.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static string ReadString(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("The information you entered is incorrect, please re-enter it.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }





        public static Menu ReadMenu(string caption)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!Enum.TryParse(Console.ReadLine(), out Menu m))
            {
                PrintError("You did not select from the menu, please select from the menu.");
                goto l1;
            }
            Console.ResetColor();

            return m;
        }


        public static FuelType ReadFuelMenu(string caption)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!Enum.TryParse(Console.ReadLine(), out FuelType f))
            {
                PrintError("Please select fuel type");
                goto l1;
            }
            Console.ResetColor();
            return f;
        }



        public static void PrintError(string message)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.Beep(3000, 900);
            Console.ResetColor();

        }

    }
}