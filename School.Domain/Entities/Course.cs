namespace School.Domain.Entities;

public class Course : Knowledge
{
    public string? Description { get; set; }
    public int ModuleCuantities { get; set; }
    
    public int ProfessorId { get; set; }
    public Professor? Professor { get; set; }
    
    public List<Enrollment>? Enrollments { get; set; }
}