namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        //[Test]
        //public void Test_If_EmptyConstructor_Creates_Car_With_FuelAmount_Equal_To_0()
        //{
        //    var car = new Car(); 
        //}

        [TestCase("Sport", "Audi", 10.5, 90)]

        public void Test_If_Car_Properties_Return_Correct_Values(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [TestCase (null, "Audi", 10.5, 90)]
        [TestCase("Sport", null, 10.5, 90)]
        [TestCase("Sport", "Audi", -10.5, 90)]
        [TestCase("Sport", null, 10.5, 90)]
        [TestCase("Sport", "Audi", 10.5, 0)]
        [TestCase("Sport", "Audi", 10.5, -90)]


        public void Test_When_Car_Property_Value_IsInvalid_Should_Throw_Exceptions(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]

        public void Test_Refeul_When_Fuel_Input_Is_Negative_OrZero_Should_Throw_Excetion(double fuelToRefuel)
        {
            var car = new Car("Sport", "Audi", 10.5, 90);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void Test_Refuel_When_Fuel_Capacity_IsLower_Than_Input_Should_Fill_UpTo_Capacity_Value()
        {
            var car = new Car("Sport", "Audi", 10.5, 90);

            double fuelToRefuel = 100;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]

        public void Test_Refuel_When_User_Should_Increase_Fuel_Amount()
        {
            var car = new Car("Sport", "Audi", 10.5, 90);

            double fuelToRefuel = 60;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [Test]

        public void Test_When_Drive_FuelNeeded_More_Than_FuelAmount_Should_Throw_Exception()
        {
            var car = new Car("Sport", "Audi", 10.5, 90);
            double distance = 1000;
            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(fuelNeeded);
            });
        }

        [TestCase(80, 82)]
        [TestCase(900, 0)]

        public void Test_When_Drive_Fuel_Should_Decrese(double distance, double expectedFuelLeft)
        {
            var car = new Car("Sport", "Audi", 10, 90);
            car.Refuel(90);

            car.Drive(distance);

            Assert.AreEqual(expectedFuelLeft, car.FuelAmount);
        }
    }
}