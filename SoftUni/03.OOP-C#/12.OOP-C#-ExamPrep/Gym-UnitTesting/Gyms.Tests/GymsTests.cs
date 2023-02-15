using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]

        public void TestAthletes_Constructor()
        {
            Athlete newAthlete = new Athlete("John");

            Assert.AreEqual("John", newAthlete.FullName);
            Assert.IsFalse(newAthlete.IsInjured);

            newAthlete.IsInjured = true;

            Assert.IsTrue(newAthlete.IsInjured);

            newAthlete.FullName = "Josy";

            Assert.AreEqual("Josy", newAthlete.FullName);
        }

        [Test]

        public void TestGym_Constructor()
        {
            Gym gym = new Gym("Pulse", 50);

            Assert.AreEqual(gym.Name, "Pulse");
            Assert.AreEqual(gym.Capacity, 50);
            Assert.AreEqual(gym.Count, 0);
        }

        [TestCase(null)]
        [TestCase("")]


        public void TestGym_Constructor_NameException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 50);
            });
        }

        [Test]


        public void TestGym_Constructor_CapacityException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Pesho", -50);
            });
        }

        [Test]

        public void TestGym_Constructor_CapacityZero()
        {
            Gym gym = new Gym("Pesho", 0);

            Assert.AreEqual(gym.Capacity, 0);
        }

        [Test]

        public void TestAddAthlete_Method()
        {
            Gym gym = new Gym("Pesho", 10);
            Athlete newAthlete = new Athlete("John");
            Athlete secondAthlete = new Athlete("Qna");

            gym.AddAthlete(newAthlete);
            Assert.AreEqual(1, gym.Count);
            gym.AddAthlete(secondAthlete);
            Assert.AreEqual(2, gym.Count);
        }

        [Test]

        public void TestAddAthlete_MethodThrowsError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Gym gym = new Gym("Pesho", 0);
                Athlete newAthlete = new Athlete("John");
                gym.AddAthlete(newAthlete);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                Gym gym = new Gym("Pesho", 1);
                Athlete newAthlete = new Athlete("John");
                Athlete secondAthlete = new Athlete("Qna");

                gym.AddAthlete(newAthlete);
                gym.AddAthlete(secondAthlete);

            });
        }

        [Test]

        public void TestRemoveAthlete_Method()
        {
            Gym gym = new Gym("Pesho", 10);
            Athlete newAthlete = new Athlete("John");
            Athlete secondAthlete = new Athlete("Qna");

            gym.AddAthlete(newAthlete);
            gym.AddAthlete(secondAthlete);

            gym.RemoveAthlete("John");

            Assert.AreEqual(1, gym.Count);

            gym.RemoveAthlete("Qna");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]

        public void TestRemoveAthlete_MethodThrowsError()
        {
            Gym gym = new Gym("Pesho", 2);
            Athlete newAthlete = new Athlete("John");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Ivan");
            });
            gym.AddAthlete(newAthlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Ivan");
            });
        }

        [Test]

        public void TestInjureAthlete_Method()
        {
            Gym gym = new Gym("Pesho", 2);
            Athlete newAthlete = new Athlete("John");
            Athlete newAthlete2 = new Athlete("Petka");

            gym.AddAthlete(newAthlete);
            gym.AddAthlete(newAthlete2);

            Assert.AreEqual(newAthlete, gym.InjureAthlete("John"));

            gym.InjureAthlete("Petka");
            Assert.IsTrue(newAthlete2.IsInjured);
        }

        [Test]

        public void TestInjureAthlete_MethodThrowsError()
        {
            Gym gym = new Gym("Pesho", 2);
            Athlete newAthlete = new Athlete("John");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Ivan");
            });
            gym.AddAthlete(newAthlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Ivan");
            });
        }

        [Test]

        public void TestReport_Method()
        {
            Gym gym = new Gym("Pesho", 2);
            Athlete newAthlete = new Athlete("John");
            Athlete newAthlete2 = new Athlete("Petka");
            gym.AddAthlete(newAthlete);
            gym.AddAthlete(newAthlete2);

            string message = $"Active athletes at Pesho: John, Petka";

            Assert.AreEqual(message, gym.Report());

            gym.InjureAthlete("John");

            message = $"Active athletes at Pesho: Petka";

            Assert.AreEqual(message, gym.Report());

        }
    }
}
