using System;
using System.Collections.Generic;

namespace Api_backend_university;

public partial class Inscription
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool? IsInscribed { get; set; }

    public int? StudentId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
