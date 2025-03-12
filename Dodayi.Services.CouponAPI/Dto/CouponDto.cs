namespace Dodayi.Services.CouponAPI.Dto
{
    /// <summary>
    /// Kupon bilgilerini taşıyan veri transfer nesnesi (DTO)
    /// Kupon modeli ile istemci arasında veri alışverişi için kullanılır
    /// </summary>
    public class CouponDto
    {
        /// <summary>
        /// Kupon benzersiz kimlik numarası
        /// </summary>
        public int CouponId { get; set; }

        /// <summary>
        /// Kupon kodu - kuponun kullanımı için gereken kod
        /// </summary>
        public string CouponCode { get; set; } = string.Empty; // Initialize with a default value

        /// <summary>
        /// İndirim tutarı - uygulanan indirimin miktarı
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Minimum alışveriş tutarı - kuponun geçerli olması için gereken minimum alışveriş tutarı
        /// </summary>
        public int MinAmount { get; set; }

    }
}
