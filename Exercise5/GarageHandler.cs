using Exercise5.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    internal class GarageHandler<T> : IHandler<T> where T : Vehicle
    {

        private Garage<T> garage;

        public GarageHandler(int capacity)
        {
            garage = new Garage<T>(capacity);
        }
        public void ParkVehicle(T vehicle)
        {
            garage.ParkVehicle(vehicle);
        }


        public void ParkVehicle()
        {
            try
            {
                Console.WriteLine("Choose which type of vehicle you want to park by writing the number:");
                Console.WriteLine("1. Airplane");
                Console.WriteLine("2. Motorcycle");
                Console.WriteLine("3. Car");
                Console.WriteLine("4. Boat");
                Console.WriteLine("5. Bus");

                int choice = int.Parse(Console.ReadLine());

                T vehicle = null;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter registration number:");
                        string regNumberPlane = Console.ReadLine();
                        Console.WriteLine("Enter color:");
                        string colorPlane = Console.ReadLine();
                        Console.WriteLine("Enter number of doors:");
                        int numberOfDoorsPlane = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of wheels");
                        int numberOfWheelsPlane = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of engines:");
                        int numberOfEnginesPlane = int.Parse(Console.ReadLine());

                        vehicle = new Airplane(regNumberPlane, colorPlane, numberOfWheelsPlane, numberOfDoorsPlane, numberOfEnginesPlane)as T;
                        break;

                    case 2:


                        Console.WriteLine("Enter registration number:");
                        string regNumberBike = Console.ReadLine();
                        Console.WriteLine("Enter color:");
                        string colorBike = Console.ReadLine();
                        Console.WriteLine("Enter number of doors:");
                        int numberOfDoorsBike = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of wheels:");
                        int numberOfWheelsBike = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter 'true' if crashprotected, otherwise enter 'false':");

                        bool IsCrashProtected;

                        if (!bool.TryParse(Console.ReadLine(), out IsCrashProtected))
                        {
                            Console.WriteLine("Invalid input for crash protection. Please enter 'true' or 'false'.");
                            break;
                        }

                        vehicle = new Motorcycle(regNumberBike, colorBike, numberOfWheelsBike, numberOfDoorsBike, IsCrashProtected)as T;
                        break;

                    case 3:
                        Console.WriteLine("Enter registration number:");
                        string regNumberCar = Console.ReadLine();
                        Console.WriteLine("Enter color:");
                        string colorCar = Console.ReadLine();
                        Console.WriteLine("Enter number of doors:");
                        int numberOfDoorsCar = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of wheels");
                        int numberOfWheelsCar = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter fuel type(gas or diesel):");
                        string fuel = Console.ReadLine();

                        vehicle = new Car(regNumberCar, colorCar, numberOfWheelsCar, numberOfDoorsCar, fuel)as T;
                        break;


                    case 4:
                        Console.WriteLine("Enter registration number:");
                        string regNumberBoat = Console.ReadLine();
                        Console.WriteLine("Enter color:");
                        string colorBoat = Console.ReadLine();
                        Console.WriteLine("Enter number of doors:");
                        int numberOfDoorsBoat = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of wheels");
                        int numberOfWheelsBoat = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of engines:");
                        int boatLength = int.Parse(Console.ReadLine());

                        vehicle = new Boat(regNumberBoat, colorBoat, numberOfWheelsBoat, numberOfDoorsBoat, boatLength)as T;
                        break;

                    case 5:
                        Console.WriteLine("Enter registration number:");
                        string regNumberBus = Console.ReadLine();
                        Console.WriteLine("Enter color:");
                        string colorBus = Console.ReadLine();
                        Console.WriteLine("Enter number of doors:");
                        int numberOfDoorsBus = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of wheels");
                        int numberOfWheelsBus = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number of engines:");
                        int numberOfSeats = int.Parse(Console.ReadLine());

                        vehicle = new Bus(regNumberBus, colorBus, numberOfWheelsBus, numberOfDoorsBus, numberOfSeats)as T;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;

                }

                if (vehicle != null)
                {
                    ParkVehicle(vehicle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void ListAllVehicles()
        {
            foreach (var vehicle in garage)
            {
                Console.WriteLine($"{vehicle.GetType().Name} Registration Number: {vehicle.RegistrationNumber}");
            }

            Console.WriteLine($"\nTotal vehicles in garage: {garage.Count()}");
        }

        public void ListVehicleTypesAndQuantities()
        {
            //En dictionary är en lista med namgivna lådor där vi kan lagra saker.
            //Här vill vi lagra namnet på fordonstyper och hur många som finns av varje.
            Dictionary<string, int> vehicleTypeCounts = new Dictionary<string, int>();

            //Gå igenom varje fordon i garaget.
            foreach (var vehicle in garage)
            {
                //Få reda på namnet på fordonstypen (tex Car, Boat etc).
                string typeName = vehicle.GetType().Name;

                //Kolla om vi redan har lagrat den här typen av fordon.
                if (vehicleTypeCounts.ContainsKey(typeName))
                {
                    //Om ja, lägg till ett till på räkningen.
                    vehicleTypeCounts[typeName]++;
                }
                else
                {
                    //Annars, om det är första gången vi ser denna fordonstyp, sätt räkningen till 1.
                    vehicleTypeCounts[typeName] = 1;
                }
            }

            //Gå igenom varje par (Fordonstyp och antal) i vår dictionary.
            foreach (var vehicleTypeAndCount in vehicleTypeCounts)
            {
                //skriv ut typnamnet och antalet. 
                Console.WriteLine($"{vehicleTypeAndCount.Key}: {vehicleTypeAndCount.Value}");
            }
        }
        public T GetVehicleByRegistrationNumber(string registrationNumber) // metod för hämta ett fordon baserat på registreringsnummer.
        {
            try
            {

                foreach (T vehicle in garage)
                {
                    if (vehicle != null && vehicle.RegistrationNumber.Replace("-", "").
                        Equals(registrationNumber.Replace("-", ""),
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return vehicle;
                    }
                }

                Console.WriteLine("No vehicle with that registration number was found");
                return null;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid registration number. Please try again.");
                return null;
            }
        }


        public List<T> GetVehiclesByProperty(string propertyName, string propertyValue)
        {
            List<T> matchingVehicles = new List<T>();

            try
            {

                foreach (T vehicle in garage)
                {
                    foreach (PropertyInfo property in typeof(T).GetProperties())

                    {
                        object value = property.GetValue(vehicle);

                        if (value != null &&
                            property.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase) &&
                            value.ToString().IndexOf(propertyValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            matchingVehicles.Add(vehicle);
                            break;
                        }
                    }
                }

                if (matchingVehicles.Count == 0)
                {
                    Console.WriteLine($"No vehicle with the property value {propertyValue} was found");
                }
                return matchingVehicles;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public void PopulateGarage()
        {

            ParkVehicle(new Airplane("AIRE-12", "blue", 2, 4, 2)as T);
            ParkVehicle(new Motorcycle("BRUM-456", "green", 2, 0, true)as T);
            ParkVehicle(new Car("ABC-123", "red", 4, 5, "Diesel")as T);
            ParkVehicle(new Boat("DEFG-789", "yellow", 0, 1, 15)as T);
            ParkVehicle(new Bus("HIJ-987", "orange", 6, 3, 100)as T);
        }

        public void RemoveVehicleByRegNumber(string registrationNumber)
        {
            garage.RemoveVehicleByRegNumber(registrationNumber);
        }

        public void EmptyGarage()
        {
            garage.EmptyGarage();
        }

    }
}
