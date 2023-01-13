using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{

    private readonly IRepository repo;

    public StudentController(IRepository repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        try
        {
            var response = await repo.getAllStudents(true);
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetById(int studentId)
    {

        try
        {
            var response = await repo.getStudentById(studentId, true);
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }



 [HttpGet("{courseId}/course")]
    public async Task<IActionResult> GetByCourseId(int courseId)
    {

        try
        {
            var response = await repo.getStudentsGradeByCourseId(courseId, true);
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }



    [HttpPost]
    public async Task<IActionResult> Save(Student model)
    {
        try
        {
            model.registrationNumber = Get8CharacterRandomString();
            repo.Add(model);
            if (await repo.SaveChangesSync())
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }

        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }


    [HttpPut("{studentId}")]
    public async Task<IActionResult> Save(int studentId, Student model)
    {
        try
        {
            var student = await repo.getStudentById(studentId, false);
            if (student == null) return NotFound();

            repo.Update(model);
            if (await repo.SaveChangesSync())
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }

        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }


    [HttpDelete("{studentId}")]
    public async Task<IActionResult> Delete(int studentId)
    {
        try
        {
            var student = await repo.getStudentById(studentId, false);
            if (student == null) return NotFound();

            repo.Delete(student);
            if (await repo.SaveChangesSync())
            {
                return Ok(student);
            }
            else
            {
                return BadRequest();
            }

        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }


[ApiExplorerSettings(IgnoreApi = true)]
    public string Get8CharacterRandomString()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", ""); // Remove period.
        return path.Substring(0, 8).ToUpper();  // Return 8 character string
    }
}
