using System.ComponentModel.DataAnnotations;

namespace Dodayi.Web.Models
{
    public class ArbisKeywordFilterByIdDto
    {
        [Required(ErrorMessage = "Id alanı zorunludur")]
        public int ArbisKeywordId { get; set; }
    }
} 