using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAz_Final_Project.Infrastructure;

namespace TurboAz_Final_Project.Managers
{
    class CarManager
    {
        Car[] data = new Car[0];


        public void Add(Car entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void Remove(Car entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
            {
                return;
            }
            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
                Array.Resize(ref data, data.Length - 1);
        }


        public void PrintFuelMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine("############ Fuel types ############");
            foreach (var item in Enum.GetNames(typeof(FuelType)))
            {
                FuelType f = (FuelType)Enum.Parse(typeof(FuelType), item);
                Console.WriteLine($"{((byte)f).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public void Edit()
        {
        l1:
            int id = MainManager.ReadInteger("Select id to change: ");
            bool exist = data.Any(c => c.Id == id);
            if (!exist)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                MainManager.PrintError("Re-enter is not correct: ");
                goto l1;
            }
            Car car = null;

            foreach (Car item in data)
            {
                if (item.Id == id)
                {
                    car = item;
                }
                Console.WriteLine(item);
            }
        l2:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("" +
                " Press number 1 to change year : \n" +
                " Press number 2 to change price : \n" +
                " Press number 3 to change color :  \n" +
                " Press number 4 to change engine : \n" +
                " Press number 5 to change Model Id : \n" +
                " Pres number 6 to change FuelType: ");
            Console.ResetColor();

            int num = MainManager.ReadInteger("Select number to change : ");
            switch (num)
            {
                case 1:

                    int newYear = MainManager.ReadInteger("Enter the year : ");
                    car.Year = newYear;
                    break;

                case 2:

                    int newPrice = MainManager.ReadInteger("Enter the new price : ");
                    car.Price = newPrice;
                    break;

                case 3:

                    string newColor = MainManager.ReadString("Enter the new color : ");
                    car.Color = newColor;
                    break;

                case 4:

                    double newEngine = MainManager.ReadDouble("Enter the new engine : ");
                    car.Engine = newEngine;
                    break;


                case 5:

                    int newModelId = MainManager.ReadInteger("Enter the new Model Id : ");
                    car.ModelId = newModelId;
                    break;


                case 6:
                    PrintFuelMenu();
                    FuelType newFuel = MainManager.ReadFuelMenu("Enter the new Fueltype : ");
                    car.FuelType = newFuel;
                    break;

                default:
                    MainManager.PrintError("The information you entered is incorrect, please re-enter it.");
                    goto l2;
            }

        }



        public Car[] GetAll()
        {
            return data;
        }
    }
}