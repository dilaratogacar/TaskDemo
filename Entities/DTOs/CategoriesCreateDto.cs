using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class CategoriesCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}