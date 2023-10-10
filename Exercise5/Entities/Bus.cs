using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Entities
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfDoors, int numberOfSeats) 
            : base(registrationNumber, color, numberOfWheels, numberOfDoors)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
