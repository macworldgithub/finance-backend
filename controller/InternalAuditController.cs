using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class InternalAuditController : ControllerBase
{
    private readonly InternalAuditService _service;

    public InternalAuditController(InternalAuditService service)
    {
        _service = service;
    }

    // GET: api/InternalAudit
    [HttpGet]
    public async Task<ActionResult<List<InternalAuditTest>>> Get()
    {
        var audits = await _service.GetAsync();
        return Ok(audits);
    }

    // GET: api/InternalAudit/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<InternalAuditTest>> Get(string id)
    {
        var audit = await _service.GetAsync(id);

        if (audit is null)
            return NotFound();

        return Ok(audit);
    }

    // POST: api/InternalAudit
    [HttpPost]
    public async Task<ActionResult<InternalAuditTest>> Post(InternalAuditTest audit)
    {
        await _service.CreateAsync(audit);

        return CreatedAtAction(
            nameof(Get),
            new { id = audit.Id },
            audit);
    }

    // PUT: api/InternalAudit/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, InternalAuditTest updated)
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