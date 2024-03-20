using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class HerosFactory : IHerosFactory
    {
        public IBaseHero CriateHero(string heroName, string heroType)
        {
            IBaseHero hero;
            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }
            else
            {
                throw new InvalidTypeHeroException(string.Format(ExceptionMessages.HeroTypeIsInvalid));
            }

            return hero;
        }
    }
}
