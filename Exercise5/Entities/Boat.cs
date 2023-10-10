using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Entities
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }
        public Boat(string registrationNumber, string color, int numberOfWheels, int numberOfDoors, int length) 
            : base(registrationNumber, color, numberOfWheels, numberOfDoors)
        {
            Length = length;
        }
    }
}
