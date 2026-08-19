namespace WorkOrderApp.Application.WorkOrders.Models;

public class UpdateWorkOrderRequest
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "";
    public string SiteCode { get; set; } = "";
}