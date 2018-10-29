using System;

namespace BookLibrary
{
    using System.Globalization;

    public class Book : IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class. 
        /// </summary>
        /// <param name="title">
        /// Book title
        /// </param>
        /// <param name="author">
        /// Book author
        /// </param>
        /// <param name="year">
        /// Year of publishing
        /// </param>
        /// <param name="publishingHouse">
        /// Publishing house
        /// </param>
        /// <param name="edition">
        /// Edition number
        /// </param>
        /// <param name="pages">
        /// Number of pages
        /// </param>
        /// <param name="price">
        /// Price in local currency
        /// </param>
        public Book(string title, string author, int year, string publishingHouse, uint edition, uint pages, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year.ToString();
            this.PublishingHouse = publishingHouse;
            this.Edition = edition.ToString();
            this.Pages = pages.ToString();
            this.Price = price;
        }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Year { get; private set; }

        public string PublishingHouse { get; private set; }

        public string Edition { get; private set; }

        public string Pages { get; private set; }

        public decimal Price { get; private set; }

        /// <summary>
        /// Returns string representation of the book
        /// </summary>
        /// <param name="format">Format specifier</param>
        /// <param name="formatProvider">An instance of IFormatProvider</param>
        /// <returns>Returns string representation of the current instance of the book</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            // handling empty format as general
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            // handling null provider as current culture
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            // taking the first letter from the format specifier
            string thisFormat = format.Length == 1 ? format : format.Substring(0, 1);
            switch (thisFormat.ToUpperInvariant())
            {
                // Title
                case "T":
                    return $"Book record: {this.Title}";

                // title and Author
                case "A":
                    return $"Book record: {this.Author}, {this.Title}";

                // title, author and Year (General)
                case "Y":
                case "G":
                    return $"Book record: {this.Author}, {this.Title}, {this.Year}";

                // title, author, year and Publisher
                case "P":
                    return $"Book record: {this.Author}, {this.Title}, {this.Year}, \"{this.PublishingHouse}\"";

                // Short record
                case "S":
                    return $"Book record: {this.Title}, {this.Year}, \"{this.PublishingHouse}\"";

                // Extended record
                case "E":
                    return
                        $"Book record: {this.Author}, {this.Title}, edition {this.Edition}, {this.Pages}p., {this.Year}";

                // full book info
                default:
                    return
                        $"Book record: {this.Author}, {this.Title}, {this.Year}, \"{this.PublishingHouse}\", edition {this.Edition}, {this.Pages}p., {this.Price.ToString("C", formatProvider)}";
            }
        }
    }
}
