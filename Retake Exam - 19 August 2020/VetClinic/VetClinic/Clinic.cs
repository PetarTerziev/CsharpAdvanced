using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        private int capacity;

        public Clinic(int capacity)
        {
            this.capacity = capacity;
            this.data = new List<Pet>();
        }
        public int Capacity { get => capacity; set => capacity = value; }

        public int Count => data.Count;

        public void Add(Pet pet) 
        {
            if (Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(p => p.Name == name))
            {
                data.RemoveAll(p => p.Name == name);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner) 
        {
            return data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet() 
        {
            Pet oldestDog = new Pet("", int.MinValue, "");

            foreach (Pet pet in data)
            {
                if (pet.Age > oldestDog.Age)
                {
                    oldestDog = pet;
                }
            }

            return oldestDog; 
        }

        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (Pet pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }

    }
}
