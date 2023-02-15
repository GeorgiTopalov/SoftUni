namespace Robots.Tests
{
    using NUnit.Framework;
    using Robots;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        public object Robot { get; private set; }

        [Test]

        public void TestRobot_GettersShouldReturn_ProperValues()
        {
            Robot robot = new Robot("Pesho", 50);

            Assert.AreEqual("Pesho", robot.Name);
            Assert.AreEqual(50, robot.Battery);
            Assert.AreEqual(50, robot.MaximumBattery);
        }

        [Test]

        public void TestRobotManager_ConstructorShouldInitialize_ProperValues()
        {
            RobotManager robotManager = new RobotManager(5);

            Assert.AreEqual(5, robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);

        }

        [Test]

        public void TestRobotManager_CapacityException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-5);
            });
        }

        [Test]

        public void TestRobotManager_AddRobot_ShouldAddToCollection()
        {
            Robot robot = new Robot("Pesho", 50);
            Robot robotTwo = new Robot("Gosho", 45);

            RobotManager robotManager = new RobotManager(5);

            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
            robotManager.Add(robotTwo);
            Assert.AreEqual(2, robotManager.Count);

        }

        [Test]

        public void TestRobotManager_AddRobot_ShouldThrowException_InvalidData()
        {
            Robot robot = new Robot("Pesho", 50);
            Robot robotTwo = new Robot("Gosho", 45);
            Robot robotThree = new Robot("Pesho", 50);
            Robot robotFour = new Robot("MK-15", 50);
            Robot robotFive = new Robot("C3PO", 50);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robotThree);
            });

            robotManager.Add(robotTwo);
            robotManager.Add(robotFour);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robotFive);

            });
        }


        [Test]

        public void TestRobotManager_RemoveMethod()
        {
            Robot robot = new Robot("Pesho", 50);
            Robot robotTwo = new Robot("Gosho", 45);
            Robot robotThree = new Robot("MK-15", 50);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);
            robotManager.Add(robotTwo);
            robotManager.Add(robotThree);


            robotManager.Remove("Gosho");
            Assert.AreEqual(2, robotManager.Count);

            robotManager.Remove("MK-15");
            Assert.AreEqual(1, robotManager.Count);

        }

        [Test]

        public void TestRobotmanager_RemoveMethod_Exception()
        {
            Robot robot = new Robot("Pesho", 50);
            Robot robotTwo = new Robot("Gosho", 45);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);
            robotManager.Add(robotTwo);


            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("ASDFG");
            });
        }

        [Test]

        public void TestRobotManager_WorkMethod()
        {
            Robot robot = new Robot("Pesho", 50);
            Robot robotTwo = new Robot("Gosho", 45);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);
            robotManager.Add(robotTwo);

            robotManager.Work("Pesho", "Clean", 15);
            Assert.AreEqual(35, robot.Battery);

            robotManager.Work("Pesho", "Clean", 15);
            Assert.AreEqual(20, robot.Battery);

            robotManager.Work("Gosho", "Cook", 25);
            Assert.AreEqual(20, robotTwo.Battery);
        }

        [TestCase("Gosho", "Clean", 35)]
        [TestCase("R2D2", "Clean", 10)]

        public void TestRobotManager_WorkMethod_Exceptions(string name, string job, int battery)
        {
            Robot robot = new Robot("Gosho", 30);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(name, job, battery);
            });
        }

        [Test]

        public void Test_ChargeMethod()
        {
            Robot robot = new Robot("Gosho", 50);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);

            robotManager.Work("Gosho", "Hack", 25);

            robotManager.Charge("Gosho");

            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }

        [Test]

        public void Test_ChargeMethod_Exception()
        {
            Robot robot = new Robot("Gosho", 50);

            RobotManager robotManager = new RobotManager(3);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("R2D2");
            });
        }

    }
}
