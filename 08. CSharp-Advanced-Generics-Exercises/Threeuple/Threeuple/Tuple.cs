using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    class Tuple<Tfisrt, Tsecond, Tthird>
    {
        private Tfisrt item1;
        private Tsecond item2;
        private Tthird item3;


        public Tuple(Tfisrt fisrt, Tsecond second, Tthird third)
        {
            this.item1 = fisrt;
            this.item2 = second;
            this.item3 = third;

        }

        public Tfisrt Item1 
        {
            get { return this.item1; }
            set { this.item1 = value; } 
        }

        public Tsecond Item2
        {
            get { return this.item2; }
            set { this.item2 = value; }
        }

        public Tthird Item3
        {
            get { return this.item3; }
            set { this.item3 = value; }
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}"; 
        }

    }
}
