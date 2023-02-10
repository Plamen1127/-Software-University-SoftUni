namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "Mercedes";
            Console.WriteLine(car.Make);
        }
    }
}
