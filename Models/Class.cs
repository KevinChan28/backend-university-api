using System;
using System.Collections.Generic;
using System.Timers;

namespace Api_backend_university;

public partial class Class
{
    public int Id { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Days { get; set; } = null!;

    public int CourseId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    public virtual Teacher? Teacher { get; set; }
}
