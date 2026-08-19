using WorkOrderApp.Domain.Entities;

namespace WorkOrderApp.Application.Common.Interfaces;

public interface IWorkOrderRepository
{
    Task<List<WorkOrder>> GetAllAsync(string? status = null, string? siteCode = null, CancellationToken cancellationToken = default);
    Task<WorkOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(WorkOrder workOrder, CancellationToken cancellationToken = default);
    void Remove(WorkOrder workOrder);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}