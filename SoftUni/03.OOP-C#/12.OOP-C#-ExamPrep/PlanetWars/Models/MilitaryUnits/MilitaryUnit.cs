using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel;
        private double cost;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.enduranceLevel = 1;
        }
        public double Cost
        {
            get => this.cost;
            private set => this.cost = value;
        }

        public int EnduranceLevel => this.enduranceLevel;

        public void IncreaseEndurance()
        {
            if (this.enduranceLevel == 20)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.EnduranceLevelExceeded));
            }

            this.enduranceLevel++;
        }
    }
}
