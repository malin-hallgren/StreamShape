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

            while (true)
            {
                int selection = MenuDriver.Choice(options, "Media Menu");

                switch (selection)
                {
                    case 0:
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 1:
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 2:
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}
