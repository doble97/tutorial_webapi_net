using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class ThemesWordsSentence
{
    public int FkTheme { get; set; }

    public int FkSentence { get; set; }

    public int FkWord { get; set; }

    public virtual Sentence FkSentenceNavigation { get; set; } = null!;

    public virtual Theme FkThemeNavigation { get; set; } = null!;

    public virtual Word FkWordNavigation { get; set; } = null!;
}
