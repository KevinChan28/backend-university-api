using System;
using System.Collections.Generic;

namespace Api_backend_university;

public partial class Career
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
