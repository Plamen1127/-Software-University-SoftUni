namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class CarManagerTests
    {
        private Car defCar;
        [SetUp]
        public void SetUp()
        {
            defCar = new Car("Mercedes", "W203", 5, 62);
        }

        [Test]
        public void Constructor_Should_Inicialize_Car_Mace()
        {
            string expectedMake = "Mercedes";

            Car car = new Car(expectedMake, "W203", 5, 62);

            string actialName = car.Make;

            Assert.AreEqual(expectedMake, actialName);
        }

        [Test]
        public void Constructor_Should_Inicialize_Car_Model()
        {
            string expectedModel = "W203";

            Car car = new Car("Mercedes", expectedModel, 5, 62);

            string actialModel = car.Model;

            Assert.AreEqual(expectedModel, actialModel);
        }

        [Test]
        public void Constructor_Should_Inicialize_Car_Fuel_Consumption()
        {
            double expectedFuelConsumtion = 5;

            Car car = new Car("Mercedes", "W203", expectedFuelConsumtion, 62);

            double actialFuelConsumtion = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumtion, actialFuelConsumtion);
        }

        [Test]
        public void Constructor_Should_Inicialize_Car_Fuel_Capacity()
        {
            double expectedFuelCapacity = 62;

            Car car = new Car("Mercedes", "W203", 5, expectedFuelCapacity);

            double actialFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actialFuelCapacity);
        }

        [TestCase("Mercedes")]
        [TestCase("M")]
        [TestCase("long long long long long ong long long long very long Make")]
        public void Make_Setars_Should_Set_Valid_Make(string make)
        {
            Car car = new Car(make, "W203", 5, 62);

            string exprctedMake = make;
            string actialMake = car.Make;

            Assert.AreEqual(exprctedMake, actialMake);
        }

        [TestCase(null)]
        [TestCase("")]
        public void make_Setars_Should_Set_Throw_Exceptions_With_Empty_OrWhite_Space_Make(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "W203", 5, 62);
            }, "Make cannot be null or empty!");
        }

        [TestCase("W203")]
        [TestCase("W")]
        [TestCase("long long long long long ong long long long very long Model")]
        public void Model_Setars_Should_Set_Valid_Model(string model)
        {
            Car car = new Car("Mercedes", model, 5, 62);

            string exprctedModel = model;
            string actialModel = car.Model;

            Assert.AreEqual(exprctedModel, actialModel);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Model_Setars_Should_Set_Throw_Exceptions_With_Empty_OrWhite_Space_Model(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mercedes", model, 5, 62);
            }, "Make cannot be null or empty!");
        }

        [TestCase(25.5)]
        [TestCase(1)]
        [TestCase(0.1)]
        [TestCase(100)]
        public void Fuel_Consumption_Setars_Should_Set_Valid_Fuel_Consumption(double fuelConsumption)
        {
            Car car = new Car("mercedes", "W203", fuelConsumption, 62);

            double expectetfuelConsumption = fuelConsumption;
            double actulafuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectetfuelConsumption, actulafuelConsumption);
        }

        [TestCase(-0.1)]
        [TestCase(-55.5)]
        [TestCase(0)]
        public void Fuel_Consumption_Should_Set_Throw_Exceptions_With_Zero_Or_Negative_Fuel_Consumption(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("mercedes", "W203", fuelConsumption, 62);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(25.5)]
        [TestCase(1)]
        [TestCase(0.1)]
        [TestCase(100)]
        public void Fuel_Capacity_Setars_Should_Set_Valid_Fuel_Capacity(double fuelCapacity)
        {
            Car car = new Car("mercedes", "W203", 5, fuelCapacity);

            double expectetFuelCapacityn = fuelCapacity;
            double actulaFuelCapacityn = car.FuelCapacity;

            Assert.AreEqual(expectetFuelCapacityn, actulaFuelCapacityn);
        }

        [TestCase(-0.1)]
        [TestCase(-55.5)]
        [TestCase(0)]
        public void Fuel_Capacity_Should_Set_Throw_Exceptions_With_Zero_Or_Negative_Fuel_Capacity(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("mercedes", "W203", 5, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(61.9)]
        [TestCase(61)]
        public void Refuel_Should_Set_Valid_Fuel_Capacity(double fuelToRefuel)
        {
            Car car = new Car("mercedes", "W203", 5, 62);

            car.Refuel(fuelToRefuel);

            double expectFuel = fuelToRefuel;
            double actualFuel = car.FuelAmount;

            Assert.AreEqual(expectFuel, actualFuel);
        }

        [TestCase(-0.1)]
        [TestCase(0)]
        [TestCase(-25.5)]
        [TestCase(-100)]
        public void Refuel_Should_Set_Throw_Exceptions_With_Zero_Or_Negative_Fuel(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defCar.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(62.1)]
        [TestCase(63)]
        [TestCase(100)]
        public void Refueling_Should_Fill_The_Tank_To_The_Top_If_The_Fuel_Is_More_Than_The_Tank_Capacity(double fuelToRefuel)
        {
            Car car = new Car("mercedes", "W203", 5, 62);

            car.Refuel(fuelToRefuel);

            double expectFuel = 62;
            double actualFuel = car.FuelAmount;

            Assert.AreEqual(expectFuel, actualFuel);
        }


        [Test]
        public void Drive_Should_Reduce_Fuel_Amount_If_Its_Compleated()
        {
            Car car = new Car("mercedes", "W203", 5, 62);

            car.Refuel(62);

            car.Drive(100);

            double expectFuel = 57;
            double actualFuel = car.FuelAmount;

            Assert.AreEqual(expectFuel, actualFuel);

        }

        [Test]
        public void Drive_Should_Throw_Exception_When_Fuel_Needed_Is_More_From_Fuel_Amount()
        {
            Car car = new Car("mercedes", "W203", 5, 62);

            car.Refuel(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(150);
            }, "You don't have enough fuel to drive!");

        }
    }
}