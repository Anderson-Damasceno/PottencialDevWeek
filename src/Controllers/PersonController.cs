using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private DataBaseContext? _context { get; set; }

    public PersonController(DataBaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Person> GetPerson()
    {
        // var someone = new Person("Jonh", 30, "15935745602");
        // var newContract = new Contract("abc123", 200.00);
        // someone.contracts.Add(newContract);
        return _context!.People!.Include(p => p.contracts).ToList();
    }

    [HttpPost]
    public Person Create([FromBody] Person someone)
    {
        _context!.People!.Add(someone);
        _context.SaveChanges();
        return someone;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person someone)
    {
        _context!.People!.Update(someone);
        _context.SaveChanges();

        return "updated";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        return "deleted id" + id;
    }

}