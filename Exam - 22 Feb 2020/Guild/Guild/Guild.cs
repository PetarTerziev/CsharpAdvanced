using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private string name;
        private int capacity;
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Count => roster.Count;

        public void AddPlayer(Player player) 
        {
            if (Count < capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name) 
        {
            if (roster.Any(p => p.Name == name))
            {
                roster.RemoveAll(p => p.Name == name);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name) 
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string class_)
        {
            Player[] result = roster.Where(p => p.Class == class_).ToArray();
            roster.RemoveAll(p => p.Class == class_);
            return result ;
        }

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();

        }


    }
}
