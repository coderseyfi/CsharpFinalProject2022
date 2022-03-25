using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAz_Final_Project.Managers
{
    class ModelManager
    {


        Model[] data = new Model[0];


        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
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
            Model model = null;

            foreach (Model item in data)
            {
                if (item.Id == id)
                {
                    model = item;
                }
                Console.WriteLine(item);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("" +
                " Press number 1 to change model's name : \n" +
                " Press number 2 to change Marka Id : \n");
            Console.ResetColor();

        l2:
            int num = MainManager.ReadInteger("Select number to change: ");
            switch (num)
            {
                case 1:

                    string newName = MainManager.ReadString("Enter the new name : ");
                    model.Name = newName;
                    break;

                case 2:
                    int newMarkalId = MainManager.ReadInteger("Enter the new Marka Id : ");
                    model.MarkaId = newMarkalId;
                    break;

                default:
                    MainManager.PrintError("The information you entered is incorrect, please re-enter it.");
                    goto l2;
            }





        }

        public void Remove(Model entity)
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
        public Model[] GetAll()
        {
            return data;
        }


    }
}
