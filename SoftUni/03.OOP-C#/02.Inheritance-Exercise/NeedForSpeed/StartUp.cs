namespace NeedForSpeed
{
    using System;
    
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(160, 75);
            Car car = new Car(210, 75);
            FamilyCar familyCar = new FamilyCar(120, 75);
            SportCar sportCar = new SportCar(300, 120);

            Console.WriteLine($"{car.Fuel}");
            car.Drive(10);
            Console.WriteLine($"{car.Fuel}");
            Console.WriteLine();
            Console.WriteLine($"{vehicle.Fuel}");
            vehicle.Drive(10);
            Console.WriteLine($"{vehicle.Fuel}");
            Console.WriteLine();
            Console.WriteLine($"{familyCar.Fuel}");
            familyCar.Drive(10);
            Console.WriteLine($"{familyCar.Fuel}"); Console.WriteLine();
            Console.WriteLine($"{sportCar.Fuel}");
            sportCar.Drive(10);
            Console.WriteLine($"{sportCar.Fuel}");

        }
    }
}
