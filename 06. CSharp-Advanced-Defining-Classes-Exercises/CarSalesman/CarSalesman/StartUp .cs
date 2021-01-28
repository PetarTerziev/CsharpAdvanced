using System;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countEngines = int.Parse(Console.ReadLine());
            Engine[] engines = new Engine[countEngines];

            for (int i = 0; i < countEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                engines[i] = CreateEngine(engineInfo);
            }

            int countCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[countCars];

            for (int i = 0; i < countCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cars[i] = CreateCar(carInfo, engines);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }

        static Engine CreateEngine(string[] engineInfo) 
        {
            string model = engineInfo[0];
            string power = engineInfo[1];
            string displacement = engineInfo.Length == 4 ? engineInfo[2] : string.Empty;
            string efficiency = engineInfo.Length == 4 ? engineInfo[3] : string.Empty;
            int result = 0;

            if (engineInfo.Length == 2)
            {
                displacement = "n/a";
                efficiency = "n/a";
            }
            else if (engineInfo.Length == 3)
            {
                bool success = int.TryParse(engineInfo[2], out result);

                if (success)
                {
                    efficiency = "n/a";
                    displacement = result.ToString();
                }
                else
                {
                    displacement = "n/a";
                    efficiency = engineInfo[2];
                }
            }

            return new Engine(model, power, displacement, efficiency);
        }

        static Car CreateCar(string[] carInfo, Engine[] engines)
        {
            string model = carInfo[0];
            Engine engine = engines.Where(e => e.Model == carInfo[1]).FirstOrDefault();
            string weight = carInfo.Length == 4 ? carInfo[2] : string.Empty;
            string color = carInfo.Length == 4 ? carInfo[3] : string.Empty;
            int result = 0;

            if (carInfo.Length == 2)
            {
                weight = "n/a";
                color = "n/a";
            }
            else if (carInfo.Length == 3)
            {
                bool success = int.TryParse(carInfo[2], out result);

                if (success)
                {
                    color = "n/a";
                    weight = result.ToString();
                }
                else
                {
                    weight = "n/a";
                    color = carInfo[2];
                }
            }

            return new Car(model, engine, weight, color);
        }
    }
}
