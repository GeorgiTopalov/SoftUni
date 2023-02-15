namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

[TestFixture]

    public class AquariumsTests
    {
        [Test]

        public void TestAquariumClass_Constructor()
        {
            Aquarium aquarium = new Aquarium("Aqua", 35);

            Assert.AreEqual("Aqua", aquarium.Name);
            Assert.AreEqual(35, aquarium.Capacity);
        }

        [Test]

        public void Test_FishCollectionShouldInitialize()
        {
            Aquarium aquarium = new Aquarium("Aqua", 35);

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]

        public void Test_ShouldThrowException_IfNameIsNotValid()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 35);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium("", 35);
            });
        }

        [Test]

        public void Test_ShouldThrowException_IfCapacityIsNotValid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", -1);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", -9999);
            });
        }

        [Test]

        public void Test_ShouldThrowException_IfCapacityIsZero()
        {
            Aquarium aquarium = new Aquarium("Aqua", 0);

            Assert.AreEqual("Aqua", aquarium.Name);
            Assert.AreEqual(0, aquarium.Capacity);
        }

        [Test]

        public void Test_AddFishMethod()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Ivan");
            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]

        public void Test_AddFishMethod_ThrowsException()
        {
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", 0);
                Fish fish = new Fish("Ivan");
                aquarium.Add(fish);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", 1);
                Fish fish = new Fish("Ivan");
                Fish fishTwo = new Fish("Pesho");
                aquarium.Add(fish);
                aquarium.Add(fishTwo);
            });
        }

        [Test]

        public void Test_RemoveFishMethod()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Ivan");
            Fish fishTwo = new Fish("Pesho");

            aquarium.Add(fish);
            aquarium.Add(fishTwo);

            aquarium.RemoveFish("Ivan");
            Assert.AreEqual(1, aquarium.Count);

            aquarium.RemoveFish("Pesho");
            Assert.AreEqual(0, aquarium.Count);
        }

        [TestCase(null)]
        [TestCase("Gosho")]
        [TestCase(" ")]

        public void Test_RemoveFishMethod_ThrowsException(string name)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", 1);
                Fish fish = new Fish("Ivan");
                Fish fishTwo = new Fish("Pesho");
                aquarium.Add(fish);
                aquarium.Add(fishTwo);

                aquarium.RemoveFish(name);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", 1);

                aquarium.RemoveFish("Gosho");
            });
        }

        [Test]

        public void Test_SellFishMethod()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Ivan");
            Fish fishTwo = new Fish("Pesho");

            aquarium.Add(fish);
            aquarium.Add(fishTwo);

            Assert.AreEqual(true, fish.Available);
            aquarium.SellFish("Ivan");
            Assert.AreEqual(false, fish.Available);
        }

        [Test]

        public void Test_SellFishMethod_ReturnsFish()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Ivan");
            Fish fishTwo = new Fish("Pesho");

            aquarium.Add(fish);
            aquarium.Add(fishTwo);
            Fish testFish = aquarium.SellFish("Ivan");

            Assert.AreEqual(fish.Name, testFish.Name);
            Assert.AreEqual(fish.Available, testFish.Available);
        }

        [Test]

        public void Test_SellFishMethod_SameName()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Ivan");
            Fish fishTwo = new Fish("Ivan");

            aquarium.Add(fish);
            aquarium.Add(fishTwo);

            Assert.AreEqual(true, fish.Available);
            aquarium.SellFish("Ivan");
            Assert.AreEqual(false, fish.Available);
            Assert.AreEqual(true, fishTwo.Available);
        }

        [TestCase(null)]
        [TestCase("Gosho")]
        [TestCase(" ")]

        public void Test_SellFishMethod_ThrowsException(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", 1);
                Fish fish = new Fish("Ivan");
                Fish fishTwo = new Fish("Pesho");
                aquarium.Add(fish);
                aquarium.Add(fishTwo);

                aquarium.SellFish(name);
            });
        }

        [Test]


        public void Test_SellFishMethod_ThrowsException_EmptyAqua()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("Aqua", 1);
                aquarium.SellFish("Gosho");
            });
        }

        [Test]

        public void Test_ReportMethod()
        {
            Aquarium aquarium = new Aquarium("Aqua", 2);
            Fish fish = new Fish("Ivan");
            Fish fishTwo = new Fish("Pesho");
            aquarium.Add(fish);
            aquarium.Add(fishTwo);


            Assert.AreEqual("Fish available at Aqua: Ivan, Pesho", aquarium.Report());

        }

        [Test]

        public void TestFishClass_Constructor()
        {
            Fish fish = new Fish("Johny");

            Assert.AreEqual("Johny", fish.Name);
            Assert.AreEqual(true, fish.Available);
        }

        [Test]
        public void TestFishClass_Properties()
        {
            Fish fish = new Fish("Johny");

            fish.Name = "Gosho";

            Assert.AreEqual("Gosho", fish.Name);

            fish.Available = false;

            Assert.AreEqual(false, fish.Available);


        }
    }
}
