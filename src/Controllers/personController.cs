using formAPI.src.Models;
using formAPI.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace formAPI.src.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase
{
    private readonly PersonService _service;
    
    public PersonController(AppDBContext appDBContext){
        _service = new PersonService(appDBContext);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPerson(){
        try{
            return Ok(new {
                sucess = true,
                data = await _service.GetAll()
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Erro: {e.Message}; Tipo: {e.GetType()}.");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        } 
    }

    [HttpGet("find/{id}")]
    public async Task<IActionResult> GetPersonById(Guid id){
        try{
            var _person = await _service.GetById(id);

            if(_person == null){
                return NotFound(new {
                    sucess = true,
                    data = "Person not found"
                });
            }

            return Ok(new {
                sucess = true,
                data = _person
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Erro: {e.Message}; Tipo: {e.GetType()}.");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpGet("find/c/{cpf}")]
    public async Task<IActionResult> GetPersonByCPF(string cpf){
        try{
            var _person = await _service.GetByCPF(cpf);

            if(_person == null){
                return NotFound(new {
                    sucess = true,
                    data = "Person not found"
                });
            }

            return Ok(new {
                sucess = true,
                data = _person
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Erro: {e.Message}; Tipo: {e.GetType()}.");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpPost("new")]
    public async Task<IActionResult> RegisterPerson(Person person){
        try{
            await _service.Create(person);
            return await Task.FromResult(CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person));
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Erro: {e.Message}; Tipo: {e.GetType()}.");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> ChangePerson(Person person, Guid id){
        try{
            var _person = await _service.GetById(id);
        
            if(_person == null){
                return NotFound(new {
                    sucess = true,
                    data = "Person not found"
                });
            }

            return Ok(new {
                sucess = true,
                data = await _service.Update(person, id)
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Erro: {e.Message}; Tipo: {e.GetType()}.");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id){
        try{
            var _person = await _service.GetById(id);
        
            if(_person == null){
                return NotFound(new {
                    sucess = true,
                    data = "Person not found"
                });
            }

            return Ok(new {
                sucess = true,
                data = await _service.Delete(id)
            });
        }
        catch(Exception e){
            System.Console.WriteLine($"\nFalhou. Erro: {e.Message}; Tipo: {e.GetType()}.");
            return StatusCode(500, new { success = false, message = $"Internal error. Details: {e.Message}"});
        }
    }

}
