using System.ComponentModel.DataAnnotations;
using BlazorApp1.Data;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp1.Models
{
    public class UserRating
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public int MovieId { get; set; }
        
        [Range(1, 10)]
        public int Rating { get; set; }
        
        public Movie Movie { get; set; }
    }
}