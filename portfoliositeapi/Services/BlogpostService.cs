using Microsoft.EntityFrameworkCore;
using Portfoliositeapi.Data;
using Portfoliositeapi.DTOs;
using portfoliositeapi.Models;

namespace portfoliositeapi.Services;

public class BlogpostService
{
    private readonly AppDbContext _db;

    public BlogpostService(AppDbContext db)
    {
        _db = db;
    }

    // GET: Alle blogposts
    public async Task<List<BlogpostDto>> GetAll()
    {
        return await _db.Blogposts
            .Select(b => new BlogpostDto
            {
                Id = b.Id,
                Titel = b.Titel,
                Inhoud = b.Inhoud
            })
            .ToListAsync();
    }

    // GET: Blogpost op ID
    public async Task<BlogpostDto?> GetById(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);

        if (blogpost == null)
            return null;

        return new BlogpostDto
        {
            Id = blogpost.Id,
            Titel = blogpost.Titel,
            Inhoud = blogpost.Inhoud
        };
    }

    // POST: Blogpost aanmaken
    public async Task<BlogpostDto> Create(CreateBlogpostDto dto)
    {
        var blogpost = new Blogpost
        {
            Titel = dto.Titel,
            Inhoud = dto.Inhoud
        };

        _db.Blogposts.Add(blogpost);
        await _db.SaveChangesAsync();

        return await GetById(blogpost.Id)
               ?? throw new Exception("Blogpost niet gevonden.");
    }

    // PUT: Blogpost aanpassen
    public async Task<BlogpostDto?> Update(int id, UpdateBlogpostDto dto)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);

        if (blogpost == null)
            return null;

        blogpost.Titel = dto.Titel;
        blogpost.Inhoud = dto.Inhoud;

        await _db.SaveChangesAsync();

        return await GetById(id);
    }

    // DELETE: Blogpost verwijderen
    public async Task<bool> Delete(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);

        if (blogpost == null)
            return false;

        _db.Blogposts.Remove(blogpost);
        await _db.SaveChangesAsync();

        return true;
    }
}