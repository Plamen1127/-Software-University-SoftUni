namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defDb;
        [SetUp]
        public void SetUp()
        {
            defDb = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void Constructor_Shuld_Initialiaze_Data_With_Correct_Count(int[] data)
        {
            Database database = new Database(data);

            int expextedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expextedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void Constructor_Shuld_Throw_Exception_When_Input_Data_Is_About_16_Count(int[] data)
        {


            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(data);

            }, "Array's capacity must be exactly 16 integers!");
        }


        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_Shuld_Add_Elements_Into_Data_Field(int[] data)
        {
            Database database= new Database(data);

            int[] expectData = data;
            int[] actulaData = database.Fetch();

            CollectionAssert.AreEqual(expectData, actulaData);

        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Count_Shut_Return_Correct_Count(int[] data)
        {
            Database database = new Database(data);

            int expectData = data.Length;
            int actulaData = database.Count;

            Assert.AreEqual(expectData, actulaData);

        }

        [Test]
        public void Adding_Elements_Shud_Increase_Count()
        {
            int expectetCount = 5;

            for (int i = 1; i <= expectetCount; i++)
            {
                this.defDb.Add(i);
            }

            int actualCoun = defDb.Count;

            Assert.AreEqual(expectetCount, actualCoun);
        }
        [Test]
        public void Adding_Elements_Shud_Add_them_To_The_Data_Colection()
        {
            int[] expectData = new int[5];

            for (int i = 1; i <= 5; i++)
            {
                this.defDb.Add(i);
                expectData[i-1] = i;  
            }

            int[] actualData = this.defDb.Fetch();

            CollectionAssert.AreEqual(expectData, actualData);
        }

        [Test]
        public void Adding_More_Then_16_Element_Should_Throw_Exception()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defDb.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]

        public void Removing_Elements_Should_Decrease_Count()
        {
            int initilCount = 5;

            for (int i = 1; i <= initilCount; i++)
            {
                this.defDb.Add(i);
            }

            int remuoveCount = 2;

            for (int i = 1; i <= remuoveCount; i++)
            {
                this.defDb.Remove();
            }

            int expectedCount = initilCount - remuoveCount;
            int actualiCount = this.defDb.Count;

            Assert.AreEqual(expectedCount, actualiCount);


        }

        [Test]
        public void Removing_Elements_Should_Remouve_From_Data_Colection()
        {
            int initilCount = 5;
            for (int i = 1; i <= initilCount; i++)
            {
                this.defDb.Add(i);
            }

            int remuveCount = 2;
            for (int i = 1; i <= remuveCount; i++)
            {
                this.defDb.Remove();
            }

            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actulData = this.defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actulData);
        }

        [Test]
        public void Remuving_Element_When_Elements_Are_0_Should_Throw_Exception()
        {
           

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Fetch_Should_Return_Colection_With_Elements_In_Db(int[] data)
        {
            Database database = new Database(data);

            int[] expectedData = data;
            int[] actialData = database.Fetch();

            CollectionAssert.AreEqual (expectedData, actialData);   
        }
    }
}
