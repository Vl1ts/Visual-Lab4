using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal class RomanNumberExtend : RomanNumber
    {
        private ushort number;
        private ushort ConvertToUshort(string newStringValue)
        {
            ushort numberValue = 0;

            const ushort combinationAmount = 7 + 6;
            ushort[] combinationValues = new ushort[combinationAmount] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] combinationStringValues = new string[combinationAmount] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            for (int i = 0; i < combinationAmount; ++i)
            {
                while (newStringValue.IndexOf(combinationStringValues[i]) == 0)
                {
                    numberValue += combinationValues[i];
                    newStringValue = newStringValue.Remove(0, combinationStringValues[i].Length);
                }
            }

            if (numberValue < 1 || numberValue > 3999)
            {
                throw new RomanNumberException("Incorrect input string!");
            }

            return numberValue;
        }
        public RomanNumberExtend(string num)
        {
            number = ConvertToUshort(num);
        }
        public ushort getNumber()
        {
            return number;
        }
    }
}
