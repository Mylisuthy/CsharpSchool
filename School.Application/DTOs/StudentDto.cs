namespace School.Application.DTOs;

public class StudentDto
{
    // Id is null on create, Use that with Update and delete
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Document { get; set; }
    public string? Address { get; set; }
    
    public string? Grade { get; set; }
}