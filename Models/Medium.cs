using System;
using System.Collections.Generic;

namespace StreamShape.Models;

public partial class Medium
{
    public int Mediaid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? Releasedate { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public virtual ICollection<Tvshow> Tvshows { get; set; } = new List<Tvshow>();
}
