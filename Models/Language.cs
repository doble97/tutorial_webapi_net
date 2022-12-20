using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class Language
{
    public int Id { get; set; }

    public string? Language1 { get; set; }

    public string? CodLanguage { get; set; }

    public virtual ICollection<Theme> Themes { get; } = new List<Theme>();
}
