using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    internal class Controller : IController
    {
        private readonly PilotRepository pilots;
        private readonly FormulaOneCarRepository cars;
        private readonly RaceRepository races;

        public Controller()
        {
            this.pilots = new PilotRepository();
            this.cars = new FormulaOneCarRepository();
            this.races = new RaceRepository();
        }

        public PilotRepository Pilots { get => this.pilots; }
        public FormulaOneCarRepository Cars { get => this.cars; }
        public RaceRepository Races { get => this.races; }
        public object Car { get; private set; }

        public string CreatePilot(string fullName)
        {
            if (Pilots.FindByName(fullName) != default)
            {
                throw new InvalidOperationException($"Pilot { fullName } is already created.");
            }
            this.Pilots.Add(new Pilot(fullName));

            return $"Pilot { fullName } is created.";
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (Cars.FindByName(model) != default)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            string carFullType = string.Format("{0}.{1}", typeof(FormulaOneCar).Namespace, type);
            Type carType = Type.GetType(carFullType);
            FormulaOneCar car = (FormulaOneCar)Activator.CreateInstance(carType, model, horsepower, engineDisplacement);
            this.Cars.Add(car);

            return $"Car { type }, model { model } is created.";
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.Races.FindByName(raceName) != default)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }

            this.Races.Add(new Race(raceName, numberOfLaps));
            return $"Race { raceName } is created.";
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IFormulaOneCar car = this.Cars.FindByName(carModel);
            IPilot pilot = this.Pilots.FindByName(pilotName);

            if ((pilot == default) || (pilot.Car != null))
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }
            if (car == default)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }

            pilot.AddCar(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { carModel } car.";

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = this.Pilots.FindByName(pilotFullName);
            IRace race = this.Races.FindByName(raceName);
            if (race == default)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if ((pilot == default) || (!pilot.CanRace))
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot { pilotFullName } is added to the { raceName } race.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.Races.FindByName(raceName);

            if (race == default)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race { raceName } cannot start with less than three participants.");
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }

            Dictionary<string, double> rankings = new Dictionary<string, double>();
            rankings.Clear();

            foreach (var pilot in race.Pilots)
            {
                rankings.Add(pilot.FullName, pilot.Car.RaceScoreCalculator(race.NumberOfLaps));
            }

           //Queue<KeyValuePair<string, double>> finalRankings = new Queue<KeyValuePair<string, double>>();
           //
           //foreach (var pilot in rankings.OrderByDescending(x => x.Value).Take(3))
           //{
           //    finalRankings.Enqueue(pilot);
           //}
            List<string> topRacers = new List<string>();
            
            foreach (var pilot in rankings.OrderByDescending(x => x.Value).Take(3))
            {
                topRacers.Add(pilot.Key);
            }
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Pilot {topRacers[0]} wins the { raceName } race.");
            sb.AppendLine($"Pilot {topRacers[1]} is second in the { raceName } race.");
            sb.AppendLine($"Pilot {topRacers[2]} is third in the { raceName } race.");

            this.Pilots.FindByName(topRacers[0]).WinRace();
            race.TookPlace = true;
            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in this.Pilots.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in this.Races.Models.Where(x => x.TookPlace))
            {
               sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

    }
}