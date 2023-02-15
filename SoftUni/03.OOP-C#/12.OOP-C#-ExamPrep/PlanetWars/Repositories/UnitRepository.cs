﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.models;

        public void AddItem(IMilitaryUnit model) => this.models.Add(model);
        

        public IMilitaryUnit FindByName(string name) => this.models.FirstOrDefault(x => x.GetType().Name == name);
        

        public bool RemoveItem(string name) => this.models.Remove(FindByName(name));
    }
}
