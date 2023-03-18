using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICalling, IBrowsing
    {

        public string Call(string number)
        {
            if (!IsValidNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (!IsValidUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
        public bool IsValidNumber(string number)
            => number.All(n => char.IsNumber(n));

        private bool IsValidUrl(string url)
       => url.All(u => !char.IsDigit(u));

        

    }
}
