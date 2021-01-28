using System;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                Car newCar = new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));
                cars[i] = newCar;
            }

            while (true)
            {
                string[] driveInfo = Console.ReadLine().Split();

                if (driveInfo[0] == "End")
                {
                    break;
                }

                Car currentCar = cars.Where(c => c.Model == driveInfo[1]).FirstOrDefault();
                currentCar.Drive(double.Parse(driveInfo[2]));
            }

            Array.ForEach(cars, c => Console.WriteLine(c));
        }
    }
}
