using System;
using System.Collections.Generic;

namespace TodoAPI.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Color { get; set; }
}
