using System;

namespace StringExtension
{
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            const int NUMBEROFDIGITS = 10;
            const string NUMBERS = "0123456789ABCDEF";

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Null source string!");
            }

            if (@base < 2 || @base > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(@base), "Base must be between 2 and 16 inclusively!");
            }

            int result = 0;
            string number = source.ToLowerInvariant();

            string pattern = NUMBERS.Substring(0, @base);

            int radix = 1;

            // getting current digit
            for (int i = source.Length - 1; i >= 0; i--)
            {
                int digit = pattern.IndexOf(char.ToUpper(source[i]));
                if (digit == -1)
                {
                    throw new ArgumentException("Invalid source string!", nameof(source));
                }

                try
                {
                    checked
                    {
                        result += radix * digit;
                        if (i > 0)
                        {
                            radix *= @base;
                        }
                    }
                }
                catch (OverflowException e)
                {
                    throw new ArgumentException("Too big number!", nameof(source), e);
                }
            }

            return result;
        }
    }
}
