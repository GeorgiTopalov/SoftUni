﻿using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
                get { return this.name; }
                private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);

                }
                this.name = value;
            }

        }

        public int EnergyRequired
        {
            get { return this.energyRequired; }
            private set
            {
                if (value < 0)
                {
                   value = 0;
                }
                this.energyRequired = value;
            }

        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }
            return false;
        }
    }
}