using GraigePortfolioApi.DTOs;
using GraigePortfolioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraigePortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _blogpostService;

    public BlogpostsController(BlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlogpostDto>>> GetAll()
    {
        return Ok(await _blogpostService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostDto>> GetById(int id)
    {
        var blogpost = await _blogpostService.GetByIdAsync(id);

        if (blogpost == null)
        {
            return NotFound();
        }

        return Ok(blogpost);
    }

    [HttpPost]
    public async Task<ActionResult<BlogpostDto>> Create(BlogpostCreateDto dto)
    {
        var createdBlogpost = await _blogpostService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdBlogpost.Id },
            createdBlogpost
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BlogpostUpdateDto dto)
    {
        var updated = await _blogpostService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _blogpostService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}