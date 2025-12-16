using StreamShape.Data;
using StreamShape.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace StreamShape.Utilities
{
    internal class ActorMenu
    {
        private static readonly List<string> options = new List<string>
        {
            "No sort",
            "Sort alphabetically",
            "Sort age",
            "Back to Main Menu"
        };

        public static void Run(StreamShapeDbContext context)
        {
            List<Actor> actors = context.Actors.ToList();

            while (true)
            {
                int selection = MenuDriver.Choice(options, "Media Menu");

                switch (selection)
                {
                    case 0:
                        DisplayActor(actors);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 1:
                        List<Actor> alphaActors = actors.OrderBy(a => a.Name).ToList();
                        DisplayActor(alphaActors);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 2:
                        List<Actor> ageActors = actors.OrderBy(a => a.Birthdate).ToList();
                        DisplayActor(ageActors);
                        MenuDriver.ReturnPrevMenu();
                        break;
                    case 3:
                        return;
                }
            }
        }



        private static void DisplayActor(List<Actor> filterActors)
        {
            foreach (Actor actor in filterActors)
            {
                // Calculate the actor's age if there's a birthdate provided in table
                int age = actor.Birthdate.HasValue ? DateTime.Now.Year - actor.Birthdate.Value.Year : 0;
                Thread.Sleep(100);
                //Console.WriteLine($"{actor.Name} (birthdate: {actor.Birthdate}) {age} y.o.");


                Console.WriteLine($"{actor.Name, -20} {actor.Birthdate, -12} {age} years old");

            }
        }

    }
}
