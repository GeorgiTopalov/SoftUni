// ReSharper disable InconsistentNaming
// ReSharper disable FunctionNeverReturns
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    internal class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }

            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (this.cars.FindBy(carVIN) == default)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException("Invalid racer type!");
            }
            IRacer racer;

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, this.cars.FindBy(carVIN));
            }
            else
            {
                racer = new StreetRacer(username, this.cars.FindBy(carVIN));
            }
            racers.Add(racer);

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (this.racers.FindBy(racerOneUsername) == default)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (this.racers.FindBy(racerTwoUsername) == default)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            IMap map = new Map();
            return map.StartRace(this.racers.FindBy(racerOneUsername), this.racers.FindBy(racerTwoUsername));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Racer racer in this.racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}