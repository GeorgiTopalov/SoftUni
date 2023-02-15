using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]

            public void TestWeapons_ConstructorShouldSetProperValues()
            {
                Weapon weapon = new Weapon("Shmaizer", 2.5, 11);

                Assert.AreEqual("Shmaizer", weapon.Name);
                Assert.AreEqual(2.5, weapon.Price);
                Assert.AreEqual(11, weapon.DestructionLevel);
                Assert.True(weapon.IsNuclear);
            }

            [Test]

            public void TestWeapons_PriceShouldThrowException_WhenNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Shmaizer", - 2.5, 11);
                });
            }

            [Test]

            public void TestWeapon_IncreaseDestructionLevel_Method_ShouldIncrease_DestructionLevel()
            {
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(8, weapon.DestructionLevel);

            }

            [Test]

            public void TestPlanet_ShouldInitialize_Constructor()
            {
                Planet planet = new Planet("Earth", 250);

                Assert.AreEqual(0, planet.Weapons.Count);
                Assert.AreEqual("Earth", planet.Name);
                Assert.AreEqual(250, planet.Budget);
            }

            [TestCase(null, 200)]
            [TestCase("", 200)]
            [TestCase("Earth", -200)]

            public void TestPlanet_Validations_Exceptions(string name, double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, budget);
                });
            }

            [Test]

            public void TestPlanet_ProfitMethod_ShouldIncreaseBudget()
            {
                Planet planet = new Planet("Earth", 250);

                planet.Profit(30);

                Assert.AreEqual(280, planet.Budget);
            }

            [Test]
            public void TestPlanet_SpendFundsMethod_ShouldDecreaseBudget()
            {
                Planet planet = new Planet("Earth", 250);
                planet.SpendFunds(30);

                Assert.AreEqual(220,planet.Budget);
            }

            [Test]

            public void TestPlanet_AddWeapon_ShouldAddWeaponToList()
            {
                Planet planet = new Planet("Earth", 250);
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                Weapon weaponTwo = new Weapon("Patlak", 1.5, 3);

                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.AreEqual(weapon, planet.Weapons.FirstOrDefault());

                planet.AddWeapon(weaponTwo);

                Assert.AreEqual(2, planet.Weapons.Count);
                Assert.AreEqual(9, planet.MilitaryPowerRatio);
            }

            [Test]

            public void TestPlanet_SpendFunds_ShouldThrowException_IfAmountTooHigh()
            {
                Planet planet = new Planet("Earth", 250);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(251);
                });
            }

            [Test]

            public void TestPlanet_AddWeapon_ShouldThrowException_IfAlreadyAdded()
            {
                Planet planet = new Planet("Earth", 250);
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                Weapon weaponTwo = new Weapon("Shmaizer", 3.5, 5);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weaponTwo);
                });
            }

            [Test]

            public void Test_RemoveWeapon_ShouldRemoveWep_FromCollection()
            {
                Planet planet = new Planet("Earth", 250);
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                Weapon weaponTwo = new Weapon("Patlak", 1.5, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weaponTwo);

                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.AreEqual(weaponTwo, planet.Weapons.FirstOrDefault());
            }

            [Test]

            public void Test_UpgradeWeapon_ShouldIncrease_DestructPower()
            {
                Planet planet = new Planet("Earth", 250);
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(7, planet.Weapons.FirstOrDefault(x => x.Name == weapon.Name).DestructionLevel);
            }

            [Test]

            public void Test_UpgradeWeapon_ShouldThrowException_IfWeaponDoesntExist()
            {
                Planet planet = new Planet("Earth", 250);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Shmaizer");
                });
            }

            [Test]

            public void Test_DestructOpponentDestructOpponent_ShouldReturnMessage()
            {
                Planet planet = new Planet("Earth", 250);
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                planet.AddWeapon(weapon);
                Planet planetTwo = new Planet("Mars", 140);

                Assert.AreEqual($"{planetTwo.Name} is destructed!", planet.DestructOpponent(planetTwo));
            }

            [Test]
            public void Test_DestructOpponentDestructOpponent_ShouldThrowException_IfOpponentTooStrong()
            {
                Planet planet = new Planet("Earth", 250);
                Weapon weapon = new Weapon("Shmaizer", 2.5, 6);
                Planet planetTwo = new Planet("Mars", 140);
                planetTwo.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planetTwo);
                });
            }
        }
    }
}
