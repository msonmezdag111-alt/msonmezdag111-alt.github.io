using Microsoft.EntityFrameworkCore;
using portfoliositeapi.DTOs;
using Portfoliositeapi.Data;
using portfoliositeapi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Services registreren
builder.Services.AddScoped<ProjectService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "ByteForge API werkt!");

// PROJECTS

app.MapGet("/projects", async (ProjectService service) =>
{
    return Results.Ok(await service.GetAll());
});

app.MapGet("/projects/{id}", async (int id, ProjectService service) =>
{
    var project = await service.GetById(id);

    if (project == null)
        return Results.NotFound();

    return Results.Ok(project);
});

app.MapPost("/projects", async (CreateProjectDto dto, ProjectService service) =>
{
    var project = await service.Create(dto);

    return Results.Created($"/projects/{project.Id}", project);
});

app.MapPut("/projects/{id}", async (int id, UpdateProjectDto dto, ProjectService service) =>
{
    var project = await service.Update(id, dto);

    if (project == null)
        return Results.NotFound();

    return Results.Ok(project);
});

app.MapDelete("/projects/{id}", async (int id, ProjectService service) =>
{
    var deleted = await service.Delete(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});

app.Run();