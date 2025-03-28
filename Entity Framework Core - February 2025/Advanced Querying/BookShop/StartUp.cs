namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(GetBooksByAgeRestriction(context, "miNor")); //problem 2
           // Console.WriteLine(GetGoldenBooks(context));//
           Console.WriteLine(GetBooksNotReleasedIn(context, 2000));//

        }

        //problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return string.Empty;
            }


            var bookTitles = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(b => b)
                .ToList();


            return string.Join(Environment.NewLine, bookTitles);
        }


        //problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {

            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();



            return string.Join(Environment.NewLine, goldenBooks);
        }

        //problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTaitle = b.Title,
                    BookPrice = b.Price,
                })
                .OrderByDescending(b=>b.BookPrice) 
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books) 
            {
                sb.AppendLine($"{book.BookTaitle} - ${book.BookPrice:f2}");
            }



            return sb.ToString().TrimEnd();
        }

        //problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b=>b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b=> new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b=>b.BookId)
                .ToList();


            return string.Join(Environment.NewLine, books.Select(b=>b.Title));
        }

    }
}


