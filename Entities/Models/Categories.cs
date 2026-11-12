namespace Entities.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        ////Tabloda bir koleksiyon halinde Book tablosu ile ilişkili
        ////Birden fazla kitap olma durumunda kullanılır.
    }
}
