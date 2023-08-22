namespace Api_backend_university;

public partial class Grade
{
    public int Id { get; set; }

    public string? Partial { get; set; }

    public decimal? Grade1 { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
