using System.ComponentModel.DataAnnotations;

namespace montiepy2.Models
{
    public class BlogEntry
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Text { get; set; } = null!;
    }
}
