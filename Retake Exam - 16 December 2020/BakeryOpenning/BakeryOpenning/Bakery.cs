using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        private string name;

        private int capacity;
        public Bakery(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            data = new List<Employee>();
        }
        public string Name { get => name; set => name = value; }

        public int Capacity { get => capacity; set => capacity = value; }

        public int Count => data.Count;

        public void Add(Employee employee) 
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name) 
        {
            if (data.Any(e => e.Name == name))
            {
                data.RemoveAll(e => e.Name == name);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee() 
        {
            int oldestAge = int.MinValue;

            foreach (var empl in data)
            {
                if (empl.Age > oldestAge)
                {
                    oldestAge = empl.Age;
                }
            }

            return data.FirstOrDefault(e => e.Age == oldestAge);
        }

        public Employee GetEmployee(string name) 
        { 
            return data.FirstOrDefault(e => e.Name == name);
        }

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var empl in data)
            {
                sb.AppendLine($"Employee: {empl.Name}, {empl.Age} ({empl.Country})");
            }

            return sb.ToString().Trim();
        }
    }
}
