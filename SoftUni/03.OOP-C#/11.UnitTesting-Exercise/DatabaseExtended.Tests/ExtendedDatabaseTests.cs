namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseConstructorData")]

        [Test]

        public void Test_If_Constructor_Data_Is_Added_To_Database_Correct(Person[] people, int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                    new Person(21356, "Asen"),
                    new Person(6542321, "Jon"),
                },
                4);
            yield return new TestCaseData(
                 new Person[]
                 {
                 },
                 0);
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                    new Person(21356, "Asen"),
                    new Person(6542321, "Jon"),
                    new Person(6543321, "Petkan"),
                    new Person(6543421, "Aslan"),
                    new Person(6546321, "Krakan"),
                    new Person(6547321, "Varan"),
                    new Person(6548321, "Banan"),
                    new Person(6594321, "Stoyan"),
                    new Person(6543121, "Anton"),
                    new Person(6543221, "Kaloqn"),
                    new Person(6543231, "Jimmy"),
                    new Person(6543241, "Tosho"),
                    new Person(6543251, "Viktor"),
                    new Person(6549251, "Pepi"),
                },
                16);
        }


        [TestCaseSource("TestCaseAddData")]

        [Test]
        public void Test_If_Add_Method_Adds_People_Correct(Person[] people, Person[] peopleToAdd, int expectedCount)
        {


            Database database = new Database(people);
            foreach (Person person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);


        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                    new Person(21356, "Asen"),
                    new Person(6542321, "Jon"),
                },
                new Person[]
                {
                    new Person(6543321, "Petkan"),
                    new Person(6543421, "Aslan"),
                    new Person(6546321, "Krakan"),
                },
                7);
            yield return new TestCaseData(
                 new Person[]
                 {
                 },
                 new Person[]
                {
                    new Person(6543321, "Petkan"),
                    new Person(6543421, "Aslan"),
                    new Person(6546321, "Krakan"),
                },
                 3);
        }


        [TestCaseSource("TestCaseAddExceptionData")]

        public void Test_When_Add_Above16_People_Should_Throw_Exception(Person[] people, Person newPerson)
        {
            Database database = new Database(people);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(newPerson));
        }
        public static IEnumerable<TestCaseData> TestCaseAddExceptionData()
        {

            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                    new Person(21356, "Asen"),
                    new Person(6542321, "Jon"),
                    new Person(6543321, "Petkan"),
                    new Person(6543421, "Aslan"),
                    new Person(6546321, "Krakan"),
                    new Person(6547321, "Varan"),
                    new Person(6548321, "Banan"),
                    new Person(6594321, "Stoyan"),
                    new Person(6543121, "Anton"),
                    new Person(6543221, "Kaloqn"),
                    new Person(6543231, "Jimmy"),
                    new Person(6543241, "Tosho"),
                    new Person(6543251, "Viktor"),
                    new Person(6549251, "Pepi"),
                },
                new Person(11111, "Vasil"));
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                },
                new Person(11111, "Gosho"));
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                },
                new Person(654321, "Tosho"));
        }

        [TestCaseSource("TestCaseRemoveData")]

        public void Test_If_Remove_Method_Removes_Correct(Person[] people, int removeCount, int expectedCount)
        {
            Database database = new Database(people);

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount,database.Count);
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                    new Person(21356, "Asen"),
                    new Person(6542321, "Jon"),
                },
                3,
                1);
            yield return new TestCaseData(
                 new Person[]
                 {
                 },
                 0,
                 0);
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(654321, "Gosho"),
                    new Person(21356, "Asen"),
                    new Person(6542321, "Jon"),
                },
                4,
                0);
        }

        [TestCaseSource("TestCaseRemoveExceptionData")]

        public void Test_When_Trying_To_Remove_From_Empty_Collection_Should_Throw_Exception(Person[] people, int removeCount)
        {
            Database database = new Database(people);

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(()
                => database.Remove());
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveExceptionData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(113456, "Gosho"),
                },
                2);
        }


        [TestCaseSource("TestCaseFindByUsernameExceptionsData")]

        public void Test_When_Wrong_Arguments_Are_Asked_In_FindByName_Method_Should_Throw_Exception(Person[] people, string wrongName, string noData)
        {
            Database database = new Database(people);

            Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername(wrongName));
            Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(noData));
        }

        public static IEnumerable<TestCaseData> TestCaseFindByUsernameExceptionsData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(113456, "Gosho"),
                },
                "Vasil",
                null
                );
        }


        [TestCaseSource("TestCaseFindByIdExceptionsData")]

        public void Test_When_Wrong_Arguments_Are_Asked_In_FindById_Method_Should_Throw_Exception(Person[] people, int wrongId, int negativeId)
        {
            Database database = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(negativeId));
            Assert.Throws<InvalidOperationException>(()
                => database.FindById(wrongId));
        }

        public static IEnumerable<TestCaseData> TestCaseFindByIdExceptionsData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(113456, "Gosho"),
                },
                133456,
                -11345
                );
        }


        [TestCaseSource("TestCaseFindByUsernameData")]

        public void Test_If_FindByName_Method_Returns_The_Correct_Person(Person[] people, string name, Person personToFind)
        {
            Database database = new Database(people);

            Assert.AreEqual(personToFind.Id, database.FindByUsername(name).Id);
            Assert.AreEqual(personToFind.UserName, database.FindByUsername(name).UserName);

        }
        public static IEnumerable<TestCaseData> TestCaseFindByUsernameData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(113456, "Gosho"),
                },
                "Gosho",
                new Person(113456, "Gosho")
                );
        }

        [TestCaseSource("TestCaseFindByIdData")]

        public void Test_If_FindId_Method_Returns_The_Correct_Person(Person[] people, long id, Person personToFind)
        {
            Database database = new Database(people);

            Assert.AreEqual(personToFind.Id, database.FindById(id).Id);
            Assert.AreEqual(personToFind.UserName, database.FindById(id).UserName);

        }

        public static IEnumerable<TestCaseData> TestCaseFindByIdData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(123456, "Pesho"),
                    new Person(113456, "Gosho"),
                },
                123456,
                new Person(123456, "Pesho")
                );
        }


    }
}