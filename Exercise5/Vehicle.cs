using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class Vehicle : IVehicle
    {
        public string? RegistrationNumber { get; set; }
        public string? Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int NumberOfDoors { get; set; }



        public Vehicle(string registrationNumber, string color, int numberOfWheels, int numberOfDoors)
        {
            RegistrationNumber=registrationNumber;
            Color=color;
            NumberOfWheels=numberOfWheels;
            NumberOfDoors=numberOfDoors;
        }

    }
}
