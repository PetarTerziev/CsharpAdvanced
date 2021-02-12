using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;

        public Parking(string type, int capacity)
        {
            this.type = type;
            this.capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get => type; set => type = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Count => data.Count;

        public void Add(Car car) 
        {
            if (Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model) 
        {
            if (data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                data.RemoveAll(c => c.Manufacturer == manufacturer && c.Model == model);
                return true;
            }

            return false;
        }
        public Car GetLatestCar() 
        {
            Car latestCar = new Car("","", int.MinValue);
            bool isLatestCarExist = false;

            foreach (Car car in data)
            {
                if (car.Year > latestCar.Year)
                {
                    latestCar = car;
                    isLatestCarExist = true;
                }
            }

            if (isLatestCarExist)
            {
                return latestCar;
            }

            return null;
        }

        public Car GetCar(string manufacturer, string model) 
        {
            return data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {type}:");

            foreach (Car car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
