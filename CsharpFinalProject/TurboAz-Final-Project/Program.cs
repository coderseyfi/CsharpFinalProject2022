using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using TurboAz_Final_Project.Infrastructure;
using TurboAz_Final_Project.Managers;

namespace TurboAz_Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            string s = "Welcome to Turbo.Az";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ResetColor();

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "TurboAz Final Project";

            CarManager carMgr = new CarManager();
            MarkaManager markaMgr = new MarkaManager();
            ModelManager modelMgr = new ModelManager();

            CultureInfo c2 = new CultureInfo("en-US");
            c2.NumberFormat.CurrencyDecimalSeparator = ".";
            c2.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = c2;
            Thread.CurrentThread.CurrentUICulture = c2;





        backMenu:
            PrintMenu();

            Menu m = MainManager.ReadMenu("Select from the menu: ");

            switch (m)
            {
                case Menu.MarkaAdd:
                    Console.Clear();
                    Marka m1 = new Marka();
                    m1.Name = MainManager.ReadString("Enter the car's brend: ");
                    markaMgr.Add(m1);
                    goto case Menu.MarkaAll;


                case Menu.MarkaEdit:
                    carMgr.Edit();
                    ShowAllCars(carMgr);
                    break;


                case Menu.MarkaRemove:
                    Console.Clear();
                    ShowAllMarka(markaMgr);
                    int idForMarka = MainManager.ReadInteger("Enter the Model id you want to delete: ");
                    Marka mV2 = markaMgr.GetAll().FirstOrDefault(item => item.Id == idForMarka);
                    markaMgr.Remove(mV2);
                    Console.Clear();
                    goto backMenu;

                case Menu.MarkaSingle:
                    Console.Clear();
                    ShowAllMarka(markaMgr);
                    int idForMarkaSingle = MainManager.ReadInteger("Select ModelId for details: ");
                    Marka mSingleMarka = markaMgr.GetAll().FirstOrDefault(item => item.Id == idForMarkaSingle);
                    Console.WriteLine($"Id: {mSingleMarka.Id}\n " +
                       $"Name: {mSingleMarka.Name}");
                    break;


                case Menu.MarkaAll:
                    Console.Clear();
                    ShowAllMarka(markaMgr);
                    goto backMenu;

                case Menu.ModelAdd:
                    Console.Clear();
                    Model m2 = new Model();
                    m2.Name = MainManager.ReadString("Enter the Model's name: ");
                    Console.WriteLine("---------------");
                    ShowAllMarka(markaMgr);
                    Console.WriteLine("---------------");
                    m2.MarkaId = MainManager.ReadInteger("Enter the Marka Id:");

                l1:
                    var m43 = markaMgr.GetAll().FirstOrDefault(x => x.Id == m2.MarkaId);
                    if (m43 == null)
                    {
                        MainManager.PrintError("It does not have a brand named Id");
                        goto l1;
                    }
                    modelMgr.Add(m2);
                    goto case Menu.ModelAll;
     
                case Menu.ModelEdit:
                    modelMgr.Edit();
                    ShowAllModels(modelMgr);
                    break;

                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int idForModel = MainManager.ReadInteger("Enter the Model Id you want to delete: ");
                    Model mV3 = modelMgr.GetAll().FirstOrDefault(item => item.Id == idForModel);

                    modelMgr.Remove(mV3);
                    Console.Clear();

                    goto backMenu;


                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int idForModelSingle = MainManager.ReadInteger("Select Model Id for details: ");
                    Model mSingleModel = modelMgr.GetAll().FirstOrDefault(item => item.Id == idForModelSingle);
                    Console.WriteLine($"Id: {mSingleModel.Id}\n " +
                       $"Name: {mSingleModel.Name}");
                    goto backMenu;


                case Menu.ModelAll:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    goto backMenu;

                case Menu.CarAdd:
                    Console.Clear();
                    Car c = new Car();
                    c.Year = MainManager.ReadInteger("Enter the car's year: ");
                    c.Price = MainManager.ReadDouble("Enter the car's price: ");
                    c.Color = MainManager.ReadString("Enter the car's color: ");
                    c.Engine = MainManager.ReadDouble("Enter the car's engine: ");
                l4:
                    PrintFuelMenu();
                    FuelType fueltype = MainManager.ReadFuelMenu("Select from the menu: ");

                    switch (fueltype)
                    {
                        case FuelType.Petrol:
                            c.FuelType = FuelType.Petrol;
                            break;
                        case FuelType.Diesel:
                            c.FuelType = FuelType.Diesel;
                            break;
                        case FuelType.Electro:
                            c.FuelType = FuelType.Electro;
                            break;
                        case FuelType.Hybrid:
                            c.FuelType = FuelType.Hybrid;
                            break;
                        default:
                            MainManager.PrintError("The information you entered is incorrect, please re-enter it.");
                            goto l4;

                    }

                    Console.WriteLine("---------------");
                    ShowAllModels(modelMgr);
                    Console.WriteLine("---------------");
                    c.ModelId = MainManager.ReadInteger("Enter the car's Model Id: ");

                l7:
                    var m42 = modelMgr.GetAll().FirstOrDefault(y => y.Id == c.ModelId);
                    if (m42 == null)
                    {
                        MainManager.PrintError("It does not have a brand named Id");
                        goto l7;
                    }
                    carMgr.Add(c);
                    goto case Menu.CarsAll;

                case Menu.CarEdit:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    carMgr.Edit();
                    goto backMenu;

                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int idforCar = MainManager.ReadInteger("Enter the Model Id you want to delete: ");
                    Car mV4 = carMgr.GetAll().FirstOrDefault(item => item.Id == idforCar);
                    carMgr.Remove(mV4);
                    Console.Clear();
                    goto backMenu;


                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int idForcarSingle = MainManager.ReadInteger("Select Model Id for details: ");
                    Car mSingleCar = carMgr.GetAll().FirstOrDefault(item => item.Id == idForcarSingle);
                    Console.WriteLine($"Id: {mSingleCar.Id}\n " +
                       $"Name: {mSingleCar.Year}" +
                       $"{mSingleCar.Price}" +
                       $"{mSingleCar.Color}" +
                       $"{mSingleCar.Engine}");

                    goto backMenu;


                case Menu.CarsAll:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    goto backMenu;


                case Menu.All:
                    Console.Clear();
                    ShowAllMarka(markaMgr);
                    ShowAllModels(modelMgr);
                    ShowAllCars(carMgr);
                    goto backMenu;


                case Menu.Exit:
                    goto lEnd;


                default:

                    MainManager.PrintError("The information you entered is incorrect, please re-enter it.");
                    goto backMenu;
            }


        lEnd:
            Console.WriteLine("End..");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();




            static void PrintMenu()
            {
                Console.WriteLine(new string('-', Console.WindowWidth));
                foreach (var item in Enum.GetNames(typeof(Menu)))
                {
                    Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                    Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
                }
                Console.ResetColor();
                Console.WriteLine(new string('-', Console.WindowWidth));
            }


            static void PrintFuelMenu()
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


            static void ShowAllCars(CarManager carMgr)
            {
                Console.WriteLine("################## All Cars #################");
                foreach (var item in carMgr.GetAll())
                {
                    Console.WriteLine(item);
                }
            }


            static void ShowAllModels(ModelManager modelMgr)
            {
                Console.WriteLine("################## Models #################");
                foreach (var item in modelMgr.GetAll())
                {
                    Console.WriteLine(item);
                }
            }


            static void ShowAllMarka(MarkaManager markaMgr)
            {
                Console.WriteLine("################## Brands #################");
                foreach (var item in markaMgr.GetAll())
                {
                    Console.WriteLine(item);
                }
            }


        }
    }
}