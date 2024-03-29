namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUP()
        {
            db = new Database();
        }

        [Test]
        public void Add_Method_Test()
        {
            db.Add(new Person(1, "Plamen"));
            Person result = db.FindById(1);

            Assert.AreEqual(1, result.Id);

            Assert.AreEqual(1, db.Count);

            Assert.AreEqual("Plamen", result.UserName);
        }

        [Test]
        public void Add_Should_Throw_Is_More_Than_Maximum_Length()
        {
            Person[] people = CrateFullArray();
            db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(17, "Plamen"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        private Person[] CrateFullArray()
        {
            Person[] result = new Person[16];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Person(i, i.ToString());

            }

            return result;
        }

        [Test]
        public void Add_Should_Throw_Exception_If_Not_Unique_Username()
        {
            db.Add(new Person(1, "Plamen"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(2, "Plamen"));

            }, "There is already user with this username!");
        }

        [Test]
        public void Add_Should_Throw_Exception_If_Not_UniqueId()
        {
            db.Add(new Person(1, "Plamen"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(1, "Gosho"));

            }, "There is already user with this Id!");
        }

        [Test]
        public void Constructor_Should_Initialaze_With_Corrct_Count()
        {
            db.Add(new Person(1, "Plamen"));
            db.Add(new Person(2, "Gosho"));

            Person first = db.FindById(1);
            Person second = db.FindById(2);

            Assert.AreEqual("Plamen", first.UserName);

            Assert.AreEqual("Gosho", second.UserName);

            Assert.AreEqual(2, db.Count);
        }

        [Test]
        public void Removeing_Element_From_Empty_Collection_Should_Throw_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();

            });
        }

        [Test]
        public void Removeing_Elements_From_The_Collections_Should_Remove_It_From_The_Database_Collection()
        {
            db.Add(new Person(1, "Plamen"));
            db.Add(new Person(2, "Gosho"));
            Person first = db.FindById(1);
            db.Remove();

            Assert.AreEqual(1, db.Count);

            Assert.AreEqual("Plamen", first.UserName);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("Gosho");
            }, "No user is present by this username!");

        }

        [Test]
        public void Find_By_Username_Should_Throw_If_Username_Null_Or_Empty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            }, "Username parameter is null!");

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(string.Empty);
            }, "Username parameter is null!");
        }

        [Test]
        public void Find_By_Username_Should_Throw_Exception_If_Username_Does_Not_Exsist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("Gosho");
            }, "No user is present by this username!");
        }

        [Test]
        public void Find_By_User_Name_Returns_CorrectUser()
        {
            db.Add(new Person(1, "Plamen"));
            db.Add(new Person(2, "Gosho"));
            Person person = db.FindByUsername("Plamen");

            Assert.AreEqual("Plamen", person.UserName);

            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void Find_By_ID_Should_Throw_Exception_If_Id_Doesnt_Exist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(1);
            }, "No user is present by this ID!");

        }

        [Test]
        public void Find_By_ID_Should_Throw_exception_If_Id_Is_Less_Than0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-1);
            }, "Id should be a positive number!");
        }

        [Test]
        public void Find_By_ID_Returns_Correct_User()
        {
            db.Add(new Person(1, "Plamen"));
            db.Add(new Person(2, "Gosho"));
            Person person = db.FindById(1);

            Assert.AreEqual("Plamen", person.UserName);

            Assert.AreEqual(1, person.Id);
        }



    }
}
    