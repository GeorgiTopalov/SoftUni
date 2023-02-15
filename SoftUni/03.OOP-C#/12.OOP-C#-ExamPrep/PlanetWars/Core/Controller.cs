using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != default)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            Planet planet = new Planet(name, budget);
            this.planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != "StormTroopers" &&
                     unitTypeName != "SpaceForces" &&
                     unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            string unitFullName = string.Format("{0}.{1}", typeof(MilitaryUnit).Namespace, unitTypeName);
            Type type = Type.GetType(unitFullName);
            MilitaryUnit militaryUnit = (MilitaryUnit)Activator.CreateInstance(type);
            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" &&
                     weaponTypeName != "NuclearWeapon" &&
                     weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
         
            string unitFullName = string.Format("{0}.{1}", typeof(Weapon).Namespace, weaponTypeName);
            Type type = Type.GetType(unitFullName);
            Weapon weapon = Activator.CreateInstance(type, destructionLevel) as Weapon;
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.TrainArmy();
            planet.Spend(1.25);

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);
            string winningPlanet = String.Empty;
            string losingPlanet = String.Empty;

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price));
                planets.RemoveItem(planetTwo);

                winningPlanet = firstPlanet.Name;
                losingPlanet = secondPlanet.Name;
            }
            else if (secondPlanet.MilitaryPower > firstPlanet.MilitaryPower)
            {
                winningPlanet = secondPlanet.Name;
                losingPlanet = firstPlanet.Name;

                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price));
                planets.RemoveItem(planetOne);
            }
            else if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon") && secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")) ||
                    ((!firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")) && (!secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return String.Format(OutputMessages.NoWinner);
                }
                else if (firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    winningPlanet = secondPlanet.Name;
                    losingPlanet = firstPlanet.Name;

                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price));
                    planets.RemoveItem(planetTwo);
                }
                else
                {
                    winningPlanet = secondPlanet.Name;
                    losingPlanet = firstPlanet.Name;

                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price));
                    planets.RemoveItem(planetOne);
                }
            }

            return String.Format(OutputMessages.WinnigTheWar, winningPlanet, losingPlanet);
        }
        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

    }
}