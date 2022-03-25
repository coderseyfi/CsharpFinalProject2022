using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAz_Final_Project
{
    class Marka
    {
        static int counter = 0;

        public Marka()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public string Name { get;  set; }

        public override string ToString()
        {
            return $"Id:{Id}. Name:{Name}";
        }
    }

   
}
