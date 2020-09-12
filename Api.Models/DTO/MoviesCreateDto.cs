using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTO
{
    //Используй конфигурации сущностей для валидации вместо дто
    //Твоя дто должна быть чистой
    public class MoviesCreateDto
    {
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