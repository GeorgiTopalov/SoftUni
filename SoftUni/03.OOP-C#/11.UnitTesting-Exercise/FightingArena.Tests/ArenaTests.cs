namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]

        public void Text_Constructor_Should_Initialize_Warriors()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Count, arena.Warriors.Count);
            Assert.AreEqual(0, arena.Count);
        }


        [TestCaseSource("TestCaseEnrollData")]

        public void Test_When_Enroll_Should_Add_Warrior_To_Warriors(Warrior[] warriors, int EnrollCount)
        {
            Arena arena = new Arena();

            for (int i = 0; i < EnrollCount; i++)
            {
                arena.Enroll(warriors[i]);
            }
            Assert.True(arena.Warriors.Any(x => x.Name == "Ivan"));
            Assert.AreEqual(warriors.Length, arena.Count);

        }
        public static IEnumerable<TestCaseData> TestCaseEnrollData()
        {
            yield return new TestCaseData(
               new Warrior[]
            {
                new Warrior("Ivan", 20, 120),
                new Warrior("Petkan", 20, 90),
                new Warrior("Kaloqn", 24, 100),
            },
                3);
        }
        [TestCaseSource("TestCaseEnrollExceptionData")]

        public void Test_When_Enroll_SameName_Warrior_Should_Throw_Exception(Warrior[] warriors, int EnrollCount)
        {
            Arena arena = new Arena();

            for (int i = 0; i < EnrollCount; i++)
            {
                arena.Enroll(warriors[i]);
            }

            Warrior warrior = new Warrior("Ivan", 20, 100);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
        public static IEnumerable<TestCaseData> TestCaseEnrollExceptionData()
        {
            yield return new TestCaseData(
               new Warrior[]
            {
                new Warrior("Ivan", 20, 120),
                new Warrior("Petkan", 20, 90),
                new Warrior("Kaloqn", 24, 100),
            },
                3);
        }

        [TestCaseSource("TestCaseFightExceptionsData")]

        public void Test_When_FightName_IsNull_Should_Throw_Exception(Warrior[] warriors, string attackerName, string defenderName)
        {
            Arena arena = new Arena();
            arena.Enroll(warriors[0]);
            arena.Enroll(warriors[1]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, defenderName);
            });
        }
        public static IEnumerable<TestCaseData> TestCaseFightExceptionsData()
        {
            yield return new TestCaseData(
                new Warrior[]
                {
                new Warrior("Ivan", 20, 29),
                new Warrior("Petkan", 30, 90)
                },
                "Ivan",
                null);
            yield return new TestCaseData(
                new Warrior[]
                {
                new Warrior("Ivan", 20, 29),
                new Warrior("Petkan", 30, 90)
                },
                null,
                "Petkan");
            yield return new TestCaseData(
                new Warrior[]
                {
                new Warrior("Ivan", 20, 29),
                new Warrior("Petkan", 30, 90)
                },
                "Gosho",
                "Petkan");
            yield return new TestCaseData(
                new Warrior[]
                {
                new Warrior("Ivan", 20, 29),
                new Warrior("Petkan", 30, 90)
                },
                "Ivan",
                "Gosho");
        }

        [Test]
        public void Test_Fight_Should_Call_Attack_Method()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Ivan", 80, 120);
            Warrior defender = new Warrior("Petkan", 30, 70);

            arena.Enroll(defender);
            arena.Enroll(attacker);

            arena.Fight("Ivan", "Petkan");

            Assert.AreEqual(90, attacker.HP);
            Assert.AreEqual(0, defender.HP);

        }
    }
}
