using Ghaddoura_Imran_Project.Models;
using Ghaddoura_Imran_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

namespace Ghaddoura_Imran_Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentsService studentsService) : ControllerBase
{

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetSingleStudentDetails(Guid id)
    {
        var student = await studentsService.GetSingleStudentDetails(id);
        if (student is null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllStudents()
    {
        var students = await studentsService.GetAllStudents();

        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult> AddStudent([FromBody] Student student)
    {
        await studentsService.AddStudent(student);
        return CreatedAtAction(nameof(GetSingleStudentDetails), new { id = student.Id }, student);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateStudent([FromBody] Student item, [FromRoute] Guid id)
    {
        if (item.Id != id)
        {
            return BadRequest();
        }

        var student = await studentsService.UpdateStudent(item);

        if (student is null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteStudent(Guid id)
    {
        var student = await GetSingleStudentDetails(id);
        if (student is null)
        {
            return NotFound();
        }
        await studentsService.DeleteStudent(id);
        return NoContent();
    }
}
