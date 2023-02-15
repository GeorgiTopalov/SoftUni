using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        string make;
        string model;
        string licensePlate;
        int horsePower;
        double weight;

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.make = make;
            this.model = model;
            this.licensePlate = licensePlate;
            this.horsePower = horsePower;
            this.weight = weight;
        }

        public string Make { get { return this.make; } set { this.make = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public string LicensePlate { get { return this.licensePlate; } set { this.licensePlate = value; } }
        public int HorsePower { get { return this.horsePower; } set { this.horsePower = value; } }
        public double Weight { get { return this.weight; } set { this.weight = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"License Plate: {this.LicensePlate}");
            sb.AppendLine($"Horse Power: {this.HorsePower}");
            sb.AppendLine($"Weight: {this.Weight}");

            return sb.ToString().TrimEnd();
        }
    }
}
