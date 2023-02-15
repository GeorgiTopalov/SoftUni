using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }      
        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }

        public virtual void Drive(double distance, string vehicleType)
        {
            double fuelNeeded = this.FuelConsumption * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                Console.WriteLine($"{vehicleType} travelled {distance} km");
                this.FuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine($"{vehicleType} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }
    }
}
