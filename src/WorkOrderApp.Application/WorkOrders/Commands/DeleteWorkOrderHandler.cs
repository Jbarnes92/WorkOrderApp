using WorkOrderApp.Application.Common.Interfaces;

namespace WorkOrderApp.Application.WorkOrders.Commands;

public class DeleteWorkOrderHandler
{
    private readonly IWorkOrderRepository _repo;

    public DeleteWorkOrderHandler(IWorkOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(DeleteWorkOrderCommand command, CancellationToken ct = default)
    {
        var workOrder = await _repo.GetByIdAsync(command.Id, ct);

        if (workOrder is null)
        {
            throw new ArgumentException("Work order not found.");
        }

        _repo.Remove(workOrder);
        await _repo.SaveChangesAsync(ct);
    }
}