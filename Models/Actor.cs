using System;
using System.Collections.Generic;

namespace StreamShape.Models;

public partial class Actor
{
    public int Actorid { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<EpisodeActor> EpisodeActors { get; set; } = new List<EpisodeActor>();

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}
