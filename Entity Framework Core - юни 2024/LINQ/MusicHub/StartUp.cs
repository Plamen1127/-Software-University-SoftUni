namespace MusicHub
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.ExceptionServices;
    using System.Text;
    using System.Xml.Linq;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            ;
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        WriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.WriterName)
                    .ToList(),
                    TotalAlbumPrice = a.Songs.Sum(s => s.Price)
                })
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                int songNumber = 0;

                foreach (var s in a.Songs)
                {
                    songNumber++;

                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price:f2}");
                    sb.AppendLine($"---Writer: {s.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {a.TotalAlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsInfo = context.Songs
                .AsEnumerable()
                 .Where(s => s.Duration.TotalSeconds > duration)
                 .Select(s => new
                 {
                     s.Name,
                     Preformers = s.SongPerformers
                                .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                .OrderBy(p => p)
                                .ToList(),
                     WriterName = s.Writer.Name,
                     AlbumProducerName = s.Album!.Producer!.Name,
                     Duration = s.Duration
                                .ToString("c")
                 })
                 .OrderBy(s => s.Name)
                 .ThenBy(s => s.WriterName)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            int songNumber = 0;

            foreach (var s in songsInfo)
            {
                songNumber++;

                sb.AppendLine($"-Song #{songNumber}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Writer: {s.WriterName}");


                foreach (var p in s.Preformers)
                {
                    sb.AppendLine($"---Performer: {p}");
                }


                sb.AppendLine($"---AlbumProducer: {s.AlbumProducerName}");
                sb.AppendLine($"---Duration: {s.Duration}");

            }

            return sb.ToString().TrimEnd();

        }
    }
}
