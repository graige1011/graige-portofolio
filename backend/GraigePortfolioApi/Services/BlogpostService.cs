using GraigePortfolioApi.Data;
using GraigePortfolioApi.DTOs;
using GraigePortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraigePortfolioApi.Services;

public class BlogpostService
{
    private readonly AppDbContext _context;

    public BlogpostService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BlogpostDto>> GetAllAsync()
    {
        return await _context.Blogposts
            .Select(blogpost => new BlogpostDto
            {
                Id = blogpost.Id,
                Title = blogpost.Title,
                Content = blogpost.Content,
                PublicationDate = blogpost.PublicationDate
            })
            .ToListAsync();
    }

    public async Task<BlogpostDto?> GetByIdAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost == null)
        {
            return null;
        }

        return new BlogpostDto
        {
            Id = blogpost.Id,
            Title = blogpost.Title,
            Content = blogpost.Content,
            PublicationDate = blogpost.PublicationDate
        };
    }

    public async Task<BlogpostDto> CreateAsync(BlogpostCreateDto dto)
    {
        var blogpost = new Blogpost
        {
            Title = dto.Title,
            Content = dto.Content,
            PublicationDate = dto.PublicationDate
        };

        _context.Blogposts.Add(blogpost);
        await _context.SaveChangesAsync();

        return new BlogpostDto
        {
            Id = blogpost.Id,
            Title = blogpost.Title,
            Content = blogpost.Content,
            PublicationDate = blogpost.PublicationDate
        };
    }

    public async Task<bool> UpdateAsync(int id, BlogpostUpdateDto dto)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost == null)
        {
            return false;
        }

        blogpost.Title = dto.Title;
        blogpost.Content = dto.Content;
        blogpost.PublicationDate = dto.PublicationDate;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost == null)
        {
            return false;
        }

        _context.Blogposts.Remove(blogpost);
        await _context.SaveChangesAsync();

        return true;
    }
}