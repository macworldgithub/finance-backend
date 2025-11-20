using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] 

public class ResidiualRiskController : ControllerBase
{
    private readonly ResidualRiskService _service;

    public ResidiualRiskController(ResidualRiskService service)
    {
        _service = service;
    }

    // GET: api/ResidiualRisk
    [HttpGet]
    public async Task<ActionResult<List<ResidualRiskAssessment>>> Get()
    {
        var risks = await _service.GetAsync();
        return Ok(risks);
    }

    // GET: api/ResidiualRisk/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ResidualRiskAssessment>> Get(string id)
    {
        var risk = await _service.GetAsync(id);

        if (risk is null)
            return NotFound();

        return Ok(risk);
    }

    // POST: api/ResidiualRisk
    [HttpPost]
    public async Task<ActionResult<ResidualRiskAssessment>> Post(ResidualRiskAssessment risk)
    {
        await _service.CreateAsync(risk);

        return CreatedAtAction(
            nameof(Get),
            new { id = risk.Id },
            risk);
    }

    // PUT: api/ResidiualRisk/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, ResidualRiskAssessment updated)
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