
using _02.CarExtension;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "Mercedes";
            car.Model = "C220";
            car.Year = 2004;
            car.FuelQuantity = 200;
            car.FuelConsumption = 20;
            car.Drive(10);
            Console.WriteLine(car.WhoAmI());
        }
    }
}