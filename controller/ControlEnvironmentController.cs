using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class ControlEnvironmentController : ControllerBase
{
    private readonly ControlEnvironmentService _service;

    public ControlEnvironmentController(ControlEnvironmentService service)
    {
        _service = service;
    }

    // GET: api/ControlEnvironment
    [HttpGet]
    public async Task<ActionResult<List<ControlEnvironment>>> Get()
    {
        var environments = await _service.GetAsync();
        return Ok(environments);
    }

    // GET: api/ControlEnvironment/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ControlEnvironment>> Get(string id)
    {
        var environment = await _service.GetAsync(id);

        if (environment is null)
            return NotFound();

        return Ok(environment);
    }

    // POST: api/ControlEnvironment
    [HttpPost]
    public async Task<ActionResult<ControlEnvironment>> Post(ControlEnvironment environment)
    {
        await _service.CreateAsync(environment);

        return CreatedAtAction(
            nameof(Get),
            new { id = environment.Id },
            environment);
    }

    // PUT: api/ControlEnvironment/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, ControlEnvironment updated)
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