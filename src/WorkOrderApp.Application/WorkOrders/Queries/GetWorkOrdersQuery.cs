namespace WorkOrderApp.Application.WorkOrders.Queries;

public class GetWorkOrdersQuery
{
    public string? Status { get; set; }
    public string? SiteCode { get; set; }
}