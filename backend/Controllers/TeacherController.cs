using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{


    private readonly IRepository repo;

    public TeacherController(IRepository repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        try
        {
            var response = await repo.getTeachers();
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("{teacherId}")]
    public async Task<IActionResult> GetById(int teacherId)
    {

        try
        {
            var response = await repo.getTeacherById(teacherId);
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }


    [HttpPost]
    public async Task<IActionResult> Save(Teacher model)
    {
        try
        {
            repo.Add(model);
            if (await repo.SaveChangesSync())
            {
                return Ok();
            }else{
                 return BadRequest();
            }

        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }




    [HttpPut("{teacherId}")]
    public async Task<IActionResult> Update(int teacherId, Teacher model)
    {
        try
        {
            var teacher = await repo.getTeacherById(teacherId);
            if (teacher == null) return NotFound();

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


    [HttpDelete("{teacherId}")]
    public async Task<IActionResult> Delete(int teacherId)
    {
        try
        {
            var teacher = await repo.getTeacherById(teacherId);
            if (teacher == null) return NotFound();

            repo.Delete(teacher);
            if (await repo.SaveChangesSync())
            {
                return Ok(teacher);
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
    
}
