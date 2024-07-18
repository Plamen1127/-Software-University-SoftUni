namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);  // не е нужно да се пуска на всяко стартиране

            Console.WriteLine(RemoveBooks(db));

           
        }

        // problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                // AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true); //и дата начина парсват
                Enum.TryParse(command, true, out AgeRestriction ageRestriction);


                string[] bookTitles = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception)
            {

                return null;
            }


        }


        // problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] bookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksPrices = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            return string.Join(Environment.NewLine, booksPrices.Select(a => $"{a.Title} - ${a.Price:f2}"));
        }

        // problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, booksNotReleasedIn.Select(a => a.Title));
        }

        // problem 06

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);



            var booksByCategory = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, booksByCategory);

        }

        // problem 07 

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleasedBefore = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, booksReleasedBefore);
        }

        // problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNamesEndingIn = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName

                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            return string.Join(Environment.NewLine, authorNamesEndingIn.Select(a => $"{a.FirstName} {a.LastName}"));


        }

        // problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitlesContaining = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(a => a.Title)
                .OrderBy(b => b);

            return string.Join(Environment.NewLine, bookTitlesContaining);
        }

        // problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName,
                    b.BookId
                })
                .OrderBy(b => b.BookId);

            return string.Join(Environment.NewLine, booksByAuthor.Select(a => $"{a.Title} ({a.FirstName} {a.LastName})"));
        }

        // problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck);

            return countBooks.Count();

        }

        // problem 12

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesByAuthor = context.Authors
            .OrderByDescending(a => a.Books.Sum(b => b.Copies))
            .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
            .ToArray();

            return string.Join(Environment.NewLine, copiesByAuthor);
        }

        // problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitsByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    totalProfit = c.CategoryBooks.Select(cb => cb.Book.Price * cb.Book.Copies).Sum()

                })
                .OrderByDescending(c => c.totalProfit)
                .ThenBy(c => c.Name)
                .ToArray();

            return string.Join(Environment.NewLine, totalProfitsByCategory.Select(c => $"{c.Name} ${c.totalProfit:f2}"));
        }

        // problem 14

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    books = c.CategoryBooks.Select(cb => cb.Book)
                    .OrderByDescending(c => c.ReleaseDate)
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in mostRecentBooks)
            {
                sb.AppendLine($"--{book.Name}");
                foreach (var b in book.books)
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
               .ToList();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
            

        }

        // problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int countBookForRemuve = books.Count();

            context.RemoveRange(books);
            context.SaveChanges();

            return countBookForRemuve;
        }
    }
}


