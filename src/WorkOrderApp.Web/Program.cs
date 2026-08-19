using WorkOrderApp.Web.Components;
using Microsoft.EntityFrameworkCore;
using WorkOrderApp.Infrastructure.Persistence;
using WorkOrderApp.Application.Common.Interfaces;
using WorkOrderApp.Infrastructure.Repositories;
using WorkOrderApp.Domain.Entities;
using WorkOrderApp.Application.WorkOrders.Models;
using MudBlazor.Services;
using WorkOrderApp.Application.WorkOrders.Commands;
using WorkOrderApp.Application.WorkOrders.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=workorders.db"));

builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();

builder.Services.AddMudServices();

builder.Services.AddHttpClient();

builder.Services.AddScoped<CreateWorkOrderHandler>();

builder.Services.AddScoped<GetWorkOrdersHandler>();

builder.Services.AddScoped<UpdateWorkOrderHandler>();

builder.Services.AddScoped<DeleteWorkOrderHandler>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapGet("/api/workorders", async (
    string? status,
    string? siteCode,
    GetWorkOrdersHandler handler) =>
{
    var result = await handler.Handle(new GetWorkOrdersQuery
    {
        Status = status,
        SiteCode = siteCode
    });

    return Results.Ok(result);
});

app.MapGet("/api/workorders/{id:int}", async (int id, IWorkOrderRepository repo) =>
{
    var workOrder = await repo.GetByIdAsync(id);

    if (workOrder is null)
    {
        return Results.NotFound(new { error = "Work order not found." });
    }
    var result = new WorkOrderDto
    {
        Id = workOrder.Id,
        Title = workOrder.Title,
        Description = workOrder.Description,
        Status = workOrder.Status,
        SiteCode = workOrder.SiteCode,
        CreatedAtUtc = workOrder.CreatedAtUtc
    };
    return Results.Ok(result);
});

app.MapPost("/api/workorders", async (CreateWorkOrderRequest request, CreateWorkOrderHandler handler) =>
{
    try
    {
        var command = new CreateWorkOrderCommand
        {
            Title = request.Title,
            Description = request.Description,
            SiteCode = request.SiteCode
        };

        var result = await handler.Handle(command);

        return Results.Created($"/api/workorders/{result.Id}", result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapPut("/api/workorders/{id:int}", async (int id, UpdateWorkOrderRequest request, UpdateWorkOrderHandler handler) =>
{
    try
    {
        var command = new UpdateWorkOrderCommand
        {
            Id = id,
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            SiteCode = request.SiteCode
        };

        var result = await handler.Handle(command);
        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapDelete("/api/workorders/{id:int}", async (int id, DeleteWorkOrderHandler handler) =>
{
    try
    {
        await handler.Handle(new DeleteWorkOrderCommand { Id = id });
        return Results.NoContent();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();
