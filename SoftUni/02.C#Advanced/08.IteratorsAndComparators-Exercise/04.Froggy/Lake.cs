﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {

            for (int i = 0; i < stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }
            };
            for (int i = stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}
