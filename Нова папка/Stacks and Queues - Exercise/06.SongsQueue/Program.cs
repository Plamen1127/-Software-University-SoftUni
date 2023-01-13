using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", "));

            while (queue.Count>0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string newSong = command.Substring(4);

                    if (queue.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(newSong);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
