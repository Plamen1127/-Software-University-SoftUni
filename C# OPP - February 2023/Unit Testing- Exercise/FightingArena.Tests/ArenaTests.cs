namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Diagnostics;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Constructor_Should_Initialize_Warriors_Colection()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Enroling_Not_ExistingWorrior_Shuold_Success()
        {
            Warrior warrior = new Warrior("Plamen", 100, 100);

            this.arena.Enroll(warrior);

            bool isWarriorenrol = this.arena.Warriors.Contains(warrior);

            Assert.IsTrue(isWarriorenrol);
        }

        [Test]
        public void Enroling_Existing_The_Same_Worrior_Shuold_Throw_Exception()
        {
            Warrior warrior = new Warrior("Plamen", 100, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Enroling_Existing_The_Same_Name_Worrior_Shuold_Throw_Exception()
        {
            Warrior w1 = new Warrior("Plamen", 100, 100);
            Warrior w2 = new Warrior("Plamen", 50, 60);

            this.arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(w2);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Count_Should_Return_Enroling_Warriors_Count()
        {
            Warrior w1 = new Warrior("Plamen", 50, 100);
            Warrior w2 = new Warrior("Gosho", 45, 100);

            this.arena.Enroll(w1);
            this.arena.Enroll(w2);

            int expectetCount = 2;
            int actualCoun = this.arena.Count;

            Assert.AreEqual(expectetCount, actualCoun);
        }

        [Test]
        public void Count_Should_Return_Zero_When_No_Enroling_Warriors_Are_Enroling()
        {
            int expectetCount = 0;
            int actualCoun = this.arena.Count;

            Assert.AreEqual(expectetCount, actualCoun);
        }

        [Test]
        public void Fight_Should_Throw_Exception_Whit_Non_Existing_Attacker()
        {

            Warrior w1 = new Warrior("Plamen", 50, 100);
            Warrior w2 = new Warrior("Gosho", 45, 100);


            this.arena.Enroll(w2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(w1.Name, w2.Name);
            }, $"There is no fighter with name {w1.Name} enrolled for the fights!");
        }

        [Test]
        public void Fight_Should_Throw_Exception_Whit_Non_Existing_Defender()
        {

            Warrior w1 = new Warrior("Plamen", 50, 100);
            Warrior w2 = new Warrior("Gosho", 45, 100);


            this.arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(w1.Name, w2.Name);
            }, $"There is no fighter with name {w2.Name} enrolled for the fights!");
        }

        [Test]
        public void Figth_Should_Succeed_When_Warrios_Exist()
        {

            Warrior w1 = new Warrior("Plamen", 50, 100);
            Warrior w2 = new Warrior("Gosho", 35, 100);

            this.arena.Enroll(w1);
            this.arena.Enroll(w2);

            int w1ExpectetHp = w1.HP-w2.Damage;
            int W2ExpectetHp = w2.HP-w1.Damage;

            this.arena.Fight(w1.Name, w2.Name);

            int w1ActualHp = w1.HP;
            int w2ActualHp = w2.HP;

            Assert.AreEqual(w1ExpectetHp, w1ActualHp);
            Assert.AreEqual(W2ExpectetHp, w2ActualHp);
        }
    }
}
