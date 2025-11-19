using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ControlActivitiesController : ControllerBase
{
    private readonly ControlActivitiesService _service;

    public ControlActivitiesController(ControlActivitiesService service)
    {
        _service = service;
    }

    // GET: api/ControlActivities
    [HttpGet]
    public async Task<ActionResult<List<ControlActivity>>> Get()
    {
        var activities = await _service.GetAsync();
        return Ok(activities);
    }

    // GET: api/ControlActivities/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ControlActivity>> Get(string id)
    {
        var activity = await _service.GetAsync(id);

        if (activity is null)
            return NotFound();

        return Ok(activity);
    }

    // POST: api/ControlActivities
    [HttpPost]
    public async Task<ActionResult<ControlActivity>> Post(ControlActivity activity)
    {
        await _service.CreateAsync(activity);

        return CreatedAtAction(
            nameof(Get),
            new { id = activity.Id },
            activity);
    }

    // PUT: api/ControlActivities/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, ControlActivity updated)
    {
        var existing = await _service.GetAsync(id);

        if (existing is null)
            return NotFound();

        // keep the same Id
        updated.Id = existing.Id;

        await _service.UpdateAsync(id, updated);

        return NoContent();
    }

    // DELETE: api/ControlActivities/{id}
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
