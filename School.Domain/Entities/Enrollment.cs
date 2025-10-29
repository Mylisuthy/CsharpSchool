namespace School.Domain.Entities;

public class Enrollment
{
     public int StudentId { get; set; }
     public Student? Students { get; set; }
     
     public int CourseId { get; set; }
     public Course? Course { get; set; }
}