using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string name, string lastName, decimal salary, Corps corps) 
            : base(id, name, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        => base.ToString() + $"{Environment.NewLine}Corps: {Corps}";
    }
}
