using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> items = new List<string>();

            foreach (var item in planet.Items)
            {
                items.Add(item);
            }
            foreach (var astronaut in astronauts)
            {
                for (var i = 0; i < items.Count; i++)
                {
                    astronaut.Breath();
                    

                    string currentItem = items[i];
                    astronaut.Bag.Items.Add(currentItem);
                    items.Remove(currentItem);
                    planet.Items.Remove(currentItem);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                    i--;
                }
            }
        }
    }
}
