using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        [Required]
        public int StatusID { get; set; }

        [Required]
        public int CategoriesId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Id yok — veritabanı verecek
        // CreatedDate yok — sunucu verecek
        // CreatedBy yok — sunucu (giriş yapmış kullanıcıdan) verecek
        // Status, Categories (navigation) yok — sadece ID'ler yeterli
    }
}