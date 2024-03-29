using Exercise5.Entities;
using Xunit;
using Exercise5; 



namespace Exercise5Test
{
    public class GarageTest
    {
        [Fact]
        public void ParkVehicleValid()
        {
            //Arrange
            var garage = new Garage<Car>(5);
            var vehicle = new Car("NIN-181", "purple", 4, 3, "Diesel");
            //Act
            garage.ParkVehicle(vehicle);

            //Assert
            var parkedVehicle = garage.FirstOrDefault();
            Assert.NotNull(parkedVehicle);
            Assert.Equal(vehicle, parkedVehicle);
        }

        [Fact]
        public void ParkVehicleInvalid()
        {
            //Arrange
            var garage = new Garage<Car>(5);


            //Act  
            var result = garage.ParkVehicle(new Car("NIN181", "purple", 4, 3, "diesel"));
            
            //Assert
            Assert.False(result);




        }
    }
}