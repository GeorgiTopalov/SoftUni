using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model) => this.models.Add(model);


        public IWeapon FindByName(string name) => this.models.FirstOrDefault(x => x.GetType().Name == name);


        public bool RemoveItem(string name) => this.models.Remove(FindByName(name));

    }
}
