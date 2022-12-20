using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class Sentence
{
    public int Id { get; set; }

    public string? Sentence1 { get; set; }

    public string? Translation { get; set; }

    public virtual ICollection<ThemesWordsSentence> ThemesWordsSentences { get; } = new List<ThemesWordsSentence>();
}
