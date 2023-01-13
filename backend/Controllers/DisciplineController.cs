using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplineController : ControllerBase
{

    private readonly IRepository repo;

    public DisciplineController(IRepository repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        try
        {
            var response = await repo.getDisciplines();
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("{disciplineId}")]
    public async Task<IActionResult> GetById(int disciplineId)
    {

        try
        {
            var response = await repo.getDisciplineById(disciplineId);
            return Ok(response);
        }
        catch (System.Exception ex)
        {

            return BadRequest($"Error: {ex.Message}");
        }
    }



   



    [HttpPost]
    public async Task<IActionResult> Save(Discipline model)
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




    [HttpPut("{disciplineId}")]
    public async Task<IActionResult> Update(int disciplineId, Course model)
    {
        try
        {
            var course = await repo.getDisciplineById(disciplineId);
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


    [HttpDelete("{disciplineId}")]
    public async Task<IActionResult> Delete(int disciplineId)
    {
        try
        {
            var course = await repo.getDisciplineById(disciplineId);
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
