using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TodoAPI.Models;

public partial class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateOnly DueDate { get; set; }

    public TimeOnly DueTime { get; set; }

    public virtual Category Category { get; set; } = null!;
}
