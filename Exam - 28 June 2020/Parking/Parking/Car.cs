using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        private string manufacturer;
        private string model;
        private int year;

        public Car(string manufacturer, string model, int year)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
        }

        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }

        public override string ToString()
        {
            return $"{manufacturer} {model} ({year})"; 
        }
    }
}
