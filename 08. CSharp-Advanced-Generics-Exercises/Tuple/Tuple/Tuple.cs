using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    class Tuple<Tfisrt, Tsecond>
    {
        private Tfisrt item1;
        private Tsecond item2;

        public Tuple(Tfisrt fisrt, Tsecond second)
        {
            this.item1 = fisrt;
            this.item2 = second;
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

        public override string ToString()
        {
            return $"{Item1} -> {Item2}"; 
        }

    }
}
