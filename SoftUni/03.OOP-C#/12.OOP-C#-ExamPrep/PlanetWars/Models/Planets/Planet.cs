using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private readonly UnitRepository units;
        private readonly WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }
        public double MilitaryPower
        {
            get 
            {
                double value = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);

                if (this.units.Models.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                {
                    value *= 1.30;
                }
                if (this.weapons.Models.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    value *= 1.45;
                }
                return Math.Round(value, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => this.units.AddItem(unit);
        

        public void AddWeapon(IWeapon weapon) => this.weapons.AddItem(weapon);
        
        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }
        public void Profit(double amount)
        {
            this.Budget += amount;

        }
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            if (!this.Army.Any())
            {
                sb.AppendLine($"--Forces: No units");
            }
            else
            {
                sb.AppendLine($"--Forces: {string.Join(", ", this.Army.Select(x => x.GetType().Name))}");
            }
            if (!this.Weapons.Any())
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", this.Weapons.Select(x => x.GetType().Name))}");
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        
        
    }
}
