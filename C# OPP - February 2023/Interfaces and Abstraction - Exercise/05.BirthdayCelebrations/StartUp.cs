
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizenPet = new List<IBirthable>();


            string input;
            while ((input=Console.ReadLine())!="End")
            {
                string[] ìnfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = ìnfo[0];

                switch (command)
                {
                    case "Citizen":
                        IBirthable citizen = new Citizen(ìnfo[1], int.Parse(ìnfo[2]), ìnfo[3], ìnfo[4]);
                        citizenPet.Add(citizen);
                        break;
                    case "Pet":
                        IBirthable pet = new Pet(ìnfo[1], ìnfo[2]);
                        citizenPet.Add(pet);
                        break;

                }
            }

            string data = Console.ReadLine();

            foreach (var itame in citizenPet)
            {

                if (itame.Birthdate.EndsWith(data))
                {
                    Console.WriteLine(itame.Birthdate);

                }
            }


        }
    }
}
