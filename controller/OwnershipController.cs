using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]

public class OwnershipController : ControllerBase
{
    private readonly OwnershipService _service;

    public OwnershipController(OwnershipService service)
    {
        _service = service;
    }

    // GET: api/Ownership
    [HttpGet]
    public async Task<ActionResult<List<Ownership>>> Get()
    {
        var records = await _service.GetAsync();
        return Ok(records);
    }

    // GET: api/Ownership/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Ownership>> Get(string id)
    {
        var record = await _service.GetAsync(id);

        if (record is null)
            return NotFound();

        return Ok(record);
    }

    // POST: api/Ownership
    [HttpPost]
    public async Task<ActionResult<Ownership>> Post(Ownership record)
    {
        await _service.CreateAsync(record);

        return CreatedAtAction(
            nameof(Get),
            new { id = record.Id },
            record);
    }

    // PUT: api/Ownership/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, Ownership updated)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        // keep the same Id
        updated.Id = existing.Id;

        await _service.UpdateAsync(id, updated);

        return NoContent();
    }

    // DELETE: api/Ownership/{id}
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        await _service.DeleteAsync(id);

        return NoContent();
    }
}