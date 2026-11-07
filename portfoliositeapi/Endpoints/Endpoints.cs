using portfoliositeapi.DTOs;
using Portfoliositeapi.DTOs;
using portfoliositeapi.Services;

namespace portfoliositeapi.Endpoints;

public class Endpoints
{
    private WebApplication app;
    public Endpoints(WebApplication app)
    // project deel
    {
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
        
        // blogpost deel
        app.MapGet("/blogposts", async (BlogpostService service) =>
        {
            return Results.Ok(await service.GetAll());
        });
        
        app.MapGet("/blogposts/{id}", async (int id, BlogpostService service) =>
        {
            var blogpost = await service.GetById(id);

            if (blogpost == null)
                return Results.NotFound();

            return Results.Ok(blogpost);
        });
        
        app.MapPost("/blogposts", async (CreateBlogpostDto dto, BlogpostService service) =>
        {
            var blogpost = await service.Create(dto);

            return Results.Created($"/blogposts/{blogpost.Id}", blogpost);
        });
        
        app.MapPut("/blogposts/{id}", async (int id, UpdateBlogpostDto dto, BlogpostService service) =>
        {
            var blogpost = await service.Update(id, dto);

            if (blogpost == null)
                return Results.NotFound();

            return Results.Ok(blogpost);
        });
        
        app.MapDelete("/blogposts/{id}", async (int id, BlogpostService service) =>
        {
            var deleted = await service.Delete(id);

            if (!deleted)
                return Results.NotFound();

            return Results.NoContent();
        });
    }
    }