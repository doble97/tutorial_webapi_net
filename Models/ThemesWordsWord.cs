using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class ThemesWordsWord
{
    public int FkThemes { get; set; }

    public int FkWord1 { get; set; }

    public int FkWord2 { get; set; }

    public virtual Theme FkThemesNavigation { get; set; } = null!;

    public virtual Word FkWord1Navigation { get; set; } = null!;

    public virtual Word FkWord2Navigation { get; set; } = null!;
}
