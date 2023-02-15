using Heroes.Models.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();
            int barbCasualties = 0;
            int knightsCasualties = 0;
            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == "Barbarian")
                {
                    barbarians.Add(hero);
                }
                else
                {
                    knights.Add(hero);
                }
            }
            while (true)
            {
                foreach (IHero hero in knights.Where(x => x.IsAlive))
                {
                    foreach (IHero h in barbarians.Where(x => x.IsAlive))
                    {
                        h.TakeDamage(hero.Weapon.DoDamage());

                        if (!h.IsAlive)
                        {
                            barbCasualties++;
                        }
                    }
                }

                foreach (IHero h in barbarians.Where(x => x.IsAlive))
                {
                    foreach (IHero hero in knights.Where(x => x.IsAlive))
                    {
                        hero.TakeDamage(h.Weapon.DoDamage());

                        if (!hero.IsAlive)
                        {
                            knightsCasualties++;
                        }
                    }
                }

                if (!knights.Any(x => x.IsAlive))
                {
                    return $"The barbarians took {barbCasualties} casualties but won the battle.";
                }
                else if (!barbarians.Any(x => x.IsAlive))
                {
                    return $"The knights took {knightsCasualties} casualties but won the battle.";
                }
            }


        }
    }
}
