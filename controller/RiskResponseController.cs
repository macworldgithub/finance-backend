using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class RiskResponseController : ControllerBase
{
    private readonly RiskResponseService _service;

    public RiskResponseController(RiskResponseService service)
    {
        _service = service;
    }

    // GET: api/RiskResponse
    [HttpGet]
    public async Task<ActionResult<List<RiskResponse>>> Get()
    {
        var responses = await _service.GetAsync();
        return Ok(responses);
    }

    // GET: api/RiskResponse/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<RiskResponse>> Get(string id)
    {
        var response = await _service.GetAsync(id);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    // POST: api/RiskResponse
    [HttpPost]
    public async Task<ActionResult<RiskResponse>> Post(RiskResponse response)
    {
        await _service.CreateAsync(response);

        return CreatedAtAction(
            nameof(Get),
            new { id = response.Id },
            response);
    }

    // PUT: api/RiskResponse/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, RiskResponse updated)
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