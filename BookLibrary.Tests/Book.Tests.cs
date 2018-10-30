namespace BookLibrary.Tests
{
    using System;
    using System.Globalization;

    using NUnit.Framework;

    [TestFixture]
    public class BookTests
    {
        public static CultureInfo cultureInfo = new CultureInfo("de-DE");

        [TestCase("t", ExpectedResult = "Book record: C# in Depth")]
        [TestCase("a", ExpectedResult = "Book record: Jon Skeet, C# in Depth")]
        [TestCase("g", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 2019")]
        [TestCase("p", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 2019, \"Manning\"")]
        [TestCase("s", ExpectedResult = "Book record: C# in Depth, 2019, \"Manning\"")]
        [TestCase("e", ExpectedResult = "Book record: Jon Skeet, C# in Depth, edition 4, 900p., 2019")]
        [TestCase("unsupported", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 2019, \"Manning\", edition 4, 900p., $40.00")]
        public string ToString_TestDifferentFormats_ReturnCorrectResult(string format)
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
            return book.ToString(format, null);
        }

        [Test]
        public void ToString_TestDifferentCultures_ReturnDifferentResult()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
            Assert.AreNotEqual(book.ToString("u", new CultureInfo("de-DE")), book.ToString("u", new CultureInfo("en-US")));
        }
    }
}
