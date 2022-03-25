using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAz_Final_Project
{
    class Model
    {
        static int counter = 0;

        public Model()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}. Name:{Name} MarkaId:{MarkaId}";
        }
    }
}
