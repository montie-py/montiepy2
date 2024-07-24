namespace montiepy2.Models
{
    public enum ReviewType {
        Books,
        Music
    }

    public class ReviewEntry
    {
        public int Id { get; set;}
        public string ItemTitle { get; set;} = null!;
        public string ReviewText { get; set;} = null!;
    }
}