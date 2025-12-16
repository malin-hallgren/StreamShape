using System;
using System.Collections.Generic;

namespace StreamShape.Models;

public partial class Tvshow
{
    public int Showid { get; set; }

    public int Mediaid { get; set; }

    public int? Seasoncount { get; set; }

    public int? Episodecount { get; set; }

    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    public virtual Medium Media { get; set; } = null!;
}
