﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets.Contracts
{
    public class Planet : IPlanet
    {
        private string name;
        private readonly List<string> items;
        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }
        public ICollection<string> Items => this.items;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }
    }
}
