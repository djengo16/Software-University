namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportBookDTO[]), new XmlRootAttribute("Books"));

            StringBuilder output = new StringBuilder();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportBookDTO[] bookDTOs =
                    (ImportBookDTO[])serializer.Deserialize(stringReader);

                List<Book> books = new List<Book>();
                
                foreach (var book in bookDTOs)
                {
                    if (!IsValid(book))
                    {
                        output.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        DateTime publishedOn;
                        bool isDateValid = DateTime
                            .TryParseExact(book.PublishedOn,
                            "MM/dd/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out publishedOn);
                        if (!isDateValid)
                        {
                            output.AppendLine(ErrorMessage);
                        }
                        else
                        {
                            Book validBook = new Book
                            {
                                Name = book.Name,
                                Genre = (Genre)book.Genre,
                                Pages = book.Pages,
                                Price = book.Price,
                                PublishedOn = publishedOn
                            };

                            books.Add(validBook);

                            output.AppendLine(String.Format
                                (SuccessfullyImportedBook, validBook.Name, validBook.Price));
                        }
                    }
                }
                
                context.Books.AddRange(books);
                context.SaveChanges();
            }
            return output.ToString().TrimEnd();

        }


        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportAuthorDTO[] importAuthors = JsonConvert.DeserializeObject<ImportAuthorDTO[]>(jsonString);

            List<Author> validAuthors = new List<Author>();
            List<AuthorBook> validAuthorBooks = new List<AuthorBook>();
            
            
            foreach (var importedAuthor in importAuthors)
            {
                if (!IsValid(importedAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var AuthorEmailExist = context.Authors.FirstOrDefault(x => x.Email == importedAuthor.Email);

                if(AuthorEmailExist != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = importedAuthor.FirstName,
                    LastName = importedAuthor.LastName,
                    Email = importedAuthor.Email,
                    Phone = importedAuthor.Phone
                };

                

                foreach (var book in importedAuthor.Books)
                {
                    var checkBook = context.Books.FirstOrDefault(x => x.Id == book.Id);
                    if (!(checkBook == null))
                    {
                       
                        var authorBook = new AuthorBook
                        {
                            BookId = (int)book.Id,
                            Book = context.Books.FirstOrDefault(x => x.Id == book.Id),
                            Author = author
                        };
                        author.AuthorsBooks.Add(authorBook);
                    }
                }
                if (!author.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                sb.AppendLine(String.Format
                    (SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
                context.Authors.Add(author);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}