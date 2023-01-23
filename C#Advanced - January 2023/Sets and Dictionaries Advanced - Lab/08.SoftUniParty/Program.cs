using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            List<string> regularGuests = new List<string>();

            string reservation = Console.ReadLine();

            while (reservation != "PARTY")
            {
                guests.Add(reservation);

                reservation = Console.ReadLine();
            }

            while (reservation != "END")
            {
                guests.Remove(reservation);
                reservation = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);


            foreach (var item in guests)
            {
                
                if (char.IsDigit(item[0]))
                {
                    Console.WriteLine(item);
                }
                else
                {
                    regularGuests.Add(item);
                }
            }

            foreach (var item in regularGuests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
