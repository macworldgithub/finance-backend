using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]

public class GCRExceptionController : ControllerBase
{
    private readonly GCRExceptionService _service;

    public GCRExceptionController(GCRExceptionService service)
    {
        _service = service;
    }

    // GET: api/GCRException
    [HttpGet]
    public async Task<ActionResult<List<GRCExceptionLog>>> Get()
    {
        var exceptions = await _service.GetAsync();
        return Ok(exceptions);
    }

    // GET: api/GCRException/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<GRCExceptionLog>> Get(string id)
    {

        var exception = await _service.GetAsync(id);

        if (exception is null)
            return NotFound();

        return Ok(exception);
    }

    // POST: api/GCRException
    [HttpPost]
    public async Task<ActionResult<GRCExceptionLog>> Post(GRCExceptionLog exception)
    {
        await _service.CreateAsync(exception);

        return CreatedAtAction(
            nameof(Get),
            new { id = exception.Id },
            exception);
    }

    // PUT: api/GCRException/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, GRCExceptionLog updated)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        // keep the same Id
        updated.Id = existing.Id;

        await _service.UpdateAsync(id, updated);

        return NoContent();
    }

      public async Task<IActionResult> Delete(string id)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        await _service.DeleteAsync(id);

        return NoContent();
    } 
}