namespace Api_backend_university.DTO
{
    public class StudentsWithCareer
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? Telephone { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? CareerId { get; set; }

        public int? UserId { get; set; }

        public virtual CareerInformation? Career { get; set; }
    }
}
