using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Entities
{
    public class Car : Vehicle
    {
        public string FuelType { get; set; }
        public Car(string registrationNumber, string color, int numberOfWheels, int numberOfDoors, string fuelType) 
            : base(registrationNumber, color, numberOfWheels, numberOfDoors)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return base.ToString() + $"{FuelType}";
        }
    }
}
