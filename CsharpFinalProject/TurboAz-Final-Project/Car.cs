using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAz_Final_Project.Infrastructure;

namespace TurboAz_Final_Project
{
    class Car
    {
        static int counter = 0;

        public Car()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        
        public int Year { get; set; }
        public double Price{ get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public FuelType FuelType { get; set; }
        public int ModelId { get; set; }
         

        public override string ToString()
        {
            return $"Id:{Id}. :Year:{Year} Price:{Price}₼ Color:{Color} Engine:{Engine}L FuelType:{FuelType} ModelId:{ModelId}";
        }


    }
}
