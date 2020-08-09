namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.Core.Internal;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;


    public static class Deserializer
    {
        public static string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDTO[] importGames = JsonConvert.DeserializeObject<ImportGameDTO[]>(jsonString);

            List<Game> validGames = new List<Game>();

            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (var importGame in importGames)
            {

                if (!IsValid(importGame))
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }
                ;
                DateTime gameDate;

                bool isGameDateValid = DateTime
                      .TryParseExact(importGame.ReleaseDate,
                      "yyyy-MM-dd",
                      CultureInfo.InvariantCulture,
                      DateTimeStyles.None,
                      out gameDate);

                if (!isGameDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game validGame = new Game
                {
                    Name = importGame.Name,
                    Price = importGame.Price,
                    ReleaseDate = gameDate,
                };


                //•	If a developer/genre/tag with that name doesn’t exist, create it. 

                Developer developer = developers.FirstOrDefault(x => x.Name == importGame.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = importGame.Developer,
                    };
                    developers.Add(developer);


                }
                validGame.Developer = developer;
                developer.Games.Add(validGame);



                Genre genre = genres.FirstOrDefault(x => x.Name == importGame.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = importGame.Genre
                    };

                    genres.Add(genre);

                }
                validGame.Genre = genre;
                genre.Games.Add(validGame);

                foreach (var importTag in importGame.Tags)
                {
                    if (importTag.IsNullOrEmpty())
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    Tag tag = tags.FirstOrDefault(x => x.Name == importTag);
                    GameTag gameTag;
                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = importTag
                        };
                        gameTag = new GameTag
                        {
                            Game = validGame,
                            Tag = tag
                        };
                        tags.Add(tag);
                    }
                    else
                    {
                        gameTag = new GameTag
                        {
                            Game = validGame,
                            Tag = tag
                        };
                    }
                    validGame.GameTags.Add(gameTag);
                }
                if (validGame.Genre == null || validGame.Developer == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!validGame.GameTags.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                validGames.Add(validGame);
                sb.AppendLine($"Added {validGame.Name} ({validGame.Genre.Name}) with {validGame.GameTags.Count} tags");

            }
            context.Games.AddRange(validGames);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDTO[] importUsers = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);

            List<User> validUsers = new List<User>();

            foreach (var importUser in importUsers)
            {
                if (!IsValid(importUser))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User validUser = new User
                {
                    FullName = importUser.FullName,
                    Username = importUser.Username,
                    Email = importUser.Email,
                    Age = importUser.Age
                };

                ;
                foreach (var cardDTO in importUser.Cards)
                {
                    if (!IsValid(cardDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (cardDTO.Type != "Debit" && cardDTO.Type != "Credit")
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Card card = new Card
                    {
                        Number = cardDTO.Number,
                        Cvc = cardDTO.CVC,
                        Type = (CardType)Enum.Parse(typeof(CardType), cardDTO.Type),
                        User = validUser
                    };

                    context.Cards.Add(card);
                    validUser.Cards.Add(card);

                }
                sb.AppendLine($"Imported {validUser.Username} with {validUser.Cards.Count} cards");
                validUsers.Add(validUser);
                context.Users.Add(validUser);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportPurchaseDTO[]), new XmlRootAttribute("Purchases"));

            StringBuilder output = new StringBuilder();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportPurchaseDTO[] purchaseDTOs =
                    (ImportPurchaseDTO[])serializer.Deserialize(stringReader);

                var validPurchases = new List<Purchase>();

                foreach (var purchaseDTO in purchaseDTOs)
                {
                    ;
                    
                    if (!IsValid(purchaseDTO))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    // //“Retail”, “Digital”
                    if (purchaseDTO.Type != "Retail" && purchaseDTO.Type != "Digital")
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Card cardNumber = context.Cards.FirstOrDefault(c => c.Number == purchaseDTO.Card);

                    //User user = context.Users.Where(x => x.Cards.Contains(cardNumber)).FirstOrDefault();

                    //if(user == null)
                    //{
                    //    output.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    if(cardNumber == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime dateTime;
                    

                    bool isOpenDateValid = DateTime
                        .TryParseExact(purchaseDTO.Date,
                        "dd/MM/yyyy HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out dateTime);



                    if (!isOpenDateValid)
                    {
                        output.AppendLine(ErrorMessage);

                        continue;
                    }

                    Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDTO.Title);

                    if(game == null)
                    {
                        output.AppendLine(ErrorMessage);

                        continue;
                    }

                    Purchase validPurchase = new Purchase
                    {
                        Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDTO.Type),
                        ProductKey = purchaseDTO.Key,
                        Card = cardNumber,
                        Date = dateTime,
                        Game = game
                    };

                    validPurchases.Add(validPurchase);
                    output.AppendLine($"Imported {game.Name} for {cardNumber.User.Username}");
                }
                context.Purchases.AddRange(validPurchases);
                context.SaveChanges();

                return output.ToString().TrimEnd();
            }
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}