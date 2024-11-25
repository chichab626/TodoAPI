using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TodoAPI.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public bool IsDefault { get; set; }

    [JsonIgnore]
    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
