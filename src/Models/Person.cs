namespace formAPI.src.Models;

public class Person
{
    public Guid Id {get; private set;}
    public string Name {get; set;}
    public string _CPF;
    public string CPF {
        get {
            return _CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }
        set{
            string temp = value.Replace("-", "").Replace(".", "").Trim();
            if(temp.Length == 11){
                _CPF = temp;
            }
            else{
                throw new Exception("Invalid Document!");
            }
        }
    }
    public DateOnly BirthDate {get; set;}
    public decimal MonthlyIncome {get; set;}
    public DateOnly? DeletedAt {get; private set;}


    public Person(){
        Id = new Guid();
        DeletedAt = null;
    }

    public void DeletePerson(){
        DeletedAt = DateOnly.FromDateTime(DateTime.Now);
    }

}
