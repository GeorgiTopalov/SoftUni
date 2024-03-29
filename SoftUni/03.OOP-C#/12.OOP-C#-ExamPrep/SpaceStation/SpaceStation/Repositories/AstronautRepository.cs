﻿using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.models;

        public void Add(IAstronaut model) => this.models.Add(model);


        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IAstronaut model) => this.models.Remove(model);
    }
}
