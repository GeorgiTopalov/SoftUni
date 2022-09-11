using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        List<Drone> drones;

        public List<Drone> Drones { get { return this.drones; } set { this.drones = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => this.drones.Count;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Drones = new List<Drone>();
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
        }

        public string AddDrone(Drone drone)
        {
            if (Capacity <= drones.Count)
            {
                return "Airfield is full.";
            }
            else
            {
                if ((drone.Name != null) &&
                (drone.Name != string.Empty) &&
                (drone.Range >= 5) &&
                (drone.Range <= 15))
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
            }
            return "Invalid drone.";
        }
        public bool RemoveDrone(string name)
        {
            var drone = Drones.FirstOrDefault(dr => dr.Name == name);
            return Drones.Remove(drone);

        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;

            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Brand == brand)
                {
                    count++;
                    Drones.Remove(Drones[i]);
                    i--;
                }
            }
            return count;
        }

        public Drone FlyDrone(string name)
        {
            foreach (Drone drone in Drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return drone;
                }
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyingDrones = new List<Drone>();

            foreach (Drone drone in Drones)
            {
                if (drone.Range >= range && drone.Available == true)
                {
                    flyingDrones.Add(drone);
                    drone.Available = false;
                }
            }

            return flyingDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (Drone drone in Drones.Where(x=>x.Available == true))
            {
                sb.AppendLine($"{drone}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
