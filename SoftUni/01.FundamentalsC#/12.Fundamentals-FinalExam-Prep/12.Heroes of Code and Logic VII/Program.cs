using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Hero
    {
        public Hero(string name, int health, int mana)
        {
            this.Name = name;
            this.MP = mana;
            this.HP = health;
        }
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());

            List<Hero> party = new List<Hero>();

            for (int i = 0; i < partySize; i++)
            {
                string[] character = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currHeroName = character[0];
                int heroHP = int.Parse(character[1]);
                int heroMP = int.Parse(character[2]);
                Hero newHero = new Hero(currHeroName, heroHP, heroMP);

                party.Add(newHero);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string heroName = inputArgs[1];

                if (command == "CastSpell")
                {
                    int neededMP = int.Parse(inputArgs[2]);
                    string spellName = inputArgs[3];

                    CastSpell(party, heroName, neededMP, spellName);
                }
                else if (command == "TakeDamage")
                {
                    int damageTaken = int.Parse(inputArgs[2]);
                    string attacker = inputArgs[3];

                    TakeDamage(party, heroName, damageTaken, attacker);
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(inputArgs[2]);
                    Recharge(party, heroName, amount);
                }
                else
                {
                    int amount = int.Parse(inputArgs[2]);
                    Heal(party, heroName, amount);
                }
            }

            foreach (Hero hero in party)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"HP: {hero.HP}");
                Console.WriteLine($"MP: {hero.MP}");
            }
        }
        static List<Hero> CastSpell(List<Hero> party, string heroName, int neededMP, string spellName)
        {
            foreach (Hero hero in party)
            {
                if (hero.Name == heroName)
                {
                    if (neededMP > hero.MP)
                    {
                        Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
                    }
                    else
                    {
                        hero.MP -= neededMP;
                        Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.MP} MP!");
                    }
                    break;
                }
            }
            return party;
        }
        static List<Hero> TakeDamage(List<Hero> party, string heroName, int damageTaken, string attacker)
        {
            foreach (Hero hero in party)
            {
                if (hero.Name == heroName)
                {
                    if (hero.HP > damageTaken)
                    {
                        hero.HP -= damageTaken;
                        Console.WriteLine($"{hero.Name} was hit for {damageTaken} HP by {attacker} and now has {hero.HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                        party.Remove(hero);
                    }
                    break;
                }
            }
            return party;
        }
        static List<Hero> Recharge(List<Hero> party, string heroName, int amount)
        {
            foreach (Hero hero in party)
            {
                if (hero.Name == heroName)
                {
                    hero.MP += amount;
                    if (hero.MP > 200)
                    {
                        amount = 200 + amount - hero.MP;
                        hero.MP = 200;
                    }
                    Console.WriteLine($"{hero.Name} recharged for {amount} MP!");
                    break;
                }
            }
            return party;
        }
        static List<Hero> Heal(List<Hero> party, string heroName, int amount)
        {
            foreach (Hero hero in party)
            {
                if (hero.Name == heroName)
                {
                    hero.HP += amount;
                    if (hero.HP > 100)
                    {
                        amount = 100 + amount - hero.HP;
                        hero.HP = 100;
                    }
                    Console.WriteLine($"{hero.Name} healed for {amount} HP!");
                    break;
                }
            }
            return party;
        }
    }
}
