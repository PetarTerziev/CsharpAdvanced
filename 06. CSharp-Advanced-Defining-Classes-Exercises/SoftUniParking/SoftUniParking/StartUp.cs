using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());

            var parking = new Parking(5);
            Console.WriteLine(parking.Count);
            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car2));
            Console.WriteLine(parking.Count);
            Console.WriteLine(parking.RemoveCar("xxx"));
            Console.WriteLine(parking.GetCar("CC1856BG").ToString());

            parking.RemoveSetOfRegistrationNumber(new List<string>() { "CC1856BG", "EB8787MN" });

            Console.WriteLine(parking.Count);

        }
    }
}
