using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base (tankCapacity, fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }
        public override void Drive(double distance, string vehicleType)
        {
            base.Drive(distance, vehicleType);
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }
    }
}
