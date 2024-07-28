using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {

            CarDealerContext context = new CarDealerContext();

            //from problem 09-13
            // string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(context, inputJson);
            //Console.WriteLine(result);

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            //вземаме влист от валидните Id-та
            var validSupplierId = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            //филтрираме само валиднитъе Id-та от parts
            var partsWithValidSupplairId = parts
                .Where(p => validSupplierId.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(partsWithValidSupplairId);
            context.SaveChanges();

            return $"Successfully imported {partsWithValidSupplairId.Length}.";
        }

        //problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<List<ImportCarsDto>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(newCar);
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar()
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }


            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);

            context.SaveChanges();


            return $"Successfully imported {cars.Count}.";
        }

        //problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }


        //problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver,

                })
                .ToList();

            return SerializeObjWithJsonSettings(orderedCustomers);
        }

        //problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance,

                })
                .ToList();

            return SerializeObjWithJsonSettings(carsToyota);
        }

        //problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            return SerializeObjWithJsonSettings(suppliers);
        }

        //problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var GetCarsWithTheirListOfParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(cp => new
                    {
                        cp.Part.Name,
                        Price = cp.Part.Price.ToString("f2")
                    })
                })
                .ToList();

            return SerializeObjWithJsonSettings(GetCarsWithTheirListOfParts);
        }

        //problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var soldCarCustomers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Select(c => c.Car.PartsCars.Select(p => p.Part.Price).Sum())
                })
                .ToList();

            var totalSalesByCustomer = soldCarCustomers
                .Select(s => new
                {
                    s.FullName,
                    s.BoughtCars,
                    SpentMoney = s.SpentMoney.Sum()

                })
                 .OrderByDescending(s => s.SpentMoney)
                 .ThenByDescending(s => s.BoughtCars)
                 .ToList();

            return SerializeObjWithJsonSettings(totalSalesByCustomer);
        }

        //problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(x => new
            {
                car = new
                {
                    x.Car.Make,
                    x.Car.Model,
                    x.Car.TraveledDistance
                },
                customerName = x.Customer.Name,
                Discount = x.Discount.ToString("F2"),
                price = x.Car.PartsCars.Sum(p => p.Part.Price).ToString("F2"),
                priceWithDiscount = (x.Car.PartsCars.Sum(p => p.Part.Price) - x.Car.PartsCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("F2")
            })
            .Take(10)
            .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }





        private static string SerializeObjWithJsonSettings(object obj)
        {
            var settingsWithNull = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
              //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            var settingsWithoutNull = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(obj, settingsWithoutNull);
        }
    }
}