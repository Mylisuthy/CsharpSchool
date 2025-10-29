namespace School.Domain.Entities;

public class Student : Person
{
    public string? Grade { get; set; }
    public List<Enrollment>? Enrollments { get; set; }
}