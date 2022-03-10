using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal class RomanNumber : ICloneable, IComparable
    {
        private ushort value;
        private StringBuilder? stringValue;
        private static StringBuilder? Convert(ushort n)
        {
            StringBuilder? newStringValue = new StringBuilder();

            try
            {
                const ushort combinationAmount = 7 + 6;
                ushort[] combinationValues = new ushort[combinationAmount] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
                string[] combinationStringValues = new string[combinationAmount] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

                for (int i = 0; i < combinationAmount; ++i)
                {
                    while (n >= combinationValues[i])
                    {
                        newStringValue.Append(combinationStringValues[i]);
                        n -= combinationValues[i];
                    }
                }

                if (newStringValue == null)
                {
                    throw new RomanNumberException("Construction failed!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return newStringValue;
        }
        //Конструктор получает число n, которое должен представлять объект
        public RomanNumber(ushort n = 1)
        {
            if (n < 1 || n > 3999)
            {
                throw new RomanNumberException("Incorrect number: out of range!");
            }

            value = n;
            stringValue = Convert(n);
        }
        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            //RomanNumber roman = new RomanNumber();

            //roman.value = (ushort)(n1.value + n2.value);
            //roman.stringValue = Convert(roman.value);

            //return roman;

            return new RomanNumber((ushort)(n1.value + n2.value));
        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value - n2.value));
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value * n2.value));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
            {
                throw new RomanNumberException("One of numbers is null!");
            }

            return new RomanNumber((ushort)(n1.value / n2.value));
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            if (stringValue == null)
            {
                throw new RomanNumberException("Number is null!");
            }

            return stringValue.ToString();
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(value);
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            RomanNumber? new_obj = obj as RomanNumber;

            return value.CompareTo(new_obj.value);
        }
    }
}
