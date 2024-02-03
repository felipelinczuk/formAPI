using formAPI.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace formAPI.src.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase
{
    private readonly AppDBContext _appDBContext;
    
    public PersonController(AppDBContext appDBContext){
        _appDBContext = appDBContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPerson(){
        try{
            return Ok(new {
                sucess = true,
                data = await _appDBContext.People.ToListAsync()
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Tipo: {e.GetType()} Erro: {e.Message}");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        } 
    }

    [HttpGet("find/{id}")]
    public async Task<IActionResult> GetPersonById(Guid id){
        try{
            return Ok(new {
                sucess = true,
                //data = await
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Tipo: {e.GetType()} Erro: {e.Message}");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpPost("new")]
    public async Task<IActionResult> RegisterPerson(Person person){
        try{
            _appDBContext.People.Add(person);
            await _appDBContext.SaveChangesAsync();
            return await Task.FromResult(CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person));
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Tipo: {e.GetType()} Erro: {e.Message}");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> ChangePerson(Guid id){
        try{
            return Ok(new {
                sucess = true,
                //data = await
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Tipo: {e.GetType()} Erro: {e.Message}");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id){
        try{
            return Ok(new {
                sucess = true,
                //data = await
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Tipo: {e.GetType()} Erro: {e.Message}");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

}
