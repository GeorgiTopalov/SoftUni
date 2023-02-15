using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        List<Fish> fish;
        string material;
        int capacity;

        public List<Fish> Fish { get { return this.fish; } set { this.fish = value; } }
        public string Material { get { return this.material; } set { this.material = value; } }
        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }
        public int Count { get { return fish.Count; } }

        public Net(string material, int capacity)
        {
            this.fish = new List<Fish>();
            this.material = material;
            this.capacity = capacity;
        }

        public string AddFish(Fish fish)
        {
            if (this.fish.Count == capacity)
            {
                return "Fishing net is full.";
            }
            if (fish.FishType == null ||
                fish.FishType == string.Empty ||
                fish.Weight <= 0 ||
                fish.Length <= 0)
            {
                return "Invalid fish.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";

        }
        public bool ReleaseFish(double weight)
        {
            foreach (Fish fish in fish)
            {
                if (fish.Weight.Equals(weight))
                {
                    this.fish.Remove(fish);
                    return true;
                }
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            foreach (Fish fish in fish)
            {
                if (fish.FishType.Equals(fishType))
                {
                    return fish;
                }
            }
            return null;
        }
        public Fish GetBiggestFish()
        {
            Fish longestFish = null;
            double longestFishLength = int.MinValue;

            foreach(Fish fish in fish)
            {
                if (fish.Length > longestFishLength)
                {
                    longestFish = fish;
                    longestFishLength = fish.Length;
                }
            }
            return longestFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (Fish f in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine($"{f}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
