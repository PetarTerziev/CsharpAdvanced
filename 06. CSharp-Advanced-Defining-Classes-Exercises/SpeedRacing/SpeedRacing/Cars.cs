using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {

            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
            TravelleDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelleDistance { get; set; }

        public void Drive(double amountOfKM)
        {
            double neededFuel = amountOfKM * FuelConsumptionPerKilometer;

            if (neededFuel <= FuelAmount)
            {
                FuelAmount -= neededFuel;
                TravelleDistance += amountOfKM;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelleDistance}";
        }

    }
}
