using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;
        private int exploredPlanets;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.ExploredPlanets = 0;
        }

        public int ExploredPlanets { get => this.exploredPlanets; private set => this.exploredPlanets = value; }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }

            this.astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }
        public string RetireAstronaut(string astronautName)
        {
            if (!astronauts.Models.Any(x => x.Name == astronautName))
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astronauts.FindByName(astronautName));
            return $"Astronaut {astronautName} was retired!";

        }
        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            Mission mission = new Mission();

            if (!astronauts.Models.Any(x => x.Oxygen >= 60))
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            List<IAstronaut> astronautsOnMission = astronauts.Models.Where(x => x.Oxygen >= 60).ToList();
            
            mission.Explore(planet, astronautsOnMission);

            int deadCounter = 0;

            foreach (var astronaut in astronautsOnMission.Where(x => x.Oxygen <= 0))
            {
                deadCounter++;
            }
            ExploredPlanets++;
            return $"Planet: { planetName } was explored! Exploration finished with { deadCounter } dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ExploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {String.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine($"Bag items: none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        
    }
}