
using System;
using System.Linq;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICalling
    {
        public string Call(string number)
        {
            if (!IsValidNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {number}";
        }

        private bool IsValidNumber(string number)
       => number.All(n => char.IsDigit(n));
    }
}
