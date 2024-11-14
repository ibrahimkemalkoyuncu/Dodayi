using System.ComponentModel.DataAnnotations;

namespace Dodayi.Services.BapAPI.Models
{
    public partial class ArbisKeyword
    {
        [Key]
        public int Id { get; set; }
        public string? Turkish { get; set; }
        public string? English { get; set; }
        public int? ArbisId { get; set; }
        public int? TempId { get; set; }
        public int? ParentId { get; set; }
    }
}
