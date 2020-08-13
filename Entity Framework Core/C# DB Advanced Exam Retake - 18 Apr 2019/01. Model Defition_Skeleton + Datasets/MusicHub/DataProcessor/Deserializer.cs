namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportWriterDTO[] writersDTO = JsonConvert.DeserializeObject<ImportWriterDTO[]>(jsonString);

            List<Writer> validWriters = new List<Writer>();

            foreach (var writerDTO in writersDTO)
            {
                if (!IsValid(writerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validWriters.Add(new Writer
                {
                    Name = writerDTO.Name,
                    Pseudonym = writerDTO.Pseudonym
                });

                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writerDTO.Name));
            }
            context.Writers.AddRange(validWriters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportProducerDTO[] producersDTO = JsonConvert.DeserializeObject<ImportProducerDTO[]>(jsonString);

            List<Producer> validProducers = new List<Producer>();

            foreach (var producerDTO in producersDTO)
            {
                if (!IsValid(producerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Producer producer = new Producer
                {
                    Name = producerDTO.Name,
                    Pseudonym = producerDTO.Pseudonym,
                    PhoneNumber = producerDTO.PhoneNumber
                };

                bool isAllAlbumsValid = true;

                List<Album> albums = new List<Album>();


                foreach (var albumDTO in producerDTO.Albums)
                {
                    if (!IsValid(albumDTO))
                    {
                        isAllAlbumsValid = false;
                        continue;
                    }

                    DateTime releaseDate;

                    bool isReleaseDateValid = DateTime
                     .TryParseExact(albumDTO.ReleaseDate,
                     "dd/MM/yyyy",
                     CultureInfo.InvariantCulture,
                     DateTimeStyles.None,
                     out releaseDate);

                    if (!isReleaseDateValid)
                    {
                        isAllAlbumsValid = false;
                        continue;
                    }

                    albums.Add(new Album
                    {
                        Name = albumDTO.Name,
                        ReleaseDate = releaseDate,
                        Producer = producer
                    });
                }
                if (!isAllAlbumsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                producer.Albums = albums;
                validProducers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }

            }

            context.Producers.AddRange(validProducers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportSongDTO[]), new XmlRootAttribute("Songs"));

            StringBuilder output = new StringBuilder();

            List<string> validGenres = new List<string>
            { "Blues", "Rap", "PopMusic", "Rock", "Jazz" };

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportSongDTO[] songsDTO =
                    (ImportSongDTO[])serializer.Deserialize(stringReader);

                var validSongs = new List<Song>();

                foreach (var songDTO in songsDTO)
                {
                    if (!IsValid(songDTO))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!validGenres.Contains(songDTO.Genre))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Writer writer = context.Writers.FirstOrDefault(x => x.Id == songDTO.WriterId);

                    if (writer == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Album album = context.Albums.FirstOrDefault(x => x.Id == songDTO.AlbumId);

                    if (album == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Song song = new Song
                    {
                        Name = songDTO.Name,
                        Duration = TimeSpan.ParseExact(songDTO.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture),
                        CreatedOn = DateTime.ParseExact(songDTO.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Genre = (Genre)Enum.Parse(typeof(Genre), songDTO.Genre),
                        Album = album,
                        Writer = writer,
                        Price = songDTO.Price
                    };

                    validSongs.Add(song);

                    output.AppendLine(String.Format(SuccessfullyImportedSong, songDTO.Name, songDTO.Genre, songDTO.Duration));

                }
                context.Songs.AddRange(validSongs);
                context.SaveChanges();

                return output.ToString().TrimEnd();
            }
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportSongPerformerDTO[]), new XmlRootAttribute("Performers"));

            StringBuilder output = new StringBuilder();



            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportSongPerformerDTO[] performersDTO =
                    (ImportSongPerformerDTO[])serializer.Deserialize(stringReader);

                var validPerformers = new List<Performer>();

                foreach (var performerDTO in performersDTO)
                {
                    if (!IsValid(performerDTO))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Performer performer = new Performer
                    {
                        FirstName = performerDTO.FirstName,
                        LastName = performerDTO.LastName,
                        Age = performerDTO.Age,
                        NetWorth = performerDTO.NetWorth
                    };
                    bool isAllSongsValid = true;

                    foreach (var songIdDTO in performerDTO.PerformersSongs)
                    {
                        Song song = context.Songs.FirstOrDefault(x => x.Id == songIdDTO.Id);

                        if (song == null)
                        {
                            isAllSongsValid = false;
                            continue;
                        }

                        performer.PerformerSongs.Add(new SongPerformer
                        {
                            Performer = performer,
                            SongId = song.Id,
                            Song = song
                        });
                    }

                    if (!isAllSongsValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    validPerformers.Add(performer);

                    output.AppendLine(String.Format(SuccessfullyImportedPerformer, performer.FirstName,
                        performer.PerformerSongs.Count));
                }

                context.Performers.AddRange(validPerformers);
                context.SaveChanges();

            }


            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)

        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}