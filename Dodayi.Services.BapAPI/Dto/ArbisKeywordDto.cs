namespace Dodayi.Services.BapAPI.Dto
{
    public class ArbisKeywordDto
    {
        public int Id { get; set; }
        public string? Turkish { get; set; }
        public string? English { get; set; }
        public int? ArbisId { get; set; }
        public int? TempId { get; set; }
        public int? ParentId { get; set; }
    }
}
