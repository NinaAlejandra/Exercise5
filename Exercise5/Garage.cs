using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles; // en privat array som kommer att hålla alla fordon
        private static int count;
        public Garage(int capacity)
        {
            vehicles = new T[capacity];
            count = 0;
        }

        public bool ParkVehicle(T vehicle)
        {
            //logik för att parkera fordon
            if(count < vehicles.Length)
            {
             vehicles[count] = vehicle;
                        count++;
                return true;
            }
           else
            {
                Console.WriteLine("Finns ingen ledig plats");
                return false;
            }
        }

        public void RemoveVehicleByRegNumber(string registrationNumber)
        {
            try
            {
                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (vehicles[i] != null && vehicles[i].RegistrationNumber.Replace("-", "").Equals(registrationNumber.Replace("-", ""), StringComparison.OrdinalIgnoreCase))
                    {
                        vehicles[i] = null;
                        count--;
                        Console.WriteLine($"Vehicle with registration number {registrationNumber} has been removed.");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No vehicle with that registration number was found.");
                }
            }

            catch (FormatException)
            {

                Console.WriteLine("Invalid registration number. Please try again.");
            }

        }

        public void EmptyGarage()
        {
            Array.Clear(vehicles, 0, vehicles.Length); //rensar arrayen av fordon
            count = 0; //återställ räknaren till 0
        }



        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
            }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

      
    }
}
