using System.Net.NetworkInformation;

namespace Entities.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int StatusID { get; set; }
        public Status Status { get; set; } = null!;

        public int CategoriesId { get; set; }
        public Categories Categories { get; set; } = null!;

        public string Priority { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

    }
}
