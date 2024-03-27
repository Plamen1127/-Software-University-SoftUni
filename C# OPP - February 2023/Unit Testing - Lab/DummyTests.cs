using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Chec_Is_Dummy_Loses_Healt_Corectly()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]  
        public void Dead_Dummy_Shuld_Throw_Exception_When_Attacked()
        {
            Dummy dummy= new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5), "Dummy accept attach when dead");
        }

        [Test]
        public void Dummy_Give_Exspirience_When_Dies()
        {
            Dummy dummy= new Dummy(0, 10);

            int giveExspiriance = dummy.GiveExperience();

            Assert.AreEqual(10,giveExspiriance);
        }

        [Test]

    public void Dummy_Cant_Give_Exspirience_When_Alive()
        {
            Dummy dummy = new Dummy(10,10);

            Assert.Throws<InvalidOperationException>( () => dummy.GiveExperience(), "Alive Dummy cant give exspiriance");
        }
    }
}