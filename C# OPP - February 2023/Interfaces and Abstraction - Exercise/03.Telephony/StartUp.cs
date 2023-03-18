using System;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] pfoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICalling phone;
            foreach (var number in pfoneNumbers)
            {
                if (number.Length == 7)
                {
                    phone = new StationaryPhone();

                }
                else
                {
                    phone = new Smartphone();
                   
                }

                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsing browse = new Smartphone();
            foreach (var web in websites)
            {
                try
                {
                    Console.WriteLine(browse.Browse(web));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
