namespace WorkOrderApp.Application.WorkOrders.Models;

public class CreateWorkOrderRequest
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string SiteCode { get; set; } = "";

}