﻿using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.models;

        public void Add(IEgg model) => this.models.Add(model);

        public IEgg FindByName(string name) => this.models.FirstOrDefault(x => x.Name.Equals(name));

        public bool Remove(IEgg model) => this.models.Remove(model); 
    }
}
