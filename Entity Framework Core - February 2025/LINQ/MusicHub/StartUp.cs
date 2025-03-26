namespace MusicHub
{
    using System;
    using System.Text;
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

            //Test your solutions here
            Console.WriteLine(ExportAlbumsInfo(context,9));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var albumsInfo = context
                .Producers.First(x => x.Id == producerId)
                .Albums.Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriterName = s.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.SongWriterName),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;

                if (album.Songs.Any())
                {

                    

                    foreach (var song in album.Songs)
                    {
                        sb.AppendLine($"---#{counter++}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.SongPrice:f2}");
                        sb.AppendLine($"---Writer: {song.SongWriterName}");
                    }

                    sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");

                }


            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
