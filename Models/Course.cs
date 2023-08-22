using System;
using System.Collections.Generic;

namespace Api_backend_university;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? EventId { get; set; }

    public int Semester { get; set; }

    public virtual ICollection<Assist> Assists { get; set; } = new List<Assist>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Event? Event { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
