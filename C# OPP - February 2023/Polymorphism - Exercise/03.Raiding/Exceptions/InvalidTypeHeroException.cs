using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Exceptions
{
    public class InvalidTypeHeroException : Exception
    {
        public InvalidTypeHeroException()
            :base()
        {

        }

        public InvalidTypeHeroException(string message)
            : base(message) 
        {
        }

       
    }
}
