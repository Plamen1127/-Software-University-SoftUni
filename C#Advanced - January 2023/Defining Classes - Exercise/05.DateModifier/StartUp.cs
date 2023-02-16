using Date_Modifier;
using System;

namespace Date_Modifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            int diferenceDay = DateModifier.GetDiferenseDay(start, end);

            Console.WriteLine(diferenceDay);
        }
    }
}