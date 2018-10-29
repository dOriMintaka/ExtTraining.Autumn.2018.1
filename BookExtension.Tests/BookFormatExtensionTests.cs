namespace BookExtension.Tests
{
    using BookLibrary;

    using NUnit.Framework;

    [TestFixture]
    public class BookFormatExtensionTests
    {
        [Test]
        public void Format_CorrectInput_CorrectResult()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);

            // testing extension
            Assert.AreEqual("Author: Jon Skeet\nTitle: C# in Depth, edition 4\nYear: 2019", string.Format(new BookFormatExtension(), "{0:c}", book));

            // if format specifier is one of the built-in formats use built-in
            Assert.AreEqual("Book record: C# in Depth", string.Format(new BookFormatExtension(), "{0:t}", book));
        }
    }
}
