namespace Dodayi.Services.CouponAPI.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = string.Empty; // Initialize with a default value
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }
}
