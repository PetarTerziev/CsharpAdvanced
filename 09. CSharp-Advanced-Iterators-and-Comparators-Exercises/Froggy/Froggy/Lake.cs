using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(List<int> stones)
        {
            this.Stones = stones;
        }
        public List<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            int[] numOddIndex = Stones.Where((s, i) => i % 2 != 0).Reverse().ToArray();
            int[] numEvenIndex = Stones.Where((s, i) => i % 2 == 0).ToArray();
            int[] array = numEvenIndex.Concat(numOddIndex).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
