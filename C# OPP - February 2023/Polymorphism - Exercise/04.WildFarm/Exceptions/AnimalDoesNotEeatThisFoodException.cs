using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Exceptions
{
    public class AnimalDoesNotEeatThisFoodException  : Exception
    {
        public AnimalDoesNotEeatThisFoodException(string message):
            base(message)
        {
                
        }
        public AnimalDoesNotEeatThisFoodException():
            base()
        {

        }
    }
}
