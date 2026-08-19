using WorkOrderApp.Application.Common.Interfaces;
using WorkOrderApp.Application.WorkOrders.Models;

namespace WorkOrderApp.Application.WorkOrders.Commands;

public class UpdateWorkOrderHandler
{
    private readonly IWorkOrderRepository _repo;

    public UpdateWorkOrderHandler(IWorkOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<WorkOrderDto> Handle(UpdateWorkOrderCommand command, CancellationToken ct = default)
    {
        var workOrder = await _repo.GetByIdAsync(command.Id, ct);

        if (workOrder is null)
        {
            throw new ArgumentException("Work order not found.");
        }
        if (string.IsNullOrWhiteSpace(command.Title))
        {
            throw new ArgumentException("Title is required.");
        }
        if (command.Title.Length > 200)
        {
            throw new ArgumentException("Title must be 200 characters or fewer.");
        }
        if (string.IsNullOrWhiteSpace(command.SiteCode))
        {
            throw new ArgumentException("SiteCode is required.");
        }
        if (string.IsNullOrWhiteSpace(command.Status))
        {
            throw new ArgumentException("Status is required.");
        }

        workOrder.Title = command.Title.Trim();
        workOrder.Description = command.Description?.Trim() ?? "";
        workOrder.Status = command.Status.Trim();
        workOrder.SiteCode = command.SiteCode.Trim();

        await _repo.SaveChangesAsync(ct);

        return new WorkOrderDto
        {
            Id = workOrder.Id,
            Title = workOrder.Title,
            Description = workOrder.Description,
            Status = workOrder.Status,
            SiteCode = workOrder.SiteCode,
            CreatedAtUtc = workOrder.CreatedAtUtc
        };
    }
}