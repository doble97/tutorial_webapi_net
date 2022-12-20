using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class Word
{
    public int Id { get; set; }

    public string? Word1 { get; set; }

    public virtual ICollection<ThemesWordsSentence> ThemesWordsSentences { get; } = new List<ThemesWordsSentence>();

    public virtual ICollection<ThemesWordsWord> ThemesWordsWordFkWord1Navigations { get; } = new List<ThemesWordsWord>();

    public virtual ICollection<ThemesWordsWord> ThemesWordsWordFkWord2Navigations { get; } = new List<ThemesWordsWord>();
}
