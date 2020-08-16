namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {

        [Test]

        public void TestIfRobotConstructorWorksProperly()
        {
            string expName = "TestName";
            int expBattery = 50;

            int expMaximumBattery = 50;

            Robot robot = new Robot(expName, expMaximumBattery);

            Assert.AreEqual(expName, robot.Name);
            Assert.AreEqual(expMaximumBattery, robot.MaximumBattery);
            Assert.AreEqual(expBattery, robot.Battery);

        }

        [Test]
        public void TestIfRobotManagerConstructorWorkProperly()
        {
            RobotManager robotManager = new RobotManager(100);

            Assert.AreEqual(100, robotManager.Capacity);
        }

        [Test]

        public void TestIfCapacityThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-200));
        }

        [Test]

        public void TestIfCountWorksProperly()
        {
            RobotManager robotManager = new RobotManager(100);

            robotManager.Add(new Robot("robot1", 20));
            robotManager.Add(new Robot("robot2", 20));

            int expCount = 2;

            int actualCount = robotManager.Count;

            Assert.AreEqual(expCount, actualCount);
        }

        [Test]

        public void TestIfAddMethodAddsPropery()
        {
            RobotManager robotManager = new RobotManager(100);

            Robot robo = new Robot("robot1", 20);

            robotManager.Add(robo);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]

        public void TestIfAddMethodThrowsExceptionWhenRobotExistsAlready()
        {
            RobotManager robotManager = new RobotManager(100);

            Robot robo = new Robot("robot1", 20);
            robotManager.Add(robo);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robo));
        }

        [Test]
        public void TestIfAddMethodThrowsExceptionWhenThereIsNoCapacity()
        {
            RobotManager robotManager = new RobotManager(0);
            Robot robo = new Robot("robot1", 20);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robo));
        }

        [Test]
        public void TestIfRemoveRobotRemovesProperly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robo = new Robot("robot1", 20);

            robotManager.Add(robo);

            robotManager.Remove("robot1");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]

        public void TestIfRemoveRobotThrowsExceptionWhenRobotIsNull()
        {
            RobotManager robotManager = new RobotManager(5);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(null));
        }

        [Test]

        public void TestIfWorkMethodWorksProperly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robo = new Robot("robot1", 20);
            robotManager.Add(robo);

            robotManager.Work("robot1", "test", 10);

            int expectedBattery = 10;

            int actualResult = robo.Battery;

            Assert.AreEqual(expectedBattery, actualResult);
        }

        [Test]

        public void TestIfWorkMethodThrowsExceptionWhenRobotIsNull()
        {
            RobotManager robotManager = new RobotManager(5);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("invalid","invalid",10));
        }

        [Test]
        public void TestIfWorkMethodThrowsExceptionIfRobotBatteryIsNotEnough()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robo = new Robot("robot1", 5);
            robotManager.Add(robo);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("robot1", "job", 100));
        }
        [Test]
        public void TestIfChargeMethodWorksProperly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robo = new Robot("robot1", 20);
            robotManager.Add(robo);
            robotManager.Work("robot1", "job", 10);

            robotManager.Charge("robot1");

            int expBattery = 20;
            int actualBattery = robo.Battery;

            Assert.AreEqual(expBattery, actualBattery);
        }

        [Test]
        public void TestIfChargeThrwosExceptionWhenRobotIsNull()
        {
            RobotManager robotManager = new RobotManager(5);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("invalid"));
        }



    }
}
