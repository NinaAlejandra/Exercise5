using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Entities
{
    public class Motorcycle : Vehicle

    {
        public bool HasCrashProtection { get; set; }
        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int numberOfDoors, bool hasCrashProtection) 
            : base(registrationNumber, color, numberOfWheels, numberOfDoors)
        {
            HasCrashProtection = hasCrashProtection;
        }
    }
}
