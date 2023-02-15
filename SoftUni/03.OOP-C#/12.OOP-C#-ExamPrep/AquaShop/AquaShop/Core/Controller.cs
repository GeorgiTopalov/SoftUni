using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public DecorationRepository Decorations 
        {
            get => this.decorations;
        }
        public List<IAquarium> Aquariums
        {
            get => this.aquariums;
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            string aquariumFullName = string.Format("{0}.{1}", typeof(Aquarium).Namespace, aquariumType);
            Type type = Type.GetType(aquariumFullName);
            Aquarium aquarium = (Aquarium)Activator.CreateInstance(type, aquariumName);
            this.Aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

        }

        public string AddDecoration(string decorationType)
        {
            if(decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }

            string decorationFullName = string.Format("{0}.{1}", typeof(Decoration).Namespace, decorationType);
            Type type = Type.GetType(decorationFullName);
            Decoration decoration = (Decoration)Activator.CreateInstance(type);
            this.Decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }

            Aquarium aquarium = (Aquarium)this.Aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (aquarium == default)
            {
                throw new Exception();
            }

            string aquariumType = aquarium.GetType().Name;

            if (fishType == "FreshwaterFish" && aquariumType == "SaltwaterAquarium" ||
                fishType == "SaltwaterFish" && aquariumType == "FreshwaterAquarium")
            {
                return (string.Format(OutputMessages.UnsuitableWater));
            }

            Fish fish;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            //string fishFullName = string.Format("{0}.{1}", typeof(Fish).Namespace, fishType);
            //Type type = Type.GetType(fishFullName);
            //Fish fish = (Fish)Activator.CreateInstance(type, fishName, fishSpecies, price);

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

        }

        public string CalculateValue(string aquariumName)
        {
            decimal fishPrice = 0m;
            decimal decorationsPrice = 0m;


            Aquarium aquarium = (Aquarium)this.Aquariums.FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fishPrice += fish.Price;
            }
            foreach (var decoration in aquarium.Decorations)
            {
                decorationsPrice += decoration.Price;
            }

            decimal totalPrice = fishPrice + decorationsPrice;

            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{totalPrice:f2}");

        }

        public string FeedFish(string aquariumName)
        {
            Aquarium aquarium = (Aquarium)this.Aquariums.FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            Decoration decoration = (Decoration)this.Decorations.FindByType(decorationType);

            if (decoration == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            Aquarium aquarium = (Aquarium)this.Aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (aquarium == default)
            {
                throw new Exception();
            }

            aquarium.AddDecoration(decoration);
            this.Decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.Aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
