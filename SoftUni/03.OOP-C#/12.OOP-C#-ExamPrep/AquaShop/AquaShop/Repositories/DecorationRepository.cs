﻿using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models;

        public Decoration FirstOrDefault { get; internal set; }

        public void Add(IDecoration model) => this.models.Add(model);

        public IDecoration FindByType(string type) => this.Models.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IDecoration model) => this.models.Remove(model);
        
    }
}
