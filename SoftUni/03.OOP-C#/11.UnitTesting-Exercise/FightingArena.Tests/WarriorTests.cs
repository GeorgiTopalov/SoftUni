namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {
        [Test]

        public void Test_PropertyGetters_Should_Return_Proper_Values()
        {
            string name = "Petko";
            int damage = 10;
            int hp = 50;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase("", 10, 50)]
        [TestCase(" ", 10, 50)]
        [TestCase(null, 10, 50)]
        [TestCase("Petko", 0, 50)]
        [TestCase("Petko", -1, 50)]
        [TestCase("Petko", 10, -50)]

        public void Test_Invalid_PropertySetters_Should_Throw_Exceptions(string name, int damage, int hp)
        {

            Assert.Throws<ArgumentException>(()=>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [TestCaseSource("TestCaseAttackData")]

        public void Test_When_Attack_Should_Remove_HP_From_Attacked_Target(Warrior attackingWar, Warrior attackedWar)
        {
            int currentDefWarHP = attackedWar.HP;
            int currentAttWarHP = attackingWar.HP;
            attackingWar.Attack(attackedWar);

            if (attackedWar.HP < attackingWar.Damage)
            {
                Assert.AreEqual(0, attackedWar.HP);
            }
            else
            {
                Assert.AreEqual(currentDefWarHP - attackingWar.Damage, attackedWar.HP);
            }

            Assert.AreEqual(currentAttWarHP - attackedWar.Damage, attackingWar.HP);
        }

            public static IEnumerable<TestCaseData> TestCaseAttackData()
        {
            yield return new TestCaseData(
                
                new Warrior("Ivan", 20, 90),
                new Warrior ("Petkan", 30, 90)
                ); 
            yield return new TestCaseData(

                 new Warrior("Ivan", 40, 90),
                 new Warrior("Petkan", 30, 40)
                 );
        }

        [TestCaseSource("TestCaseAttackExceptionsData")]

        public void Test_When_Attack_isInvalid_Should_Throw_Exception(Warrior attackingWar, Warrior attackedWar)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                attackingWar.Attack(attackedWar);
            });
        }
        public static IEnumerable<TestCaseData> TestCaseAttackExceptionsData()
        {
            yield return new TestCaseData(

                new Warrior("Ivan", 20, 29),
                new Warrior("Petkan", 30, 90)
                );
            yield return new TestCaseData(

                 new Warrior("Ivan", 40, 90),
                 new Warrior("Petkan", 30, 25)
                 ); 
            yield return new TestCaseData(

                  new Warrior("Ivan", 40, 35),
                  new Warrior("Petkan", 50, 90)
                  );
        }

    }
}