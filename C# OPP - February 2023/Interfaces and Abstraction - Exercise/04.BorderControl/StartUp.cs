using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> inhabitants = new List<IIdentifiable>();


            string input;
            while ((input=Console.ReadLine())!="End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);


                if (data.Length==3)
                {

                    IIdentifiable citizen = new Citizen(data[0], int.Parse(data[1]), data[2]);

                    inhabitants.Add(citizen);

                }
                else
                {
                    IIdentifiable robot = new Robot(data[0], (data[1]));

                    inhabitants.Add(robot);
                }
            }

            string fakeID = Console.ReadLine();

            foreach (var inhabitan in inhabitants)
            {

                if (inhabitan.Id.EndsWith(fakeID))
                {
                    Console.WriteLine(inhabitan.Id);

                }
            }


        }
    }
}
