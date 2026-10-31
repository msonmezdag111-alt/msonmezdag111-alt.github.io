using Microsoft.EntityFrameworkCore;
using portfoliositeapi;
using portfoliositeapi.DTOs;
using Portfoliositeapi.Data;

namespace portfoliositeapi.Services;

public class ProjectService
{
    private readonly AppDbContext _db;

    public ProjectService(AppDbContext db)
    {
        _db = db;
    }

    // GET: Alle projecten
    public async Task<List<ProjectDto>> GetAll()
    {
        return await _db.Projects
            .Select(p => new ProjectDto
            {
                Id = p.Id,
                Titel = p.Titel,
                Beschrijving = p.Beschrijving,
                Categorie = p.Categorie,
                GitHubUrl = p.GitHubUrl,
                Datum = p.Datum
            })
            .ToListAsync();
    }

    // GET: Project op ID
    public async Task<ProjectDto?> GetById(int id)
    {
        var project = await _db.Projects.FindAsync(id);

        if (project == null)
            return null;

        return new ProjectDto
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        };
    }

    // POST: Project aanmaken
    public async Task<ProjectDto> Create(CreateProjectDto dto)
    {
        var project = new Project
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Categorie = dto.Categorie,
            GitHubUrl = dto.GitHubUrl,
            Datum = ""
        };

        _db.Projects.Add(project);
        await _db.SaveChangesAsync();

        return await GetById(project.Id) ?? throw new Exception("Project niet gevonden.");
    }

    // PUT: Project aanpassen
    public async Task<ProjectDto?> Update(int id, UpdateProjectDto dto)
    {
        var project = await _db.Projects.FindAsync(id);

        if (project == null)
            return null;

        project.Titel = dto.Titel;
        project.Beschrijving = dto.Beschrijving;
        project.Categorie = dto.Categorie;
        project.GitHubUrl = dto.GitHubUrl;
        project.Datum = dto.Datum;

        await _db.SaveChangesAsync();

        return await GetById(id);
    }

    // DELETE: Project verwijderen
    public async Task<bool> Delete(int id)
    {
        var project = await _db.Projects.FindAsync(id);

        if (project == null)
            return false;

        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();

        return true;
    }
}