using School.Application.DTOs;
using School.Domain.Entities;

namespace School.Application.Interfaces;

public interface IStudentService : IGenericService<Student, StudentDto>
{
    // to specific metods Student
}