namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]

        public void TestPresentClass_Constructor()
        {
            Present present = new Present("Toy", 2.2);

            Assert.IsNotNull(present);
            Assert.AreEqual("Toy", present.Name);
            Assert.AreEqual(2.2, present.Magic);
        }

        [Test]

        public void TestPresentClass_Setters()
        {
            Present present = new Present("Toy", 2.2);
            present.Magic = 2.1;
            present.Name = "Toy2";

            Assert.AreEqual("Toy2", present.Name);
            Assert.AreEqual(2.1, present.Magic);
        }

        [Test]

        public void TestBagClass_Constructor()
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag);
            
        }

        [Test]
        public void TestCreate_Method()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy", 2.6);

            Assert.AreEqual($"Successfully added present {present.Name}.", bag.Create(present));
            Assert.AreEqual($"Successfully added present {present2.Name}.", bag.Create(present2));

        }

        [Test]
        public void TestCreate_Method_AddsToBag()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 2.2);
            bag.Create(present);
            Assert.AreEqual(1, bag.GetPresents().Count);
            Assert.IsNotNull(bag.GetPresent("Toy"));
            Assert.AreEqual(present, bag.GetPresent("Toy"));

        }



        [Test]
        public void TestCreate_NullExceptions()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });


        }

        [Test]
        public void TestCreate_AlreadyExistsExceptions()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy2", 2.4);
            Present present2 = new Present("Toy", 2.6);

            bag.Create(present);
            bag.Create(present2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void TestCreate_SameName()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 2.4);
            Present present2 = new Present("Toy", 2.6);
            bag.Create(present);
            bag.Create(present2);

            Assert.IsTrue(bag.Remove(present));
            Assert.AreEqual(present2, bag.GetPresent("Toy"));
        }

        [Test]
        public void TestGetPresent_Method()
        {
            Bag bag = new Bag();

            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.4);
            bag.Create(present);
            bag.Create(present2);

            Assert.IsNotNull(bag.GetPresent("Toy"));
            Assert.AreEqual(2.2, bag.GetPresent("Toy").Magic);
            Assert.AreEqual(2.4, bag.GetPresent("Toy2").Magic);
            Assert.AreEqual(present2, bag.GetPresent("Toy2"));
            Assert.AreEqual(present, bag.GetPresent("Toy"));
        }

        [Test]
        public void TestGetPresent_Method_Default()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.4);
            bag.Create(present);
            bag.Create(present2);
            string name = "Toy3";
            
            Assert.AreEqual(default , bag.GetPresent(name));
            Assert.IsNull(bag.GetPresent(name));
            
        }

        [Test]
        public void TestGetPresent_Method_SameName()
        {
            Bag bag = new Bag();
            string name = "Toy";
            Present present = new Present(name, 2.2);
            Present present2 = new Present(name, 2.4);
            bag.Create(present);
            bag.Create(present2);

            Assert.AreEqual(present, bag.GetPresent(name));

        }

        [Test]
        public void TestRemovePresent_Method()
        {
            Bag bag = new Bag();

            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.4);
            bag.Create(present);
            bag.Create(present2);

            bag.Remove(present);
            Assert.AreEqual(1, bag.GetPresents().Count);
            Assert.AreEqual(true, bag.Remove(present2));

        }

        [Test]
        public void TestRemovePresent_Method_False()
        {
            Bag bag = new Bag();

            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.4);
            Present present3 = new Present("Toy3", 12.4);
            bag.Create(present);
            bag.Create(present2);

            Assert.AreEqual(false, bag.Remove(present3));

        }

        [Test]
        public void TestRemovePresent_Method_FalseOnEmptyBag()
        {
            Bag bag = new Bag();

            Present present = new Present("Toy", 2.2);
           

            Assert.AreEqual(false, bag.Remove(present));

        }
       

        [Test]

        public void TestGetPresentWithLeastMagic_Method()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.4);
            Present present3 = new Present("Toy2", 0.4);

            bag.Create(present);
            bag.Create(present2);

            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
            bag.Create(present3);
            Assert.AreEqual(present3, bag.GetPresentWithLeastMagic());
        }

        [Test]

        public void TestGetPresentWithLeastMagic_Method_SameMagic()
        {
            Bag bag = new Bag();
            
            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.2);
            Present present3 = new Present("Toy3", 2.2);

            bag.Create(present);
            bag.Create(present2);

            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
            bag.Create(present3);
            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
        }


        [Test]
        public void TestGetPresents_Method()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 2.2);
            Present present2 = new Present("Toy2", 2.4);
            bag.Create(present);
            bag.Create(present2);

            Assert.IsNotNull(bag.GetPresents());
            Assert.AreEqual(2, bag.GetPresents().Count);
        }

        [Test]
        public void TestGetPresents_Method_WithNoPresents()
        {
            Bag bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }


    }
}
