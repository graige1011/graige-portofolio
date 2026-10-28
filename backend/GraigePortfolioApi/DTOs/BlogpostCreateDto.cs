namespace GraigePortfolioApi.DTOs;

public class BlogpostCreateDto
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }
}