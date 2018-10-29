using System;

namespace BookExtension
{
    using BookLibrary;

    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Returns an object that provides formatting services for the specified type
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return</param>
        /// <returns>An instance of the object specified by formatType, if the IFormatProvider implementation can supply that type of object; otherwise, null.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Converts the value of a book to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications</param>
        /// <param name="arg">An object to format</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance</param>
        /// <returns>The string representation of the value of arg, formatted as specified by format and formatProvider</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is Book))
            {
                throw new ArgumentException("Invalid argument!", nameof(arg));
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "Custom";
            }

            // taking the first letter from the specifier
            string thisFormat =
                format.Length == 1 ? format.ToUpperInvariant() : format.Substring(0, 1).ToUpperInvariant();
            if (thisFormat != "C")
            {
                return ((IFormattable)arg).ToString(format, formatProvider);
            }

            Book book = (Book)arg;
            string result = $"Author: {book.Author}\nTitle: {book.Title}, edition {book.Edition}\nYear: {book.Year}";
            return result;
        }
    }
}
