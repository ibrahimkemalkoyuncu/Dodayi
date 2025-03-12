using System.ComponentModel.DataAnnotations;

namespace Dodayi.Services.CouponAPI.Models
{
    /// <summary>
    /// Kupon bilgilerini tutan model sınıfı
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Kupon benzersiz kimlik numarası
        /// </summary>
        [Key]
        public int CouponId { get; set; }

        /// <summary>
        /// Kupon kodu - kuponun kullanımı için gereken kod
        /// </summary>
        [Required]
        public required string CouponCode { get; set; }

        /// <summary>
        /// İndirim tutarı - uygulanan indirimin miktarı
        /// </summary>
        [Required]
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Minimum alışveriş tutarı - kuponun geçerli olması için gereken minimum alışveriş tutarı
        /// </summary>
        public int MinAmount { get; set; }

    }
}
