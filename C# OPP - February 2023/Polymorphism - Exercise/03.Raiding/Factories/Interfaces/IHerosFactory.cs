﻿using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories.Interfaces
{
    public interface IHerosFactory
    {
         IBaseHero CriateHero(string nameNmae, string typeTape);
       
    }
}
