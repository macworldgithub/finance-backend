using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ControlAssessmentController : ControllerBase
{
    private readonly ControlAssessmentService _service;

    public ControlAssessmentController(ControlAssessmentService service)
    {
        _service = service;
    }

    // GET: api/ControlAssessment
    [HttpGet]
    public async Task<ActionResult<List<ControlAssessment>>> Get()
    {
        var assessments = await _service.GetAsync();
        return Ok(assessments);
    }
    // GET: api/ControlAssessment/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ControlAssessment>> Get(string id)
    {
        var assessment = await _service.GetAsync(id);
        if (assessment == null)
        {
            return NotFound();
        }
        return Ok(assessment);
    }
    // POST: api/ControlAssessment
    [HttpPost]
    public async Task<ActionResult<ControlAssessment>> Post(ControlAssessment assessment)
    {
        await _service.CreateAsync(assessment);

        return CreatedAtAction(
            nameof(Get),
            new { id = assessment.Id },
            assessment);
    }
    // PUT: api/ControlAssessment/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, ControlAssessment updated)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        // keep the same Id
        updated.Id = existing.Id;

        await _service.UpdateAsync(id, updated);

        return NoContent();
    }
    // DELETE: api/ControlAssessment/{id}
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