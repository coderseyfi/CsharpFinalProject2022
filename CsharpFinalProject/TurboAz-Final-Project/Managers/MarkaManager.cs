using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAz_Final_Project.Managers
{
    class MarkaManager
    {

        Marka[] data = new Marka[0];


        public void Add(Marka entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void Remove(Marka entity)
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

        public void Edit()
        {
        l1:
            int id = MainManager.ReadInteger("select id to change: ");
            bool exist = data.Any(c => c.Id == id);
            if (!exist)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                MainManager.PrintError("Re-enter is not correct: ");
                goto l1;
            }
            Marka marka = null;

            foreach (Marka item in data)
            {
                if (item.Id == id)
                {
                    marka = item;
                }
                Console.WriteLine(item);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("" +
                " Press number 1 to change brand's name : \n" +
                " Press number 2 to change Marka Id : \n");
            Console.ResetColor();

        l2:
            int num = MainManager.ReadInteger("Select number to change: ");
            switch (num)
            {
                case 1:

                    string newName = MainManager.ReadString("Enter the new brand's name :");
                    marka.Name = newName;



                    break;
                default:
                    MainManager.PrintError("The information you entered is incorrect, please re-enter it.");
                    goto l2;

            }





        }


        public Marka[] GetAll()
        {
            return data;
        }
    }
}
