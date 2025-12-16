using System;
using System.Collections.Generic;

namespace StreamShape.Models;

public partial class Movie
{
    public int Movieid { get; set; }

    public int Mediaid { get; set; }

    public virtual Medium Media { get; set; } = null!;

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}
