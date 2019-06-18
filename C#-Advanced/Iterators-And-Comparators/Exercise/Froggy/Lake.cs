using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] jumps;

        public Lake(int[] jumps)
        {
            this.jumps = jumps; 
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < jumps.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return jumps[i];
                }
            }

            for (int i = jumps.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return jumps[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
