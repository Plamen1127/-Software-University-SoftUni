using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Tomcat : Cat
    {
        private const string Tomcadgender = "Male";

        public Tomcat(string name, int age) : base(name, age, Tomcadgender)
        {
        }

        public override string ProduceSound() => "MEOW";
    }
}
