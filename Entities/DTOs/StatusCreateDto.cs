using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class StatusCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}