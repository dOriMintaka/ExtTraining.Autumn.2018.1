namespace BookExtension.Tests
{
    using BookLibrary;

    using NUnit.Framework;

    [TestFixture]
    public class BookFormatExtensionTests
    {
        [Test]
        public void test()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
            Assert.AreEqual("Author: Jon Skeet\nTitle: C# in Depth, edition 4\nYear: 2019", string.Format(new BookFormatExtension(), "{0:c}", book));
            Assert.AreEqual("Book record: C# in Depth", string.Format(new BookFormatExtension(), "{0:t}", book));
        }
    }
}
