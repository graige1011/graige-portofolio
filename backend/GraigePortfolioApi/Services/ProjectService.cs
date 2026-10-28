using GraigePortfolioApi.Data;
using GraigePortfolioApi.DTOs;
using GraigePortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraigePortfolioApi.Services;

public class ProjectService
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        return await _context.Projects
            .Select(project => new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                GitHubUrl = project.GitHubUrl,
                Date = project.Date
            })
            .ToListAsync();
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return null;
        }

        return new ProjectDto
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description,
            Category = project.Category,
            GitHubUrl = project.GitHubUrl,
            Date = project.Date
        };
    }

    public async Task<ProjectDto> CreateAsync(ProjectCreateDto dto)
    {
        var project = new Project
        {
            Title = dto.Title,
            Description = dto.Description,
            Category = dto.Category,
            GitHubUrl = dto.GitHubUrl,
            Date = dto.Date
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return new ProjectDto
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description,
            Category = project.Category,
            GitHubUrl = project.GitHubUrl,
            Date = project.Date
        };
    }

    public async Task<bool> UpdateAsync(int id, ProjectUpdateDto dto)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return false;
        }

        project.Title = dto.Title;
        project.Description = dto.Description;
        project.Category = dto.Category;
        project.GitHubUrl = dto.GitHubUrl;
        project.Date = dto.Date;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return false;
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return true;
    }
}