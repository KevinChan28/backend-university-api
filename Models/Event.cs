using System;
using System.Collections.Generic;

namespace Api_backend_university;

public partial class Event
{
    public int Id { get; set; }

    public DateTime CratedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
