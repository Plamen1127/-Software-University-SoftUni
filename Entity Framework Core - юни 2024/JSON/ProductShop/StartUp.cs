using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Text.Json;

namespace ProductShop
{
    public class StartUp
    {

        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            //problem 1
            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(context, inputJson);

            //problem 2
            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(context, inputJson);

            //problem 3
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //string result = ImportCategories(context, inputJson);

            //problem 4
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, inputJson);

            //problem 5


            Console.WriteLine(GetUsersWithProducts(context));
        }

        //problem 1 - whit DTO
        //public static string ImportUsers(ProductShopContext context, string inputJson)
        //{

        // IMapper mapper = new Mapper(new MapperConfiguration(mpc =>
        // {
        //     mpc.AddProfile<ProductShopProfile>();
        // }));
        //ImportUsersDto[] userDtos = JsonConvert.DeserializeObject<ImportUsersDto[]>(inputJson);

        // ICollection<User> validUsers = new HashSet<User>();
        // foreach (ImportUsersDto userDto in userDtos)
        // {
        // User user = mapper.Map<User>(userDto);

        //  validUsers.Add(user);
        // }

        //context.Users.AddRange(validUsers);
        //context.SaveChanges();

        // return $"Successfully imported {validUsers.Count}";
        //  }


        //problem 1 - whitout DTO
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}"; ;
        }

        //problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var roductsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            return FormatJson(roductsInRange);
        }


        //problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    })
                })
                .AsNoTracking()
                .ToList();

            // var setings = new JsonSerializerSettings()
            // {
            //     NullValueHandling = NullValueHandling.Ignore,
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //    Formatting = Formatting.Indented
            //};
            // return JsonConvert.SerializeObject(soldProducts, setings);

            return FormatJson(soldProducts);
        }


        //problem 7 

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
               .Select(c => new
               {
                   Category = c.Name,
                   ProductsCount = c.CategoriesProducts.Count(),
                   AveragePrice = c.CategoriesProducts
                                .Average(cp => cp.Product.Price)
                                .ToString("f2"),
                   TotalRevenue = c.CategoriesProducts
                                .Sum(cp => cp.Product.Price)
                                .ToString("f2")
               })
               .OrderByDescending(c => c.ProductsCount)
               .ToArray();

            return FormatJson(categories);
        }

        //problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null && p.Price != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold
                    .Where(p=>p.Buyer !=null)
                    .Select(sp => new
                    {
                        sp.Name,
                        sp.Price,

                    })
                    .ToArray()

                })
                .OrderByDescending(p => p.SoldProducts.Length)
                .ToArray ();

            var output = new
            {
                UsersCount = users.Length,
                Users = users.Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Length,
                        Products = u.SoldProducts
                    }

                })
            };

            return FormatJson(output);
              
        }





        //метод за форматиране на JSON
        private static string FormatJson(object obj)
        {
            var setings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(obj, setings);
        }
    }
}