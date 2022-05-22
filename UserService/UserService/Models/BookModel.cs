namespace UserService.Models
{
    public class BookModel
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? authors { get; set; }
        public string? categories { get; set; }
        public string? publisher { get; set; }
        public string? description { get; set; }
        public DateTime? publishedDate { get; set; }
    }
}
