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
            const string NUMBERS = "0123456789ABCDF";

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Null source string!");
            }

            if (@base < 2 || @base > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(@base), "Base must be between 2 and 16 inclusively!");
            }

            int result = 0, index = source.Length - 1;
            string number = source.ToLowerInvariant();

            string pattern = NUMBERS.Substring(0, @base);

            // checking if source string matches the pattern
            for (int i = 0; i < source.Length; i++)
            {
                if (pattern.IndexOf(char.ToUpper(source[i])) == -1)
                {
                    throw new ArgumentException("Invalid source string!", nameof(source));
                }
            }

            int radix = 1;

            while (index >= 0)
            {
                // getting current digit
                int digit;
                if (number[index] - '0' < NUMBEROFDIGITS)
                {
                    digit = number[index] - '0';
                }
                else
                {
                    digit = number[index] - 'a' + NUMBEROFDIGITS;
                }

                // checking if result can be stored in int number
                try
                {
                    checked
                    { 
                        result += radix * digit;
                        if (index > 0)
                        {
                            radix *= @base;
                        }
                    }
                }
                catch (OverflowException e)
                {
                    throw new ArgumentException("Too big number!", nameof(source), e);
                }

                index--;
            }

            return result;
        }
    }
}
