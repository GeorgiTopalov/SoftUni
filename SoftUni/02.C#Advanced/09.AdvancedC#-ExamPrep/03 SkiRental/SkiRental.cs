using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    internal class SkiRental
    {
        string name;
        int capacity;
        List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int Count { get { return this.data.Count; } }

        public void Add(Ski ski)
        {
            if (this.capacity > this.Count)
            {
                this.data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski ski = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == default)
            {
                return false;
            }

            data.Remove(ski);
            return true;
        }

        public Ski GetSki(string manufacturer, string model) => this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public Ski GetNewestSki() => this.data.OrderByDescending(x => x.Year).FirstOrDefault();
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}");

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
