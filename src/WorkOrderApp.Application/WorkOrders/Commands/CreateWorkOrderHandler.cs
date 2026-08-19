using WorkOrderApp.Application.Common.Interfaces;
using WorkOrderApp.Application.WorkOrders.Models;
using WorkOrderApp.Domain.Entities;

namespace WorkOrderApp.Application.WorkOrders.Commands;

public class CreateWorkOrderHandler
{
    private readonly IWorkOrderRepository _repo;

    public CreateWorkOrderHandler(IWorkOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<WorkOrderDto> Handle(CreateWorkOrderCommand command, CancellationToken ct = default)
    {
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

        var workOrder = new WorkOrder
        {
            Title = command.Title.Trim(),
            Description = command.Description?.Trim() ?? "",
            Status = "Open",
            SiteCode = command.SiteCode.Trim(),
            CreatedAtUtc = DateTime.UtcNow
        };

        await _repo.AddAsync(workOrder, ct);
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