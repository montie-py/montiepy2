using System.ComponentModel.DataAnnotations;

namespace montiepy2.Business.Models
{
    public class RadioEntry
    {
        public string Id { get; set; } = null!;
        public string Url { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}