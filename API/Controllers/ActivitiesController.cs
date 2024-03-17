using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API;

public class ActivitiesController(DataContext context) : BaseApiController
{
    private readonly DataContext _context = context;
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken)
    {
        return await _context.Activities.ToListAsync(cancellationToken);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Activities.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
    }
}
