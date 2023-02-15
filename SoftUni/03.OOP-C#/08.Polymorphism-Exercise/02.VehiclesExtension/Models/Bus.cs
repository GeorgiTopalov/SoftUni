using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 1.4;
        }
        public override void Drive(double distance, string vehicleType)
        {
            base.Drive(distance, vehicleType);
        }

        public void DriveEmptyBus(double distance)
        {
            double fuelNeeded = (this.FuelConsumption - 1.4) * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }
    }
}
