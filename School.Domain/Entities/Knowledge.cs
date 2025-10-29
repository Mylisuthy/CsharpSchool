namespace School.Domain.Entities;

public abstract class Knowledge
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Sector { get; set; }
    public string? Level { get; set; }
}