using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;

            Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }
        public int Count => Cars.Count();

        public string AddCar(Car car) 
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string registrationNumber) 
        {

            if (!Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber) 
        {
            return Cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers) 
        {
            List<Car> result = new List<Car>();

            Array.ForEach(registrationNumbers.ToArray(), x => Cars.RemoveAll(c => c.RegistrationNumber == x));
        }
    }
}
