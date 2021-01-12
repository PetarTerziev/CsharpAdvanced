using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int countOfPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumpInfo = new Queue<int[]>();
            FillQueue(pumpInfo, countOfPumps);
            int pumpPosCounter = -1;

            while (true)
            {
                pumpPosCounter++;

                bool isPumpCorrectPoint = true;
                int fuelQuantity = 0;

                foreach (var pump in pumpInfo)
                {
                    fuelQuantity += pump[0] - pump[1];

                    if (fuelQuantity < 0)
                    {
                        isPumpCorrectPoint = false;
                        break;
                    }
                }

                if (isPumpCorrectPoint)
                {
                    break;
                }

                pumpInfo.Enqueue(pumpInfo.Dequeue());
            }

            Console.WriteLine(pumpPosCounter);
        }

        static void FillQueue(Queue<int[]> input, int countOfPumps) 
        {
            for (int i = 0; i < countOfPumps; i++)
            {
                input.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
        }
    }
}
