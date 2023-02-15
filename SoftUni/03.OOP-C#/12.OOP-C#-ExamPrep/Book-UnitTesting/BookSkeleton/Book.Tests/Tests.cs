namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]

        public void TestBook_Constructor()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");

            Assert.AreEqual(book.BookName, "Lotr");
            Assert.AreEqual(book.Author, "J.R.Tolkien");
        }

        [TestCase("", "asd")]
        [TestCase("asd", "")]
        [TestCase(null, "asd")]
        [TestCase("asd", null)]

        public void TestBook_Constructor(string title, string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(title, author);
            });
        }

        [Test]

        public void TestBook_InstanceShouldInitializeDictionary()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]

        public void TestBook_FootnoteCounter()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            Assert.AreEqual(1, book.FootnoteCount);
            book.AddFootnote(3, "aaasd");
            Assert.AreEqual(2, book.FootnoteCount);

        }
        [TestCase(0, "asd")]
        [TestCase(-5, "asd")]
        [TestCase(11110, "asd")]
        [TestCase(11110, "asd")]
        [TestCase(5, "")]
        [TestCase(5, null)]
        public void TestBook_AddFootnoteMethod(int num, string text)
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(num, text);

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void TestBook_AddFootnoteMethodSameText()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asd");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [TestCase(2, "asdgsd")]
        [TestCase(2, "")]
        [TestCase(2, null)]

        public void TestBook_AddFootnoteMethodThrowsError(int num, string text)
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");


            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(2, "asdlkjg");
            });
        }

        [Test]
        public void TestBook_FindFootnoteMethod()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asda");

            string message1 = "Footnote #2: asd";
            string message2 = "Footnote #3: asda";
            Assert.AreEqual(message1, book.FindFootnote(2));
            Assert.AreEqual(message2, book.FindFootnote(3));
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-2)]
        public void TestBook_FindFootnoteMethodShouldThrow(int num)
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asda");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(num);
            });
        }

        [Test]
        public void TestBook_AlterFootnoteMethod()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asda");

            book.AlterFootnote(2, "Pesho");

            string message1 = "Footnote #2: Pesho";
            string message2 = "Footnote #3: asda";
            Assert.AreEqual(message1, book.FindFootnote(2));
            Assert.AreEqual(message2, book.FindFootnote(3));
            string message3 = "Footnote #3: Pesho";
            book.AlterFootnote(3, "Pesho");
            Assert.AreEqual(message3, book.FindFootnote(3));

        }

        [Test]
        public void TestBook_AlterFootnoteMethodSameText()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asda");

            book.AlterFootnote(2, "asd");

            string message = "Footnote #2: asd";
            Assert.AreEqual(message, book.FindFootnote(2));
        }

        [Test]
        public void TestBook_AlterFootnoteMethodEmptyText()
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asda");

            book.AlterFootnote(2, "");

            string message = "Footnote #2: ";
            Assert.AreEqual(message, book.FindFootnote(2));
        }

        [TestCase(5, "asd")]
        [TestCase(0, "asd")]
        [TestCase(5, null)]
        [TestCase(5, "")]
        [TestCase(-5, "asd")]
        public void TestBook_AlterFootnoteMethodShouldThrow(int num, string text)
        {
            Book book = new Book("Lotr", "J.R.Tolkien");
            book.AddFootnote(2, "asd");
            book.AddFootnote(3, "asda");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(num, text);
            });

        }
    }
}