using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            Car car = new Car(carTankCapacity, carFuelQuantity, carFuelConsumption);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Truck truck = new Truck(truckTankCapacity, truckFuelQuantity, truckFuelConsumption);

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busTankCapacity, busFuelQuantity, busFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (command[0] == "Drive")
                    {
                        double distance = double.Parse(command[2]);

                        if (command[1] == "Car")
                        {
                            car.Drive(distance, "Car");
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Drive(distance, "Truck");
                        }
                        else
                        {
                            bus.Drive(distance, "Bus");
                        }

                    }
                    else if (command[0] == "Refuel")
                    {
                        double liters = double.Parse(command[2]);

                        if (command[1] == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else
                        {
                            bus.Refuel(liters);
                        }
                    }
                    else
                    {
                        double distance = double.Parse(command[2]);
                        bus.DriveEmptyBus(distance);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}"); 
                }
               

            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
