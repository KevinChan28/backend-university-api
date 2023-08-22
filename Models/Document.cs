using System;
using System.Collections.Generic;

namespace Api_backend_university;

public partial class Document
{
    public int Id { get; set; }

    public string NameDocument { get; set; } = null!;

    public DateTime DeliveredDate { get; set; }

    public int UserId { get; set; }

    public string? Path { get; set; }

    public virtual User User { get; set; } = null!;
}
