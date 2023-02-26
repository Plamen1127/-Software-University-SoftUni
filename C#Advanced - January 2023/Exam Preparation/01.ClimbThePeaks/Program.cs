using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] portions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] stamina = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stackPortions = new Stack<int>(portions);
            Queue<int> queueStamina = new Queue<int>(stamina);

            Stack<int> difficultyLevel = new Stack<int>();
            difficultyLevel.Push(70);
            difficultyLevel.Push(60);
            difficultyLevel.Push(100);
            difficultyLevel.Push(90);
            difficultyLevel.Push(80);
            Stack<string> mounts = new Stack<string>();
            mounts.Push("Kamenitza");
            mounts.Push("Polezhan");
            mounts.Push("Banski Suhodol");
            mounts.Push("Kutelo");
            mounts.Push("Vihren");
            Queue<string> mountingPeaks = new Queue<string>();


            while (mounts.Count>0 && stackPortions.Count>0 && queueStamina.Count>0 && difficultyLevel.Count>0)
            {
                
                int energi = stackPortions.Pop() + queueStamina.Dequeue();

                if (energi>=difficultyLevel.Peek())
                {
                    mountingPeaks.Enqueue(mounts.Pop());
                    difficultyLevel.Pop();
                }

            }

            if (mountingPeaks.Count == 5)
            {
                Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine($"Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (mountingPeaks.Count>0)
            {
                Console.WriteLine("Conquered peaks:");
                for (int i = mountingPeaks.Count; i > 0; i--)
                {
                    Console.WriteLine(mountingPeaks.Dequeue());
                }
            }
           
        }



    }
}
