using System.ComponentModel.DataAnnotations;
using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 10)]
        public int? Rate { get; set; }

        [Range(0, 10)]
        public float AverageRating { get; set; } = 0;
        
        public int RatingsCount { get; set; } = 1;

        public string? ImageUrl { get; set; }
        
        public string? YoutubeTrailerId { get; set; }
        
        public ICollection<UserRating>? UserRatings { get; set; }

    }
}