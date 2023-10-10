namespace Exercise5
{
    internal interface IHandler<T> where T : Vehicle
    {
        void EmptyGarage();
        T GetVehicleByRegistrationNumber(string registrationNumber);
        List<T> GetVehiclesByProperty(string propertyName, string propertyValue);
        void ListAllVehicles();
        void ListVehicleTypesAndQuantities();
        void ParkVehicle();
        void ParkVehicle(T vehicle);
        void PopulateGarage();
        void RemoveVehicleByRegNumber(string registrationNumber);
    }
}