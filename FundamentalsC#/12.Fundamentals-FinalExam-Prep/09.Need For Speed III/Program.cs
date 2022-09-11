using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Car
    {
        public Car(string brand, int mileage, int fuel)
        {
            this.Brand = brand;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int carsToObtain = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for(int i = 0; i < carsToObtain; i++)
            {
                string[] CarToAddProps = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string carBrand = CarToAddProps[0];
                int carMileage = int.Parse(CarToAddProps[1]);
                int carFuel = int.Parse(CarToAddProps[2]);
                Car newCar = new Car(carBrand, carMileage, carFuel);
                cars.Add(newCar);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] inputArgs = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string currentCar = inputArgs[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(inputArgs[2]);
                    int fuel = int.Parse(inputArgs[3]);

                    foreach (Car car in cars)
                    {
                        if (car.Brand == currentCar)
                        {
                            if (car.Fuel < fuel)
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                            else
                            {
                                car.Fuel -= fuel;
                                car.Mileage += distance;
                                Console.WriteLine($"{car.Brand} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            }
                            if (car.Mileage >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {car.Brand}!");
                                cars.Remove(car);
                            }
                            break;
                        }
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(inputArgs[2]);

                    foreach (Car car in cars)
                    {
                        if(car.Brand == currentCar)
                        {
                            car.Fuel += fuel;

                            if (car.Fuel > 75)
                            {
                                fuel = 75 + fuel - car.Fuel ;
                                car.Fuel = 75;
                            }
                            Console.WriteLine($"{car.Brand} refueled with {fuel} liters");
                        }
                        break;
                    }
                }
                else
                {
                    int kilometers = int.Parse(inputArgs[2]);

                    foreach (Car car in cars)
                    {
                        if(car.Brand == currentCar)
                        {
                            car.Mileage -= kilometers;

                            if (car.Mileage >= 10000)
                            {
                                Console.WriteLine($"{car.Brand} mileage decreased by {kilometers} kilometers");
                            }
                            else
                            {
                                car.Mileage = 10000;
                            }
                            break;
                        }
                    }
                }

            }
            
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Brand} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
}
