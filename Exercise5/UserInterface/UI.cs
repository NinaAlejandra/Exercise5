using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.UserInterface
{
    internal class UI : IUI
    {
        private GarageHandler<Vehicle> handler;

        public UI(GarageHandler<Vehicle> garageHandler)
        {
            handler = garageHandler;
        }
        public void ShowMainMenu()
        {
            ConsoleKeyInfo key;
            int option = 0;
            string goBack = "\nPress any key to return to the main menu...";
            bool isProgramRunning = true;
            while (isProgramRunning)
            {

                bool isSelected = false;
                while (!isSelected)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Welcome to the Garage");
                    Console.ResetColor();
                    Console.WriteLine("\nYou will now be presented with some options");
                    Console.WriteLine("\n\u001b[36mUse the up and down arrows to navigate and Enter to select\u001b[0m");
                    Console.WriteLine("\nSelect:");

                    string option0 = (option == 0 ? "\n\u001b[34m0 to exit\u001b[0m" : "\n0 to exit");
                    string option1 = (option == 1 ? "\u001b[34m1 to populate the garage with vehicles\u001b[0m" : "1 to populate the garage with vehicles");
                    string option2 = (option == 2 ? "\u001b[34m2 to list all parked vehicles\u001b[0m" : "2 to list all parked vehicles");
                    string option3 = (option == 3 ? "\u001b[34m3 to list vehicle types and quantity in the garage\u001b[0m" : "3 to list vehicle types and quantity in the garage");
                    string option4 = (option == 4 ? "\u001b[34m4 to add a new vehicle to the garage\u001b[0m" : "4 to add a new vehicle to the garage");
                    string option5 = (option == 5 ? "\u001b[34m5 to find a vehicle by registration number\u001b[0m" : "5 to find a vehicle by registration number");
                    string option6 = (option == 6 ? "\u001b[34m6 to search for vehicles with specific properties\u001b[0m" : "6 to search for vehicles with specific properties");
                    string option7 = (option == 7 ? "\u001b[34m7 to remove a vehicle from the garage\u001b[0m" : "7 to remove a vehicle from the garage");
                    string option8 = (option == 8 ? "\u001b[34m8 to empty garage\u001b[0m" : "8 to empty garage");


                    Console.WriteLine(option0);
                    Console.WriteLine(option1);
                    Console.WriteLine(option2);
                    Console.WriteLine(option3);
                    Console.WriteLine(option4);
                    Console.WriteLine(option5);
                    Console.WriteLine(option6);
                    Console.WriteLine(option7);
                    Console.WriteLine(option8);


                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            option = (option == 8 ? 0 : option + 1);
                            break;

                        case ConsoleKey.UpArrow:
                            option = (option == 0 ? 8 : option -1);
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }

                }
                Console.WriteLine($"\nYou chose option {option}");


                switch (option)
                {
                    case 0:
                        isProgramRunning = false;
                        break;

                    case 1:
                        Console.WriteLine("\nPopulate garage:");
                        handler.PopulateGarage();
                        Console.WriteLine("\nGarage is now populated with:");
                        handler.ListAllVehicles();
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    case 2:
                        Console.WriteLine("\nList all vehicles:");
                        handler.ListAllVehicles();
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    case 3:
                        Console.WriteLine("\nList vehicle types and quantites:");
                        handler.ListVehicleTypesAndQuantities();
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    case 4:
                        Console.WriteLine("\nAdd vehicle to garage:");
                        handler.ParkVehicle();
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    case 5:
                        Console.WriteLine("\nSearch for a vehicle by registration number:");
                        string regNumber = Console.ReadLine();
                        Vehicle foundVehicle = handler.GetVehicleByRegistrationNumber(regNumber);
                        if (foundVehicle != null)
                        {
                            Console.WriteLine("Vehicle found:");
                            Console.WriteLine($"{foundVehicle.GetType().Name} Registration Number:{foundVehicle.RegistrationNumber}");
                        }
                        else
                        {
                            Console.WriteLine("No vehicle found with the specified registration number.");
                        }
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;


                    case 6:
                        Console.WriteLine("\nEnter the property to search for (e.g. color):");
                        string propertyName = Console.ReadLine();

                        Console.WriteLine($"Enter the value for the property {propertyName}:");
                        string propertyValue = Console.ReadLine();

                        List<Vehicle> matchingVehicles = handler.GetVehiclesByProperty(propertyName, propertyValue);

                        if (matchingVehicles.Count > 0)
                        {
                            Console.WriteLine("Vehicles with matching properties:");
                            foreach (var vehicle in matchingVehicles)
                            {
                                Console.WriteLine($"{vehicle.GetType().Name} Registration Number: {vehicle.RegistrationNumber}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No vehicles found with the specified {propertyName}");
                        }

                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    case 7:
                        Console.WriteLine("\nList of all the parked vehicles: ");
                        handler.ListAllVehicles();  
                        Console.WriteLine("\nRemove vehicle from garage by entering registration number of vehicle you wish to remove:");
                        string regNr = Console.ReadLine();
                        handler.RemoveVehicleByRegNumber(regNr);
                        //Console.WriteLine($"Vehicle with registration number {regNr} has been removed.");
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    case 8:
                        Console.WriteLine("\nEmpty the garage:");
                        handler.EmptyGarage();
                        Console.WriteLine("The garage is now empty.");
                        Console.WriteLine(goBack);
                        Console.ReadKey(true);
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
