using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base (fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }
        public override void Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }
    }
}
