using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTO
{
    public class MoviesReadDto
    {
        [Required]
        public int MovieId { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        
        [Required]
        public int Year { get; set; }
        
        [Required]
        public int AgeRestriction { get; set; }
        
        [Required]
        public float Price { get; set; }
    }
}