using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal class RomanNumberException : Exception
    {
        public RomanNumberException(string message)
            : base(message) { }
    }
}