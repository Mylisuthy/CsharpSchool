using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs;
using School.Application.Interfaces;

namespace School.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService serv)
    {
        _service = serv;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentDto>>> GetAll() =>
        Ok(await _service.AllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentDto>> ById(int id)
    {
        var item = await _service.ByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> Create([FromBody] StudentDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(ById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentDto dto)
    {
        if (dto.Id == null || dto.Id != id) return BadRequest("el Id debe de coincidir con el cuerpo.");
        var ok = await _service.UpdateAsync(dto);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}