using Microsoft.AspNetCore.Mvc;
using core.Models;
using core.Interfaces;

namespace core.Controllers;

[ApiController]
[Route("[controller]")]
public class NutDetailsController : ControllerBase
{
    private readonly INutService _nutService;

    public NutDetailsController(INutService nutService)
    {
        _nutService = nutService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<NutDetails>> Get()
    {
        return _nutService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<NutDetails> Get(int id)
    {
        var nut = _nutService.Get(id);

        if (nut is null)
            return NotFound();

        return nut;
    }

    [HttpPost]
    public ActionResult<NutDetails> Create(NutDetails nut)
    {
        _nutService.Add(nut);

        return CreatedAtAction(nameof(Get), new { id = nut.Id }, nut);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, NutDetails nut)
    {
        if (id != nut.Id)
            return BadRequest();

        if (_nutService.Get(id) is null)
            return NotFound();

        _nutService.Update(id, nut);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_nutService.Get(id) is null)
            return NotFound();

        _nutService.Delete(id);

        return NoContent();
    }
}
