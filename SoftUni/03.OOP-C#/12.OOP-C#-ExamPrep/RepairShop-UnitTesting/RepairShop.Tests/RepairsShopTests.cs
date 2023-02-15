using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
           [Test]
            public void TestCar_GetValues()
            {
                Car car = new Car("Audi", 0);

                Assert.AreEqual("Audi", car.CarModel);
                Assert.AreEqual(0, car.NumberOfIssues);
                Assert.IsTrue(car.IsFixed);
            }

            [Test]
            public void TestGarage_Getters()
            {
                Garage garage = new Garage("Garage", 5);

                Assert.AreEqual("Garage", garage.Name);
                Assert.AreEqual(5, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [TestCase(null, 5)]
            [TestCase("", 5)]

            public void TestGarage_NameSetterShouldThrowNullExeption_InvalidData(string name, int mechanics)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, mechanics);
                });
            }
            [TestCase("Audi", 0)]
            [TestCase("Audi", -2)]

            public void TestGarage_MechanicsSetterShouldThrowExeption_InvalidData(string name, int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage(name, mechanics);
                });
            }

            [Test]

            public void TestAddCarMethod_ShouldAddCar()
            {
                Garage garage = new Garage("Garage", 5);
                Car car = new Car("Audi", 0);
                Car carTwo = new Car("Mercedes", 0);
                Car carThree = new Car("Nissan", 0);

                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);

                garage.AddCar(carTwo);

                Assert.AreEqual(2, garage.CarsInGarage);

                garage.AddCar(carThree);
                Assert.AreEqual(3, garage.CarsInGarage);

            }

            [Test]

            public void TestAddCarMethod_ShouldThrowException_NoMechanics()
            {
                Garage garage = new Garage("Garage", 1);
                Car car = new Car("Audi", 0);
                Car carTwo = new Car("Mercedes", 0);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(carTwo);
                });
            }

            [Test]

            public void TestFixCar_ShouldSetCarToFixed_True()
            {
                Garage garage = new Garage("Garage", 3);
                Car car = new Car("Audi", 2);
                Car carTwo = new Car("Mercedes", 0);
                garage.AddCar(car);
                garage.AddCar(carTwo);

                garage.FixCar(car.CarModel);

                Assert.IsTrue(car.IsFixed);
            }

            [Test]

            public void TestFixCar_ShouldThrowException_WhenInputIsNull()
            {
                Garage garage = new Garage("Garage", 3);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(null);
                });
            }

            [Test]

            public void TestRemoveFixedCars_ShouldRemoveAllCars_IsFixed()
            {
                Garage garage = new Garage("Garage", 5);
                Car car = new Car("Audi", 2);
                Car carTwo = new Car("Mercedes", 0);
                Car carThree = new Car("Mazda", 0);
                Car carFour = new Car("Moskvich", 0);
                Car carFive = new Car("Volga", 1);

                garage.AddCar(car);
                garage.AddCar(carTwo);
                garage.AddCar(carThree);
                garage.AddCar(carFour);
                garage.AddCar(carFive);

                garage.RemoveFixedCar();

                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]

            public void TestRemoveFixedCars_ShouldThrowException_NoFixedCars()
            {
                Garage garage = new Garage("Garage", 5);
                Car car = new Car("Audi", 2);
                Car carTwo = new Car("Mercedes", 4);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]

            public void TestReport_ShouldReturnProperMessage()
            {
                Garage garage = new Garage("Garage", 5);
                Car car = new Car("Audi", 2);
                Car carTwo = new Car("Mercedes", 0);
                Car carThree = new Car("Mazda", 0);
                Car carFour = new Car("Moskvich", 0);
                Car carFive = new Car("Volga", 1);

                garage.AddCar(car);
                garage.AddCar(carTwo);
                garage.AddCar(carThree);
                garage.AddCar(carFour);
                garage.AddCar(carFive);

                garage.RemoveFixedCar();

                List<string> reportCars = new List<string>();

                reportCars.Add(car.CarModel);
                reportCars.Add(carFive.CarModel);
                string carsNames = string.Join(", ", reportCars);
                var report = $"There are {reportCars.Count} which are not fixed: {carsNames}.";

                Assert.AreEqual(report, garage.Report());
            }
        }
    }
}