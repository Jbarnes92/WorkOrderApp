using Microsoft.EntityFrameworkCore;
using WorkOrderApp.Application.Common.Interfaces;
using WorkOrderApp.Domain.Entities;
using WorkOrderApp.Infrastructure.Persistence;

namespace WorkOrderApp.Infrastructure.Repositories;

public class WorkOrderRepository : IWorkOrderRepository
{
    private readonly AppDbContext _db;

    public WorkOrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<WorkOrder>> GetAllAsync(
        string? status = null,
        string? siteCode = null,
        CancellationToken cancellationToken = default)
    {
        var query = _db.WorkOrders.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(x => x.Status == status);
        }

        if (!string.IsNullOrWhiteSpace(siteCode))
        {
            query = query.Where(x => x.SiteCode == siteCode);
        }

        return await query.
            OrderByDescending(x => x.CreatedAtUtc)
            .ToListAsync(cancellationToken);
    }
    public async Task<WorkOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _db.WorkOrders
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public async Task AddAsync(WorkOrder workOrder, CancellationToken cancellationToken = default)
    {
        await _db.WorkOrders.AddAsync(workOrder, cancellationToken);
    }
    public void Remove(WorkOrder workOrder)
    {
        _db.WorkOrders.Remove(workOrder);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
    
}

