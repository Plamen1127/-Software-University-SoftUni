using System;


namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            SoulMaster am = new SoulMaster("plamen", 5);
            Console.WriteLine(am);
        }
    }
}