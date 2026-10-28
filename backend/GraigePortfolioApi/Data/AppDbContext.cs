using GraigePortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraigePortfolioApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Blogpost> Blogposts { get; set; }
}