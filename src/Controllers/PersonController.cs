using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    [HttpGet]
    public Person GetPerson()
    {
        var someone = new Person("Jonh", 30, "15935745602");
        var newContract = new Contract("abc123", 200.00);
        someone.contracts.Add(newContract);
        return someone;
    }

    [HttpPost]
    public Person Create(Person someone)
    {
        return someone;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute]int id, [FromBody]Person someone)
    {
        return "id data" + id + "updated";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute]int id)
    {
        return "deleted id" + id;
    }

}