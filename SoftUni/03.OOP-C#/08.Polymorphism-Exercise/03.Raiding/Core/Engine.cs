using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Raiding
{
    public class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                BaseHero newHero = null;
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Paladin")
                {
                    newHero = new Paladin(heroName);
                }
                else if (heroType == "Druid")
                {
                    newHero = new Druid(heroName);

                }
                else if (heroType == "Rogue")
                {
                    newHero = new Rogue(heroName);

                }
                else if (heroType == "Warrior")
                {
                    newHero = new Warrior(heroName);

                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }
                raidGroup.Add(newHero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero newHero in raidGroup)
            {
                Console.WriteLine(newHero.CastAbility());
            }

            if (raidGroup.Sum(x => x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
