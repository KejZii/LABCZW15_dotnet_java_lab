using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Models;

namespace BlazorApp1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Movie>().HasData(
            new Movie
            {
                Id = -1,
                Title = "Inception",
                Description = "Sci-Fi thriller",
                ReleaseDate = new DateTime(2010, 7, 16),
                Rate = 9,
                ImageUrl = "https://inception.jpg"
            },
            new Movie
            {
                Id = -2,
                Title = "The Godfather",
                Description = "Classic mafia drama",
                ReleaseDate = new DateTime(1972, 3, 24),
                Rate = 10,
                ImageUrl = "https://fwcdn.pl/fpo/10/89/1089/7196615_1.3.jpg"
            }
        );
        
        builder.Entity<UserRating>()
            .HasIndex(ur => new { ur.UserId, ur.MovieId })
            .IsUnique();

    }
    

}