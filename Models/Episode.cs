using System;
using System.Collections.Generic;

namespace StreamShape.Models;

public partial class Episode
{
    public int Episodeid { get; set; }

    public int Showid { get; set; }

    public int Episodenummer { get; set; }

    public string? Episodetitle { get; set; }

    public DateOnly? Releasedate { get; set; }

    public virtual ICollection<EpisodeActor> EpisodeActors { get; set; } = new List<EpisodeActor>();

    public virtual Tvshow Show { get; set; } = null!;
}
