namespace WorkOrderApp.Application.WorkOrders.Models;

public class WorkOrderDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "";
    public string SiteCode { get; set; } = "";
    public DateTime CreatedAtUtc { get; set; }
}