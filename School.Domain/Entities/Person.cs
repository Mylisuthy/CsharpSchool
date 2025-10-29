namespace School.Domain.Entities;

public class Person : Existence
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Document { get; set; }
    public string? Address { get; set; }
    public string? Ocupation { get; set; }
}