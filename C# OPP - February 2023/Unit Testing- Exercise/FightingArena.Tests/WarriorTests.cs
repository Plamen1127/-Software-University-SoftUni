namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Constructor_Should_Inicialize_Warror_Name()
        {
            string exprctedName = "Plamen";

            Warrior warrior = new Warrior(exprctedName, 100, 100);

            string actialName = warrior.Name;

            Assert.AreEqual(exprctedName, actialName);
        }


        [Test]
        public void Constructor_Should_Inicialize_Warror_Damage()
        {
            int expectedDamage = 50;

            Warrior warrior = new Warrior("Plamen", expectedDamage, 100);

            int actulaDamagr = warrior.Damage;

            Assert.AreEqual(expectedDamage, actulaDamagr);
        }


        [Test]
        public void Constructor_Should_Inicialize_Warror_HP()
        {
            int expectedHP = 50;
            Warrior warrior = new Warrior("Plamen", 50, expectedHP);

            int actualHP = warrior.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase("Plamen")]
        [TestCase("P")]
        [TestCase("long long long long long ong long long long very long Name")]
        public void NameSetars_Should_Set_Valid_Name(string name)
        {
            Warrior warrior = new Warrior(name, 100, 100);

            string exprctedName = name;
            string actialName = warrior.Name;

            Assert.AreEqual(exprctedName, actialName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void NameSetars_Should_Set_Throw_Exceptions_With_Empty_OrWhite_Space_Name(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 100, 100);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(50)]
        [TestCase(1)]
        [TestCase(100)]
        public void DamageSetars_Should_Set_Valid_Damage(int damage)
        {
            Warrior warrior = new Warrior("Plamen", damage, 100);

            int expectetDamage = damage;
            int actulaDamage = warrior.Damage;

            Assert.AreEqual(expectetDamage, actulaDamage);
        }

        [TestCase(-1)]
        [TestCase(-55)]
        [TestCase(0)]
        public void Damage_Setars_Should_Set_Throw_Exceptions_With_Zero_Or_Negative_Damage(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Plamen", damage, 100);
            }, "Damage value should be positive!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(101)]
        public void Hp_Setars_Should_Set_Valid_Hp(int hp)
        {
            Warrior warrior = new Warrior("Plame", 100, hp);

            int expectetHp = hp;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectetHp, actualHp);
        }

        [TestCase(-1)]
        [TestCase(-50)]
        public void Hp_Setars_Should_Set_Throw_Exceptions_With_Negative_Hp(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Plamen", 100, hp);
            }, "HP should not be negative!");
        }

        [Test]
        public void Success_Atacking_Warrior_No_Kill()
        {
            int w1Damage = 30;
            int w1Hp = 50;
            int w2Damage = 30;
            int w2Hp = 50;

            Warrior w1 = new Warrior("Plamen", w1Damage, w1Hp);
            Warrior w2 = new Warrior("Gosho", w2Damage, w2Hp);

            w1.Attack(w2);

            int w1ExpectedHp = w1Hp - w2Damage;
            int w2ExpectetHp = w2Hp - w1Damage;

            int w1ActualHp = w1.HP;
            int w2ActualHp = w2.HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHp);
            Assert.AreEqual(w2ExpectetHp, w2ActualHp);
        }

        [TestCase(49)]
        [TestCase(50)]
        [TestCase(35)]
        public void Success_Atacking_Warrior_With_Kill(int w2Hp)
        {
            int w1Damage = 50;
            int w1Hp = 50;
            int w2Damage = 30;

            Warrior w1 = new Warrior("Plamen", w1Damage, w1Hp);
            Warrior w2 = new Warrior("Gosho", w2Damage, w2Hp);

            w1.Attack(w2);

            int w1ExpectedHp = w1Hp - w2Damage;
            int w2ExpecteHp = 0;

            int w1ActualHp = w1.HP;
            int w2ActulaHp = w2.HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHp);
            Assert.AreEqual(w2ExpecteHp, w2ActulaHp);

        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void Atacking_Should_Throw_exception_When_Attacer_Hp_Is_Below_min(int w1Hp)
        {
            int w1Damage = 50;
            int w2Hp = 50;
            int w2Damage = 30;

            Warrior w1 = new Warrior("Plamen", w1Damage, w1Hp);
            Warrior w2 = new Warrior("Gosho", w2Damage, w2Hp);


            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void Atacking_Should_Throw_Exception_When_Defender_Hp_Is_Below_min(int w2Hp)
        {
            int w1Damage = 50;
            int w1Hp = 50;
            int w2Damage = 30;

            Warrior w1 = new Warrior("Plamen", w1Damage, w1Hp);
            Warrior w2 = new Warrior("Gosho", w2Damage, w2Hp);


            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, $"Enemy HP must be greater than 30 in order to attack him!");
        }


        [TestCase(45, 55)]
        [TestCase(45, 46)]
        public void Atacking_Should_Throw_Exception_When_Attacer_Hp_Is_less_From_Damage_Of_Defender(int w1Hp, int w2Damage)
        {
            int w1Damage = 25;
            int w2Hp = 50;


            Warrior w1 = new Warrior("Plamen", w1Damage, w1Hp);
            Warrior w2 = new Warrior("Gosho", w2Damage, w2Hp);


            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, $"You are trying to attack too strong enemy");
        }
    }
}