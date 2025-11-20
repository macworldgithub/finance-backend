using Microsoft.AspNetCore.Mvc;
using YourAppName.Models;

[ApiController]
[Route("api/[controller]")]

public class ProcessesController : ControllerBase
{
    private readonly ProcessesService _service;

    public ProcessesController(ProcessesService service)
    {
        _service = service;
    }

    // GET: api/Processes
    [HttpGet]
    public async Task<ActionResult<List<Processes>>> Get()
    {
        var processes = await _service.GetAsync();
        return Ok(processes);
    }

    // GET: api/Processes/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Processes>> Get(string id)
    {
        var process = await _service.GetAsync(id);

        if (process is null)
            return NotFound();

        return Ok(process);
    }

    // POST: api/Processes
    [HttpPost]
    public async Task<ActionResult<Processes>> Post(Processes process)
    {
        await _service.CreateAsync(process);

        return CreatedAtAction(
            nameof(Get),
            new { id = process.Id },
            process);
    }

    // PUT: api/Processes/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, Processes updated)
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