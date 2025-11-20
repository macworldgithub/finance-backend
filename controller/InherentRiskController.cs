using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]

public class InherentRiskController : ControllerBase
{
    private readonly InherentRiskService _service;

    public InherentRiskController(InherentRiskService service)
    {
        _service = service;
    }

    // GET: api/InherentRisk
    [HttpGet]
    public async Task<ActionResult<List<InherentRiskAssessment>>> Get()
    {
        var risks = await _service.GetAsync();
        return Ok(risks);
    }

    // GET: api/InherentRisk/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<InherentRiskAssessment>> Get(string id)
    {
        var risk = await _service.GetAsync(id);

        if (risk is null)
            return NotFound();

        return Ok(risk);
    }

    // POST: api/InherentRisk
    [HttpPost]
    public async Task<ActionResult<InherentRiskAssessment>> Post(InherentRiskAssessment risk)
    {
        await _service.CreateAsync(risk);

        return CreatedAtAction(
            nameof(Get),
            new { id = risk.Id },
            risk);
    }

    // PUT: api/InherentRisk/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, InherentRiskAssessment updated)
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