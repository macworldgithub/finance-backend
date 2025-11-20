using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]

public class SoxControlController : ControllerBase
{
    private readonly SoxControlService _service;

    public SoxControlController(SoxControlService service)
    {
        _service = service;
    }

    // GET: api/SoxControl
    [HttpGet]
    public async Task<ActionResult<List<SOXControl>>> Get()
    {
        var controls = await _service.GetAsync();
        return Ok(controls);
    }

    // GET: api/SoxControl/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<SOXControl>> Get(string id)
    {
        var control = await _service.GetAsync(id);

        if (control is null)
            return NotFound();

        return Ok(control);
    }

    // POST: api/SoxControl
    [HttpPost]
    public async Task<ActionResult<SOXControl>> Post(SOXControl control)
    {
        await _service.CreateAsync(control);

        return CreatedAtAction(
            nameof(Get),
            new { id = control.Id },
            control);
    }

    // PUT: api/SoxControl/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, SOXControl updated)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        // keep the same Id
        updated.Id = existing.Id;

        await _service.UpdateAsync(id, updated);

        return NoContent();
    }

}