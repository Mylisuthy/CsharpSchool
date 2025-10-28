namespace School.Domain.Entities;

public class Professor : Person
{
    public string? Specialisation { get; set; }
    public List<Course>? Courses { get; set; }
}