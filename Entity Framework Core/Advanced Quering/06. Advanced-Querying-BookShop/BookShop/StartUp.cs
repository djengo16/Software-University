namespace BookShop
{
    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            // int lenghtCheck = int.Parse(Console.ReadLine());
           // DbInitializer.ResetDatabase(db);
            Console.WriteLine(RemoveBooks(db));

           // Console.WriteLine(result);
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(booksToRemove);
            int affectedRows = context.SaveChanges();

            return booksToRemove.Count;
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var results = context.Categories
                            .Select(group =>
                            new
                            {
                                CategoryName = group.Name,
                                Books = group.CategoryBooks.OrderByDescending(b => b.Book.ReleaseDate)
                                .Select(b => new
                                {
                                    b.Book.Title,
                                    b.Book.ReleaseDate
                                })
                                .Take(3).ToList()
                            })
                            .OrderBy(c => c.CategoryName)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in results)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {


            var categories = context.Categories
             .Select(c => new
             {
                 Name = c.Name,
                 TotalProfit = c.CategoryBooks.Sum(e => e.Book.Price * e.Book.Copies)
             })
             .OrderByDescending(b => b.TotalProfit)
                .ThenBy(b => b.Name)
                .ToList(); ;



            return String.Join(Environment.NewLine, categories.Select(x => $"{x.Name} ${x.TotalProfit:F2}"));
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //Return the total number of book copies for each author. Order the results descending by total book copies.

            var authors = context.Authors
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CopiesCount)
                .ToList();

            return String.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName} - {a.CopiesCount}"));
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();
        }
        public static string GetBooksByAuthor(BookShopContext context, string stringValue)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(stringValue.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Fullname = b.Author.FirstName + " " + b.Author.LastName,
                    BookTitle = b.Title
                })
                .ToList();

            return String.Join(Environment.NewLine, books.Select(x =>
              $"{x.BookTitle} ({x.Fullname})"));
        }
        public static string GetBookTitlesContaining(BookShopContext context, string stringValue)
        {


            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(stringValue.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            return String.Join(Environment.NewLine, authors.Select(a => a.FullName));
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();
            var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);



            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();



            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Price,
                    b.Title
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext bookShopContext)
        {
            //Return in a single string titles of the golden edition 
            //    books that have less than 5000 copies, each on a new line.Order them by book id ascending.

            var goldenBooks = bookShopContext.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, goldenBooks);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context.Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower()
                == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
