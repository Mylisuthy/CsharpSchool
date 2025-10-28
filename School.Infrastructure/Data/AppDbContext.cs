using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Professor> Professors => Set<Professor>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Configurar herencia TPC (Table-Per-Concrete-Type)

        modelBuilder.Entity<Student>().UseTpcMappingStrategy();
        modelBuilder.Entity<Professor>().UseTpcMappingStrategy();


        // Student

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");
            entity.Property(s => s.Grade).HasMaxLength(50);
        });


        // Professor

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.ToTable("Professors");
            entity.Property(p => p.Specialisation).HasMaxLength(100);
            entity.HasMany(p => p.Courses)
                  .WithOne(c => c.Professor)
                  .HasForeignKey(c => c.ProfessorId)
                  .OnDelete(DeleteBehavior.Restrict);
        });


        // Course

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Courses");
            entity.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        });


        // Enrollment

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollments");
            entity.HasKey(e => new { e.StudentId, e.CourseId });

            entity.HasOne(e => e.Students)
                  .WithMany(s => s.Enrollments)
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Course)
                  .WithMany(c => c.Enrollments)
                  .HasForeignKey(e => e.CourseId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
