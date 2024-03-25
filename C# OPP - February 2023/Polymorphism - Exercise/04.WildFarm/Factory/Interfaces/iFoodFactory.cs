using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Factory.Interfaces
{
    public interface IFoodFactory
    {
        public IFood CreateFood(string typeFood, int qty);
    }
}
