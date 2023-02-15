using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{

    class Vehicles
    {
        public Vehicles(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalogue
    {
        public Catalogue()
        {
            this.Trucks = new List<Vehicles>();
            this.Cars = new List<Vehicles>();
        }
        public List<Vehicles> Trucks { get; set; }

        public List<Vehicles> Cars { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            Catalogue catalogue = new Catalogue();
            double totalCarHorsePower = 0;
            double totalTrucksHorsePower = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] split = command.Split(' ').ToArray();
                string typeOfVehicle = split[0];
                string model = split[1];
                string color = split[2];
                int horsePower = int.Parse(split[3]);

                if (typeOfVehicle == "truck")
                {
                    Vehicles truck = new Vehicles("Truck", model, color, horsePower);

                    totalTrucksHorsePower += horsePower;
                    catalogue.Trucks.Add(truck);
                }
                else
                {
                    Vehicles car = new Vehicles("Car", model, color, horsePower);

                    totalCarHorsePower += horsePower;
                    catalogue.Cars.Add(car);
                }
            }

            string openCatalogue = String.Empty;


            while ((openCatalogue = Console.ReadLine()) != "Close the Catalogue")
            {
                FindAndPrintVehicleFromCatalogue(catalogue, openCatalogue);
            }

            totalCarHorsePower /= catalogue.Cars.Count;
            totalTrucksHorsePower /= catalogue.Trucks.Count;

            if (catalogue.Cars.Count == 0)
            {
                totalCarHorsePower = 0;
            }
            if (catalogue.Trucks.Count == 0)
            {
                totalTrucksHorsePower = 0;
            }
            

            Console.WriteLine($"Cars have average horsepower of: {totalCarHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {totalTrucksHorsePower:f2}.");
        }

        static void FindAndPrintVehicleFromCatalogue(Catalogue catalogue, string vehicleModel)
        {
            foreach (Vehicles car in catalogue.Cars)
            {
                if (car.Model == vehicleModel)
                {

                    Console.WriteLine($"Type: {car.Type}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HorsePower}");
                }

            }
            foreach (Vehicles truck in catalogue.Trucks)
            {
                if (truck.Model == vehicleModel)
                {

                    Console.WriteLine($"Type: {truck.Type}");
                    Console.WriteLine($"Model: {truck.Model}");
                    Console.WriteLine($"Color: {truck.Color}");
                    Console.WriteLine($"Horsepower: {truck.HorsePower}");
                }
            }
        }
    }
}
