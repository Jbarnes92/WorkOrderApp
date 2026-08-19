namespace WorkOrderApp.Application.WorkOrders.Commands;

public class UpdateWorkOrderCommand
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "";
    public string SiteCode { get; set; } = "";
}