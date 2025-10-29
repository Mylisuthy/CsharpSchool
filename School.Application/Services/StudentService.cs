using School.Application.DTOs;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Domain.Interfaces;

namespace School.Application.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _repo;

    public StudentService(IRepository<Student> repo)
    {
        _repo = repo;
    }

    public async Task<List<StudentDto>> AllAsync()
    {
        var list = await _repo.All();
        return list.Select(ToDto).ToList();
    }

    public async Task<StudentDto?> ByIdAsync(int id)
    {
        var search = await _repo.ById(id);
        if (search == null) return null;
        return ToDto(search);
    }

    public async Task<StudentDto> CreateAsync(StudentDto dto)
    {
        var entity = ToEntity(dto);
        await _repo.Create(entity);
        await _repo.Save();
        return ToDto(entity);
    }

    public async Task<bool> UpdateAsync(StudentDto dto)
    {
        if (dto.Id == null) return false;

        var exist = await _repo.ById(dto.Id.Value);
        if (exist == null) return false;
        
        exist.Name = dto.Name;
        exist.Age = dto.Age;
        exist.Email = dto.Email;
        exist.Phone = dto.Phone;
        exist.Document = dto.Document;
        exist.Address = dto.Address;
        exist.Grade = dto.Grade;
        
        await _repo.Update(exist);
        await _repo.Save();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ok = await _repo.Delete(id);
        if (!ok) return false;
        await _repo.Save();
        return true;
    }
    
    // Dtos maping
    private static StudentDto ToDto(Student s) => new StudentDto
    {
        Id = s.Id,
        Name = s.Name,
        Age = s.Age,
        Email = s.Email,
        Phone = s.Phone,
        Document = s.Document,
        Address = s.Address,
        Grade = s.Grade
    };

    private static Student ToEntity(StudentDto dto) => new Student
    {
        // auto detect Id
        Id = dto.Id ?? 0,
        Name = dto.Name,
        Age = dto.Age,
        Email = dto.Email,
        Phone = dto.Phone,
        Document = dto.Document,
        Address = dto.Address,
        Grade = dto.Grade
    };
}