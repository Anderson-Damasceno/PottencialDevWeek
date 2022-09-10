using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
    public ActionResult<List<Person>> GetPerson()
    {
        var result = _context!.People!.Include(p => p.contracts).ToList();

        if (!result.Any()) return NoContent();

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Create([FromBody] Person someone)
    {
        try
        {
            _context!.People!.Add(someone);
            _context.SaveChanges();

        }
        catch (System.Exception)
        {
            
            return BadRequest();
        }
        
        return Created("Created",someone);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person someone)
    {
        var result = _context!.People!.SingleOrDefault(e => e.Id == id);
        if(result is null) return NotFound(new {msg = "Record not found", status = HttpStatusCode.NotFound});

        try
        {
            _context!.People!.Update(someone);
            _context.SaveChanges();

        }
        catch (System.Exception)
        {

            return BadRequest(new {msg = "There was id update error" + id, status = HttpStatusCode.BadRequest});
        }

        return Ok(new { msg = "id data" + id + "updated", statu = HttpStatusCode.OK });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _context!.People!.SingleOrDefault(e => e.Id == id);

        if (result is null) return BadRequest(new { msg = "Absent content, invalid request", status = HttpStatusCode.BadRequest });

        _context.Remove(result);
        _context.SaveChanges();

        return Ok(new { msg = "deleted id" + id, status = HttpStatusCode.OK });
    }

}