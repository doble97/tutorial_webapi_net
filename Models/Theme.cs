using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class Theme
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public int? FkUser { get; set; }

    public int? FkLanguage { get; set; }

    public virtual Language? FkLanguageNavigation { get; set; }

    public virtual User? FkUserNavigation { get; set; }

    public virtual ICollection<ThemesWordsSentence> ThemesWordsSentences { get; } = new List<ThemesWordsSentence>();

    public virtual ICollection<ThemesWordsWord> ThemesWordsWords { get; } = new List<ThemesWordsWord>();
}
