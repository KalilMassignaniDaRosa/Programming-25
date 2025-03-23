using System.Security.Cryptography.X509Certificates;

namespace CheckBook.Models
{
    public class CheckBookModelEn
    {
        public int number;
        public string NumberInWords { get; set; } = string.Empty;

        public string ConvertNumber(int number)
        {
            if (number == 0)
                return "Zero";
            else if (number == 1000000)
                return "One million";

            int thousandsPart = number / 1000;
            int hundredsPart = number % 1000;

            string words = string.Empty;

            if (thousandsPart > 0)
            {
                words += ConvertGroup(thousandsPart) + " thousand";
            }

            if (hundredsPart > 0)
            {
                if (thousandsPart > 0)
                    words += " ";

                words += ConvertGroup(hundredsPart);
            }

            return char.ToUpper(words[0]) + words.Substring(1);
        }

        private string ConvertGroup(int number)
        {
            string words = string.Empty;
            int hundreds = number / 100;
            int remainder = number % 100;

            if (hundreds > 0)
            {
                if (number == 100)
                    return "one hundred";
                else
                    words += GetHundredsWord(hundreds);
            }

            if (remainder > 0)
            {
                if (!string.IsNullOrEmpty(words))
                    words += " ";

                if (remainder < 10)
                {
                    words += GetUnitsWord(remainder);
                }
                else if (remainder < 20)
                {
                    words += GetTeensWord(remainder);
                }
                else
                {
                    int tens = remainder / 10;
                    int units = remainder % 10;
                    words += GetTensWord(tens);
                    if (units > 0)
                        words += " " + GetUnitsWord(units);
                }
            }

            return words;
        }

        private string GetUnitsWord(int digit)
        {
            switch (digit)
            {
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "";
            }
        }
        private string GetTeensWord(int number)
        {
            switch (number)
            {
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
                default: return "";
            }
        }
        private string GetTensWord(int digit)
        {
            switch (digit)
            {
                case 2: return "twenty";
                case 3: return "thirty";
                case 4: return "forty";
                case 5: return "fifty";
                case 6: return "sixty";
                case 7: return "seventy";
                case 8: return "eighty";
                case 9: return "ninety";
                default: return "";
            }
        }

        private string GetHundredsWord(int digit)
        {
            switch (digit)
            {
                case 1: return "one hundred";
                case 2: return "two hundred";
                case 3: return "three hundred";
                case 4: return "four hundred";
                case 5: return "five hundred";
                case 6: return "six hundred";
                case 7: return "seven hundred";
                case 8: return "eight hundred";
                case 9: return "nine hundred";
                default: return "";
            }
        }
    }
}
