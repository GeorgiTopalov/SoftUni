
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> models;
        public HeroRepository()
        {
            this.models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.models;

        public void Add(IHero model) => this.models.Add(model);

        public IHero FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IHero model) => this.models.Remove(model);
    }
}
