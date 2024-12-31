namespace Dodayi.Services.BapAPI.Models
{
    public partial class Keyword
    {
        public int Id { get; set; }
        public string? Keyword1 { get; set; }
        public long? ProjectId { get; set; }
        public long? PersonId { get; set; }
        public int? Type { get; set; }
        public int? Line { get; set; }
    }
}
