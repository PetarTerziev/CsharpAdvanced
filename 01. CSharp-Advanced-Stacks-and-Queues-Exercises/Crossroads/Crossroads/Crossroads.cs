using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int freeWindowTime = int.Parse(Console.ReadLine());
            Queue<string> carList = new Queue<string>();
            int totalCarsPassed = 0;

            while (true)
            {
                string carName = Console.ReadLine();
                int greenLightSecondsPassed = greenLightTime;
                int freeWindowSecondsPassed = freeWindowTime;

                if (carName == "END")
                {
                    Console.WriteLine($"Everyone is safe.");
                    Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");

                    break;
                }

                if (carName != "green")
                {
                    carList.Enqueue(carName);
                }
                else
                {
                    while (greenLightSecondsPassed > 0 && carList.Count != 0)
                    {
                        string firstInQueue = carList.Dequeue();
                        greenLightSecondsPassed -= firstInQueue.Length;

                        if (greenLightSecondsPassed >= 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            freeWindowSecondsPassed += greenLightSecondsPassed;

                            if (freeWindowSecondsPassed < 0)
                            {
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{firstInQueue} was hit at " +
                                                  $"{firstInQueue[firstInQueue.Length + freeWindowSecondsPassed]}.");
                                return;
                            }

                            totalCarsPassed++;
                        }
                    }
                } 
            }

        }
    }
}
