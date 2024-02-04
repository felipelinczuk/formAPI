using formAPI.src.Models;
using Microsoft.EntityFrameworkCore;

namespace formAPI.src.Services;

public class PersonService
{
    private readonly AppDBContext _appDBContext;

    public PersonService(AppDBContext appDBContext){
         _appDBContext = appDBContext;
    }

    public async Task<List<Person>> GetAll(){
        return await _appDBContext.People.Where(p => p.DeletedAt == null).ToListAsync();
    }

    public async Task<Person?> GetById(Guid id){
        return await _appDBContext.People.Where(p => p.Id == id && p.DeletedAt == null).FirstOrDefaultAsync();
    }

    public async Task Create(Person person){
        _appDBContext.People.Add(person);
        await _appDBContext.SaveChangesAsync();
    }

    public async Task<Person> Update(Person person, Guid id){
        var _person = _appDBContext.People.SingleOrDefault(p => p.Id == id);
        
        _person!.Name = person.Name;
        _person.CPF = person.CPF;
        _person.BirthDate = person.BirthDate;
        _person.MonthlyIncome = person.MonthlyIncome;

        await _appDBContext.SaveChangesAsync();

        return _person;
    }

    public async Task<Person> Delete(Guid id){
        var _person = _appDBContext.People.SingleOrDefault(p => p.Id == id);

        _person!.DeletePerson();
        
        await _appDBContext.SaveChangesAsync();

        return _person;
    }
}
