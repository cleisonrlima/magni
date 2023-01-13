using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{

    private readonly IRepository repo;

    public CourseController(IRepository repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        try
        {
            var response = await repo.getCourses();
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetById(int courseId)
    {

        try
        {
            var response = await repo.getCourseById(courseId);
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }


    [HttpPost]
    public async Task<IActionResult> Save(Course model)
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





    [HttpPut("{courseId}")]
    public async Task<IActionResult> Save(int courseId, Course model)
    {
        try
        {
            var course = await repo.getCourseById(courseId);
            if (course == null) return NotFound();

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


    [HttpDelete("{courseId}")]
    public async Task<IActionResult> Delete(int courseId)
    {
        try
        {
            var course = await repo.getCourseById(courseId);
            if (course == null) return NotFound();

            repo.Delete(course);
            if (await repo.SaveChangesSync())
            {
                return Ok(course);
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
