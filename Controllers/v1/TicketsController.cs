using Microsoft.AspNetCore.Mvc;
using SlaTracker_Core.Models;
using SlaTracker_Core.Services;

namespace SlaTracker_Core.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class TicketsController : ControllerBase
{
    private static readonly List<Ticket> _tickets = new();
    private readonly ISlaService _slaService;

    public TicketsController(ISlaService slaService)
    {
        _slaService = slaService;
    }

    [HttpGet]
    public IActionResult GetTickets()
    {
        var result = _tickets.Select(t => new
        {
            t.Id,
            t.Title,
            t.Description,
            t.CreatedAt,
            t.TargetHours,
            SlaStatus = _slaService.CalculateStatus(t).ToString()
        });

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateTicket([FromBody] Ticket ticket)
    {
        ticket.CreatedAt = DateTime.UtcNow;
        _tickets.Add(ticket);

        return CreatedAtAction(nameof(GetTickets), new { id = ticket.Id }, new
        {
            ticket.Id,
            ticket.Title,
            SlaStatus = _slaService.CalculateStatus(ticket).ToString()
        });
    }
}
