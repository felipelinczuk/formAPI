namespace formAPI.src.Models;

public class Person
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string CPF {get; set;}
    public DateOnly BirthDate {get; set;}
    public decimal Income {get; set;}

    public Person(){
        Id = new Guid();
    }

}
