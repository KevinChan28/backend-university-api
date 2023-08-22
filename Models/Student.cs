using System;
using System.Collections.Generic;

namespace Api_backend_university;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public int? CareerId { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Assist> Assists { get; set; } = new List<Assist>();

    public virtual Career? Career { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    public virtual User? User { get; set; }
}
