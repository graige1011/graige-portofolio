namespace GraigePortfolioApi.DTOs;

public class BlogpostUpdateDto
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }
}