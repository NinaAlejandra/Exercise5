using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Entities
{
    public class Airplane : Vehicle
    {
        public int numberOfDoors { get; set; }
        public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfDoors, int numberOfEngines) 
            : base(registrationNumber, color, numberOfWheels, numberOfDoors)
        {

            NumberOfDoors = numberOfEngines;
        }

    }
}
