using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")] 

public class FinancialStatementController : ControllerBase
{
    private readonly FinancialStatementService _service;

    public FinancialStatementController(FinancialStatementService service)
    {
        _service = service;
    }

    // GET: api/FinancialStatement
    [HttpGet]
    public async Task<ActionResult<List<FinancialStatementAssertion>>> Get()
    {
        var statements = await _service.GetAsync();
        return Ok(statements);
    }

    // GET: api/FinancialStatement/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<FinancialStatementAssertion>> Get(string id)
    {
        var statement = await _service.GetAsync(id);

        if (statement is null)
            return NotFound();

        return Ok(statement);
    }

    // POST: api/FinancialStatement
    [HttpPost]
    public async Task<ActionResult<FinancialStatementAssertion>> Post(FinancialStatementAssertion statement)
    {
        await _service.CreateAsync(statement);

        return CreatedAtAction(
            nameof(Get),
            new { id = statement.Id },
            statement);
    }

    // PUT: api/FinancialStatement/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, FinancialStatementAssertion updated)
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