namespace Api_backend_university;

public partial class Assist
{
    public int Id { get; set; }

    public DateTime? DateAssist { get; set; }

    public DateTime EndTime { get; set; }

    public string Days { get; set; } = null!;

    public int? CourseId { get; set; }

    public int? StudentId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
