namespace WorkOrderApp.Application.WorkOrders.Commands;

public class CreateWorkOrderCommand
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string SiteCode { get; set; } = "";
}