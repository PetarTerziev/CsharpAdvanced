using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private string name;
        private string class_;
        private string rank;
        private string description;

        public Player(string name, string class_)
        {
            this.name = name;
            this.class_ = class_;
            this.rank = "Trial";
            this.description = "n/a";

        }

        public string Name { get => name; set => name = value; }
        public string Class { get => class_; set => class_ = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");

            return sb.ToString().Trim(); 
        }
    }
}
