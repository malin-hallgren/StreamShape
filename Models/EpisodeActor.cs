using System;
using System.Collections.Generic;

namespace StreamShape.Models;

public partial class EpisodeActor
{
    public int Episodeid { get; set; }

    public int Actorid { get; set; }

    public string? Role { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual Episode Episode { get; set; } = null!;
}
