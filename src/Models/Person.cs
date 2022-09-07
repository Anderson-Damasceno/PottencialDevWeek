
namespace src.Models;

public class Person
{
    public Person()
    {
        Name = "template";
        Age = 0;
        contracts = new();
        Active = true;
    }

    public Person(string name, int age, string cpf)
    {
        Name = name;
        Age = age;
        CPF = cpf;
        contracts = new();
        Active = true;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? CPF { get; set; }
    public bool Active { get; set; }
    public List<Contract> contracts { get; set; }

}