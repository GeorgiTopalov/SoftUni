﻿using SpaceStation.Models.Bags.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly ICollection<string> items;

        public Backpack()
        {
            this.items = new List<string>();
        }
        public ICollection<string> Items => this.items;
    }
}
