using SlaTracker_Core.Models;
using SlaTracker_Core.Enums;

namespace SlaTracker_Core.Services;

public interface ISlaService
{
    SlaStatus CalculateStatus(Ticket ticket);
}

public class SlaService : ISlaService
{
    public SlaStatus CalculateStatus(Ticket ticket)
    {
        var hoursElapsed = (DateTime.UtcNow - ticket.CreatedAt).TotalHours;
        var percentageUsed = (hoursElapsed / ticket.TargetHours) * 100;

        if (percentageUsed >= 100) return SlaStatus.Breached;
        if (percentageUsed >= 80) return SlaStatus.NearBreach;
        return SlaStatus.OnTime;
    }
}
