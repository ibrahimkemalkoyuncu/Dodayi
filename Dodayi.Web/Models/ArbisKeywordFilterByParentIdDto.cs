using System.ComponentModel.DataAnnotations;

namespace Dodayi.Web.Models
{
    public class ArbisKeywordFilterByParentIdDto
    {
        [Required(ErrorMessage = "Parent Id alanı zorunludur")]
        public int ArbisKeywordParentId { get; set; }
    }
} 