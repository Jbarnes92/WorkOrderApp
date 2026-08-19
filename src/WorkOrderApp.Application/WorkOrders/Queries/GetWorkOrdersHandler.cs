using WorkOrderApp.Application.Common.Interfaces;
using WorkOrderApp.Application.WorkOrders.Models;

namespace WorkOrderApp.Application.WorkOrders.Queries;

public class GetWorkOrdersHandler
{
    private readonly IWorkOrderRepository _repo;

    public GetWorkOrdersHandler(IWorkOrderRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<WorkOrderDto>> Handle(GetWorkOrdersQuery query, CancellationToken ct = default)
    {
        var workOrders = await _repo.GetAllAsync(query.Status, query.SiteCode, ct);

        return workOrders.Select(x => new WorkOrderDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Status = x.Status,
            SiteCode = x.SiteCode,
            CreatedAtUtc = x.CreatedAtUtc
        }).ToList();
    }
}