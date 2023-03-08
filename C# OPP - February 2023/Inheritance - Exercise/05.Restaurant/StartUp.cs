namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee cofi = new Coffee("exspreso", 500);

            System.Console.WriteLine(cofi.Milliliters);
            System.Console.WriteLine(cofi.Caffeine);
        }
    }
}