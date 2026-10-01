using SlaTracker_Core.Enums;

namespace SlaTracker_Core.Models;

public class Ticket
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int TargetHours { get; set; } = 24;
    public SlaStatus Status { get; set; } = SlaStatus.OnTime;
}
