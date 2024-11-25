using System;
using System.Collections.Generic;

namespace TodoAPI.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
