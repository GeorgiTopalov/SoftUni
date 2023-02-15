using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    internal class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }
            else if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException($"Invalid hero type.");
            }
            IHero hero;
            if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
                this.heroes.Add(hero);
                return $"Successfully added Barbarian { name } to the collection.";
            }
            else
            {
                hero = new Knight(name, health, armour);
                this.heroes.Add(hero);
                return $"Successfully added Sir { name } to the collection.";
            }
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }
            else if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            IWeapon weapon;

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                weapon = new Claymore(name, durability);
            }
            weapons.Add(weapon);
            return $"A { type.ToLower() } { name } is added to the collection";
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(x => x.Name == heroName))
            {
                throw new InvalidOperationException($"Hero { heroName } does not exist.");
            }
            else if (!weapons.Models.Any(x => x.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapom { weaponName } does not exist.");
            }
            else if (heroes.Models.FirstOrDefault(x => x.Name == heroName).Weapon != default)
            {
                throw new InvalidOperationException($"Hero { heroName } is well-armed.");
            }

            heroes.Models.FirstOrDefault(x => x.Name == heroName)
                         .AddWeapon(weapons.Models.FirstOrDefault(x => x.Name == weaponName));
            return $"Hero {heroName} can participate in battle using a {weapons.Models.FirstOrDefault(x => x.Name == weaponName).GetType().Name.ToLower() }.";
        }
        public string StartBattle()
        {
            Map map = new Map();
            ICollection<IHero> battleHeroes = new List<IHero>();

            foreach (Hero hero in heroes.Models.Where(x => x.IsAlive))
            {
                if (hero.Weapon != null)
                {
                    battleHeroes.Add(hero);
                }
            }

            return map.Fight(battleHeroes);
        }
        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Hero hero in this.heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");

                if (hero.Weapon != null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                else
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
