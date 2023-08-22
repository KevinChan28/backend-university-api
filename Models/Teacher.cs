namespace Api_backend_university;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual User? User { get; set; }
}
