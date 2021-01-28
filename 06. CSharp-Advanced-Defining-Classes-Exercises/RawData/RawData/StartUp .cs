using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
                cars[i] = CreateNewCar(Console.ReadLine().Split());
            }

            string command = Console.ReadLine();
            Func<Car, bool> delegateFilter = FilterCriteria(command);

            foreach (var car in cars)
            {
                if (delegateFilter(car))
                {
                    Console.WriteLine(car);
                }
            }
        }

        private static Func<Car, bool> FilterCriteria(string command)
        {
            switch (command)
            {
                case "fragile":
                    return c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1);
                case "flamable":
                    return c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250;
                default:
                    return null;
            };
        }

        static Car CreateNewCar(string[] carInfo) 
        {
            string carName = carInfo[0];
            Engine newEngine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
            Cargo newCargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
            Tire[] newTires = CreateNewTires(carInfo.Skip(5).ToArray());

            return new Car(carName, newEngine, newCargo, newTires);
        }

        static Tire[] CreateNewTires(string[] tireInfo) 
        {
            List<Tire> tires = new List<Tire>();

            for (int i = 0; i < tireInfo.Length; i+= 2)
            {
                Tire newTire = new Tire(double.Parse(tireInfo[i]), int.Parse(tireInfo[i + 1]));
                tires.Add(newTire);
            }

            return tires.ToArray();
        }
    }
}
