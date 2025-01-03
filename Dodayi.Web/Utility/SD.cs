namespace Dodayi.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase { get; set; } = string.Empty;
        public static string BapAPIBase { get; set; } = string.Empty;

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

    }
}
