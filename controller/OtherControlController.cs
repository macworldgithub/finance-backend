using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class OtherControlController : ControllerBase
{
    private readonly OtherControlService _service;

    public OtherControlController(OtherControlService service)
    {
        _service = service;
    }

    // GET: api/OtherControl
    [HttpGet]
    public async Task<ActionResult<List<OtherControlEnvironment>>> Get()
    {
        var controls = await _service.GetAsync();
        return Ok(controls);
    }

    // GET: api/OtherControl/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<OtherControlEnvironment>> Get(string id)
    {
        var control = await _service.GetAsync(id);

        if (control is null)
            return NotFound();

        return Ok(control);
    }

    // POST: api/OtherControl
    [HttpPost]
    public async Task<ActionResult<OtherControlEnvironment>> Post(OtherControlEnvironment control)
    {
        await _service.CreateAsync(control);

        return CreatedAtAction(
            nameof(Get),
            new { id = control.Id },
            control);
    }

    // PUT: api/OtherControl/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, OtherControlEnvironment updated)
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