using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    internal class Spy : Soldier, ISpy
    {
        public Spy(int id, string name, string lastName, int codenumber) 
            : base(id, name, lastName)
        {
            CodeNumber = codenumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        => base.ToString() + $"{Environment.NewLine}Code Number: {CodeNumber}";
    }
}
