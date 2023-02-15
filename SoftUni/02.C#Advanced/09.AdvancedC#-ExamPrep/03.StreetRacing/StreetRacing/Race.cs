using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;
        private List<Car> cars;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.name = name;
            this.type = type;
            this.laps = laps;
            this.capacity = capacity;
            this.maxHorsePower = maxHorsePower;
            this.cars = new List<Car>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Laps
        {
            get { return laps; }
            set { laps = value; }
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int MaxHorsePower
        {
            get { return maxHorsePower; }
            set { maxHorsePower = value; }
        }

        public int Count { get { return this.cars.Count; } }

        public void Add(Car car)
        {
           if((!cars.Any(x => x.LicensePlate == car.LicensePlate))
                && (this.Capacity > 0 )
                && (car.HorsePower <= this.MaxHorsePower))
            {
                cars.Add(car);
                this.Capacity--;
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = cars.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (car != default)
            {
                cars.Remove(car);
                this.Capacity++;
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = cars.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (cars.FirstOrDefault(x => x.LicensePlate.Equals(licensePlate)) != default)
            {
                return car;
            }
            return null;
        }

        public Car GetMostPowerfulCar()
        {

            Car car = cars.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            if (car != default)
            {
                return car;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
