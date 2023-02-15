namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase (new int[0])]
        [TestCase (new int[] {1, 2 ,3 ,4})]

        public void Test_If_Constructor_Data_Is_Added_To_Database_Correct(int[] parameters)
        {
            Database database = new Database(parameters);

            Assert.AreEqual(parameters.Length, database.Count);
        }
        
        [Test]
        public void Test_Add_Method_Position_And_When_Data_Count_Becomes_17_Should_Throw_Exception()
        {
            int[] arrayOfNums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

            Database database = new Database(arrayOfNums);
            int numberToAdd = 16;
            database.Add(numberToAdd);
            int[] arrayToTest = database.Fetch();

            Assert.AreEqual(16, arrayToTest.Length);
            Assert.AreEqual(numberToAdd, arrayToTest[arrayToTest.Length - 1]);

            Assert.Throws<InvalidOperationException>(()=>
            {
                database.Add(17);
            });
        }

        [Test]
        public void Test_Remove_Method_Position_And_Should_Throw_Exception_When_Data_Is_Empty()
        {
            int[] arrayOfNums = new int[] { 1, 2};

            Database database = new Database(arrayOfNums);
            database.Remove();

            int[] arrayToTest = database.Fetch();
            bool numIsRemoved = true;

            if (arrayToTest.Contains(2))
            {
                numIsRemoved = false;
            }
            Assert.IsTrue(numIsRemoved);

            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

    }
}
