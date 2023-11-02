using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue), "Input string cannot be null.");
            }

            stringValue = stringValue.Trim();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new FormatException("Input string cannot be empty or contain only whitespace.");
            }

            bool isNegative = false;
            int startIndex = 0;

            if (stringValue[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }
            else if (stringValue[0] == '+')
            {
                startIndex = 1;
            }

            if (startIndex >= stringValue.Length)
            {
                throw new FormatException("Input string does not contain valid digits.");
            }

            long result = 0;

            for (int i = startIndex; i < stringValue.Length; i++)
            {
                if (!char.IsDigit(stringValue[i]))
                {
                    throw new FormatException("Input string contains non-numeric characters.");
                }

                int digit = stringValue[i] - '0';
                result = result * 10 + digit;

                if (isNegative)
                {
                    if (-result < int.MinValue)
                    {
                        throw new OverflowException("Input number is out of Int32 range.");
                    }
                }
                else
                {
                    if (result > int.MaxValue)
                    {
                        throw new OverflowException("Input number is out of Int32 range.");
                    }
                }
            }

            return (int)(isNegative ? -result : result);
        }
    }
}