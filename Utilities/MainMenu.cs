using System;
using System.Collections.Generic;
using System.Text;
using StreamShape.Data;

namespace StreamShape.Utilities
{
    internal class MainMenu
    {
        private static readonly List<string> options = new List<string>
        {
            "Media View",
            "Actor View",
            "Add to Database",
            "Exit"
        };

        public static void Run()
        {
            using var context = new StreamShapeDbContext();


            while(true)
            {
                int selection = MenuDriver.Choice(options, "Main Menu");

                switch(selection)
                {
                    case 0:
                        List<string> mediaTypes = new List<string> { "Movies", "TV-Series", "Back" };
                        MediaMenu.Run(context);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 1:
                        ActorMenu.Run(context);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 2:
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
