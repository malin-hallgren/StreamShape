using System.Security.Cryptography;
using StreamShape.Data;
using StreamShape.Models;

namespace StreamShape.Utilities
{
    internal class MediaMenu
    {
        private static readonly List<string> options = new List<string>
        {
            "All Media",
            "TV-Series",
            "Movies",
            "Back to Main Menu"
        };

        public static void Run(StreamShapeDbContext context)
        {
            List<Medium> media = context.Media.ToList();
            List<Movie> movies = context.Movies.ToList();
            List<Tvshow> tvshows = context.Tvshows.ToList();

            while (true)
            {
                int selection = MenuDriver.Choice(options, "Media Menu");

                switch (selection)
                {
                    case 0:
                        DisplayMedia(media);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 1:
                        List<Medium> tvshowMedia = FilterTVShows(media, tvshows);
                        DisplayMedia(tvshowMedia);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 2:
                        List<Medium> movieMedia = FilterMovies(media, movies);
                        DisplayMedia(movieMedia);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private static List<Medium> FilterTVShows(List<Medium> media, List<Tvshow> tvshows)
        {
            return media.Where(m => tvshows.Any(tv => tv.Mediaid == m.Mediaid)).ToList();
        }

        private static List<Medium> FilterMovies(List<Medium> media, List<Movie> movies)
        {
            return media.Where(m => movies.Any(mo => mo.Mediaid == m.Mediaid)).ToList();
        } 

        private static void DisplayMedia(List<Medium> filteredMedia)
        {
            foreach (Medium medium in filteredMedia)
            {
                Thread.Sleep(100);
                Console.WriteLine($"{medium.Title, -20} ({medium.Releasedate?.Year})");
            }
        }
    }
}
