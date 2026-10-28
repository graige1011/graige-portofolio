namespace GraigePortfolioApi.DTOs;

public class ProjectCreateDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string GitHubUrl { get; set; } = string.Empty;

    public DateTime Date { get; set; }
}