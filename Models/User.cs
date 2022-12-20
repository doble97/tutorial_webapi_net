using System;
using System.Collections.Generic;

namespace tutorial.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<Theme> Themes { get; } = new List<Theme>();
}
